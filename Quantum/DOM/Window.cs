using System;
using Quantum.CSSOM;
using Quantum.DOM.Events;

namespace Quantum.DOM
{
    public class Window : IWindowEventHandlers
    {
        public DOMEventHandler<IWindowEvent> OnAfterPrint { get; set; }
        public DOMEventHandler<IWindowEvent> OnBeforePrint { get; set; }
        public DOMEventHandler<IWindowEvent> OnBeforeUnload { get; set; }
        public DOMEventHandler<IWindowEvent> OnHashChenge { get; set; }
        public DOMEventHandler<IWindowEvent> OnLanguageChange { get; set; }
        public DOMEventHandler<IWindowEvent> OnMessage { get; set; }
        public DOMEventHandler<IWindowEvent> OnOffline { get; set; }
        public DOMEventHandler<IWindowEvent> OnOnline { get; set; }
        public DOMEventHandler<IWindowEvent> OnPageHide { get; set; }
        public DOMEventHandler<IWindowEvent> OnPageShow { get; set; }
        public DOMEventHandler<IWindowEvent> OnPopState { get; set; }
        public DOMEventHandler<IWindowEvent> OnResize { get; set; }
        public DOMEventHandler<IWindowEvent> OnStorage { get; set; }
        public DOMEventHandler<IWindowEvent> OnUnload { get; set; }
        
        public Document Document { get; set; }
        public Screen Screen { get; set; }

        public Window()
        {
            Screen = new Screen();
            Document = new Document();
        }

        public void Open(string uri, string windowName, string windowFeatures)
        {
            // TODO: Impl
        }
        
        
        public Selection GetSelection()
        {
            return new Selection();
        }
    }
}