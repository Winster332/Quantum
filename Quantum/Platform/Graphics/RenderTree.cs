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
        public RenderTree()
        {
            LayoutRoot = null;
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
            
            BuildRenderStructure(layout);
            currentLayout.AddLayout(layout);

            if (layout.CssRule == null)
            {
              layout.CssRule = layout.MerageStyleWithParent();
            }
        }
    }
}