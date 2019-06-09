using System;
using System.CodeDom.Compiler;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.CSharp;
using SkiaSharp;

namespace Quantum.HTML.Elements
{
    [HtmlName("script")]
    public class HTMLScriptElement : HTMLElement
    {
        public string Type { get; set; }
        public string Src => GetAttribute("src")?.Value.Replace("\"", "");
        public string Charset { get; set; }
        public bool Async { get; set; }
        public bool Defer { get; set; }

        public string Text
        {
            get
            {
                if (FirstChild != null && FirstChild is HTMLTextElement script)
                {
                    var sourceScript = script.TextContent;

                    return sourceScript;
                }

                return "";
            }
        }
        public bool NoModule { get; set; }
        public string ReferrerPolicy { get; set; }
        public HTMLScriptElement()
        {
            Init("SCRIPT");
        }

        internal override void Load()
        {
            if (Text.Length != 0)
            {
                var sourceScript = Text;
                var codeBody = new StringBuilder();
                codeBody.AppendLine("using System;");
                codeBody.AppendLine("namespace DynaCore");
                codeBody.AppendLine("{");
                codeBody.AppendLine("public class DynaCore");
                codeBody.AppendLine("{");
                codeBody.AppendLine("static public int Main(string str)");
                codeBody.AppendLine("{");
                codeBody.AppendLine(sourceScript);
                codeBody.AppendLine("}");
                codeBody.AppendLine("}");
                codeBody.AppendLine("}");

                var code = codeBody.ToString();
                
                throw new PlatformNotSupportedException("Dynamic compilation not support on current platfrom");
                
                CompileCode(code);
                return;
            }
            
            ApplyFromFile();
        }

        private void CompileCode(string code)
        {
            CompilerParameters CompilerParams = new CompilerParameters();
            string outputDirectory = Directory.GetCurrentDirectory();
 
            CompilerParams.GenerateInMemory = true;
            CompilerParams.TreatWarningsAsErrors = false;
            CompilerParams.GenerateExecutable = false;
            CompilerParams.CompilerOptions = "/optimize";
 
            string[] references = { "System.dll" };
            CompilerParams.ReferencedAssemblies.AddRange(references);
 
            CSharpCodeProvider provider = new CSharpCodeProvider();
            CompilerResults compile = provider.CompileAssemblyFromSource(CompilerParams, code);
 
            if (compile.Errors.HasErrors)
            {
                string text = "Compile error: ";
                foreach (CompilerError ce in compile.Errors)
                {
                    text += "rn" + ce.ToString();
                }
                throw new Exception(text);
            }
 
            //ExpoloreAssembly(compile.CompiledAssembly);
 
            Module module = compile.CompiledAssembly.GetModules()[0];
            Type mt = null;
            MethodInfo methInfo = null;
 
            if (module != null)
            {
                mt = module.GetType("DynaCore.DynaCore");
            }
 
            if (mt != null)
            {
                methInfo = mt.GetMethod("Main");
            }
 
            if (methInfo != null)
            {
                Console.WriteLine(methInfo.Invoke(null, new object[] { "here in dyna code" }));
            }
        }

//        private void ExpoloreAssembly(Assembly assembly)
//        {
//            Console.WriteLine("Modules in the assembly:");
//            
//            foreach (Module m in assembly.GetModules())
//            {
//                Console.WriteLine(m);
//
//                foreach (Type t in m.GetTypes())
//                {
//                    Console.WriteLine($"t{t.Name}");
//
//                    foreach (MethodInfo mi in t.GetMethods())
//                    {
//                        Console.WriteLine($"tt{mi.Name}");
//                    }
//                }
//            }
//        }

        private void ApplyFromFile()
        {
            var src = Src;

            if (src != null)
            {
                var assemblies = AppDomain.CurrentDomain.GetAssemblies();
                var type = default(Type);

                foreach (var assembly in assemblies)
                {
                    var types = assembly.GetTypes().Where(x => x.GetInterfaces().Contains(typeof(IScriptable)))
                        .ToList();

                    if (types.Count != 0)
                    {
                        Assembly.Load(assembly.FullName);
                    }

                    foreach (var typeFromAssembly in types)
                    {
                        if (typeFromAssembly.FullName == src)
                        {
                            type = typeFromAssembly;
                            break;
                        }
                    }

                    if (type != null)
                    {
                        break;
                    }
                }

                if (type == null) return;

                var instanceScript = Activator.CreateInstance(type) as IScriptable;

                if (instanceScript == null) return;

                OwnerDocument.Scripts.Add(this);
                instanceScript.Start();
            }
        }

        internal override bool Draw(SKCanvas canvas)
        {
          return false;
        }
    }
}