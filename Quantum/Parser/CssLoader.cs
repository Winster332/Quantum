using System;
using System.IO;
using Quantum.Parser.CSS;

namespace Quantum.Parser
{
  public class CssLoader
  {
    private CssStateMachineProcessor _stateMachine;

    public void LoadSource(string source)
    {
      _stateMachine = new CssStateMachineProcessor(source);
      _stateMachine.Run();
      
      Console.WriteLine("Hello");
    }

    public void LoadFromFile(string file)
    {
      var source = ReadFromFile(file);

      LoadSource(source);
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