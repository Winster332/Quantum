using System;
using System.Collections.Generic;
using System.Linq;
using Quantum.CSSOM;
using Quantum.DOM;
using Quantum.HTML;

namespace Quantum.Platform.Graphics
{
    public class RenderTree
    {
        public RenderLayout LayoutRoot { get; set; }
        private BinderElementStyle _binderElementStyle;
        private Document _document;
        private Window _window;
        private RenderCompositor _compositor;
        
        public RenderTree()
        {
            LayoutRoot = null;
            _compositor = new RenderCompositor(_window);
        }

        public void Build(Window window)
        {
            _window = window;
            _document = _window.Document;
            _binderElementStyle = new BinderElementStyle(_document);
            
            TransformHtmlToRender();
        }

        private void TransformHtmlToRender()
        {
            var htmlRoots = _document.ChildNodes.Select(x => x as HTMLElement).ToList();
            LayoutRoot = new RenderLayout();
            
            foreach (var element in htmlRoots)
            {
                LayoutRoot.Element = null;
                LayoutRoot.Layouts.Add(new RenderLayout
                {
                    Element = element
                });
            }
            
            BuildRenderStructure(LayoutRoot);
        }

        private void BuildRenderStructure(RenderLayout prevLayout)
        {
            foreach (var currentLayout in prevLayout.Layouts)
            {
                foreach (var htmlElement in currentLayout.Element.Children)
                {
                    AddNewLayout(htmlElement, currentLayout);
                }
            }

            if (prevLayout.Layouts.Count == 0 && prevLayout.Element.ChildElementCount != 0)
            {
                foreach (var htmlElement in prevLayout.Element.Children)
                {
                    AddNewLayout(htmlElement, prevLayout);
                }
            }
        }

        private void AddNewLayout(Element htmlElement, RenderLayout currentLayout)
        {
            var layout = new RenderLayout
            {
                Element = htmlElement as HTMLElement,
                CssRule = _binderElementStyle.Bind(htmlElement as HTMLElement).FirstOrDefault()
            };
            
            if (layout.CssRule != null && currentLayout.CssRule != null)
            {
                var parentStyle = currentLayout.CssRule.Style;
                var currentStyle = layout.CssRule.Style;

                layout.CssRule.Style = MergeStyle(parentStyle, currentStyle);
            }

            if (layout.CssRule == null)
            {
                layout.CssRule = currentLayout.CssRule;
            }
            
            _compositor.CompositeApply(layout);
            
            BuildRenderStructure(layout);
            currentLayout.AddLayout(layout);
        }

        private CSSStyleDeclaration MergeStyle(CSSStyleDeclaration def1, CSSStyleDeclaration def2)
        {
            var result = def2.Clone() as CSSStyleDeclaration;

            foreach (var def1ChangedField in def1.ChangedFields)
            {
                var isDoubleChenge = def2.ChangedFields.FirstOrDefault(x => x == def1ChangedField);

                if (isDoubleChenge == null)
                {
                    var def1PropertyValue = def1.GetType().GetProperty(def1ChangedField).GetValue(def1);
                    result.GetType().GetProperty(def1ChangedField).SetValue(result, def1PropertyValue);
                }
            }
            
            return result;
        }
    }
}