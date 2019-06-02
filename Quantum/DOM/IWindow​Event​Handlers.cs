using Quantum.DOM.Events;

namespace Quantum.DOM
{
    public interface IWindowEvent
    {
    }

    public interface IWindowEventHandlers
    {
        DOMEventHandler<IWindowEvent> OnAfterPrint { get; set; }
        DOMEventHandler<IWindowEvent> OnBeforePrint { get; set; }
        DOMEventHandler<IWindowEvent> OnBeforeUnload { get; set; }
        DOMEventHandler<IWindowEvent> OnHashChenge { get; set; }
        DOMEventHandler<IWindowEvent> OnLanguageChange { get; set; }
        DOMEventHandler<IWindowEvent> OnMessage { get; set; }
        DOMEventHandler<IWindowEvent> OnOffline { get; set; }
        DOMEventHandler<IWindowEvent> OnOnline { get; set; }
        DOMEventHandler<IWindowEvent> OnPageHide { get; set; }
        DOMEventHandler<IWindowEvent> OnPageShow { get; set; }
        DOMEventHandler<IWindowEvent> OnPopState { get; set; }
        DOMEventHandler<IWindowEvent> OnResize { get; set; }
        DOMEventHandler<IWindowEvent> OnStorage { get; set; }
        DOMEventHandler<IWindowEvent> OnUnload { get; set; }
    }
}