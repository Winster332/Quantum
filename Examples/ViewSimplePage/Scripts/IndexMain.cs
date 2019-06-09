using Quantum.CSSOM.Common;
using Quantum.HTML;
using Quantum.HTML.Elements;

namespace ViewSimplePage.Contents.Scripts
{
    public class IndexMain : Script, IScriptable
    {
      public void Start()
      {
        var canvas = Document.GetElementById("view") as HTMLCanvasElement;
        var ctx = canvas.GetContext2d();
        
        ctx.FillStyle = new CSSColor(255, 0, 0);
        ctx.FillRect(10, 10, 50, 50);
        
        ctx.FillStyle = new CSSColor(0, 0, 255, 125);
        ctx.FillRect(30, 30, 50, 50);
      }
    }
}