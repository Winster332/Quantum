using System;
using System.Collections.Generic;
using Quantum.CSSOM;
using Quantum.Parser.Common;

namespace Quantum.Parser.CSS
{
  public class CssStateMachineInstance : StateMachineInstance
  {
    public Dictionary<string, string> Fields { get; set; }
    public string CurrentSelector { get; set; }
    public CSSStyleSheet StyleSheet { get; set; }

    public CssStateMachineInstance()
    {
      StyleSheet = new CSSStyleSheet();
      StyleSheet.Disabled = false;
      Fields = new Dictionary<string, string>();
    }

    public void BuildStyle()
    {
      var rule = new CSSRule();
      rule.Type = CSSRuleType.StyleRule;
      rule.ParentStyleSheet = StyleSheet;
      rule.SelectorText = CurrentSelector.Replace("\r", "");
      rule.Style = CSSStyleDeclaration.Parse(Fields);

      StyleSheet.CssRules.Add(rule);

      CurrentSelector = string.Empty;
      Fields.Clear();
    }
  }
}