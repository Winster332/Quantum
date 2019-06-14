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
        private Document _document;
        private Window _window;
        public RenderTree()
        {
            LayoutRoot = null;
        }

        public void Build(Window window)
        {
            _window = window;
            _document = _window.Document;
            
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
                CssRule = FindClasses(htmlElement as HTMLElement).FirstOrDefault()
            };
            
            BuildRenderStructure(layout);
            currentLayout.AddLayout(layout);
        }

        private List<CSSRule> FindClasses(HTMLElement element)
        {
            var styles = new List<CSSRule>();
            
            if (element == null)
            {
                return styles;
            }

            var className = element.GetAttribute("class")?.Value.Replace("\"", "").Replace(".", "");
            if (className != null)
            {
                styles = _document.StyleSheets
                    .Select(x => x as CSSStyleSheet)
                    .SelectMany(x => x.CssRules)
                    .Where(x => x.SelectorText.Replace(".", "").Replace("\"", "") == className)
                    .ToList();
            }

            return styles;
        }
    }
}