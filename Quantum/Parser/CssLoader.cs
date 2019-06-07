using System;
using System.IO;
using Quantum.CSSOM;
using Quantum.Parser.CSS;

namespace Quantum.Parser
{
  public class CssLoader
  {
    private CssStateMachineProcessor _stateMachine;

    public CSSStyleSheet LoadSource(string source)
    {
      _stateMachine = new CssStateMachineProcessor(source);
      _stateMachine.Run();

      return _stateMachine.Instance.StyleSheet;
    }

    public CSSStyleSheet LoadFromFile(string file)
    {
      var source = ReadFromFile(file);

      return LoadSource(source);
    }

    private string ReadFromFile(string fileName)
    {
      var fileContent = default(string);

      using (var stream = new StreamReader(fileName))
      {
        fileContent = stream.ReadToEnd();
      }

      return fileContent;
    }
  }
}