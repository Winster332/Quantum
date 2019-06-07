using System;
using System.Linq;
using Quantum.Parser.Common;

namespace Quantum.Parser.CSS
{
    public class CssStateMachineProcessor : StateMachine<CssStateMachineInstance>
    {
        public event EventHandler<string> DetectSelector;
        public event EventHandler<string> DetectOpenStyle;
        public event EventHandler<string> DetectCloseStyle;
        public event EventHandler<string> DetectStyleDecField;
        public event EventHandler StartedProcessing;
        public event EventHandler StoppedProcessing;
        public const char CharacterOpenStyle = '{';
        public const char CharacterCloseStyle = '}';
        public const char CharacterDetectStyleField = ';';
        public CssStateMachineProcessor(string source) : base(source)
        {
        }

        public override void ResolveSymbol()
        {
            if (_currentIndex == 0)
            {
                BeginProcessing();
            }

            if (_currentIndex == _maxIndex)
            {
                EndProcessing();
            }
            
            if (Instance.LastSymbol == CharacterOpenStyle)
            {
                CreateSelector();
                OpenStyle();
            }
            
            if (Instance.LastSymbol == CharacterCloseStyle)
            {
                CloseStyle();
            }
            
            if (Instance.LastSymbol == CharacterDetectStyleField)
            {
                DetectStyleField();
            }
        }

        public void CreateSelector()
        {
            var selector = _htmlSource.Substring(Instance.FirstIndex, Instance.LastIndex - Instance.FirstIndex)
                .Replace("\n", "")
                .Replace(" ", "");
            
            DetectSelector?.Invoke(this, selector);
            
            Instance.CurrentSelector = selector;
            Instance.Commit();
        }

        public void OpenStyle()
        {
            DetectOpenStyle?.Invoke(this, Instance.CurrentSelector);
            
            Instance.Commit();
        }
        
        public void CloseStyle()
        {
            DetectCloseStyle?.Invoke(this, Instance.CurrentSelector);
            
            Instance.BuildStyle();
            Instance.Commit();
        }
        
        public void DetectStyleField()
        {
            var field = _htmlSource.Substring(Instance.FirstIndex, Instance.LastIndex - Instance.FirstIndex)
                .Split(':');

            var key = field.FirstOrDefault()
                .Replace("\n", "")
                .Replace("\t", "")
                .Replace(" ", "");
            var value = field.LastOrDefault();
            
            DetectStyleDecField?.Invoke(this, string.Concat(field));
            
            Instance.Fields.Add(key, value);
            Instance.Commit();
        }

        public void BeginProcessing()
        {
            StartedProcessing?.Invoke(this, null);
        }

        public void EndProcessing()
        {
//            var nodeName = _htmlSource.Substring(Instance.FirstIndex, Instance.LastIndex - Instance.FirstIndex);
//            AddElementToInstance(nodeName);
//            Instance.State = HtmlProcessorStates.Finished;
            Instance.Commit();

            StoppedProcessing?.Invoke(this, null);
        }
    }
}
