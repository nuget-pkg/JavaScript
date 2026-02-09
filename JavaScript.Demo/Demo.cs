using Global;
using System;
using static Global.EasyObject;

namespace EasyScript.Demo;

public class Program
{
    public static int Add2(int a, int b)
    { return a + b; }
    public static void Main(string[] args)
    {
        Log(args, "args");
        //ShowDetail = true;
        var ts = new Global.JavaScript();
        ts.ExecuteFile("test.ts", """
                   var a = 123.4;
                   console.log("Hello from TypeScript", a);

                   """);
        var engine = new Global.EasyScript(transform: true, assemblies: [typeof(Program).Assembly])
        {
            Debug = true
        };
        engine.SetValue("x", 222);
        var result = EasyObject.FromObject(engine.EvaluateFile(
            "my-file.js",
            """
            class Person {
                name;
                age;
            
                constructor(name, age) {
                    this.name = name;
                    this.age = age;
                }
            
                greet() {
                    console.log("Hello");
                }
            }
            function add2(a, b) { return a + b; }
            var answer = add2($1, x);
            $echo(answer, "answer");
            $log(answer, "answer");
            answer;

            """, 111));

        Echo(result.IsNumber);
        Echo(result);
        engine.Execute("""
            var EasyScript = $namespace("EasyScript");
            var result = EasyScript.Demo.Program.Add2(1111, 2222); 
            $echo(result, "result");

            """);
        Echo(engine.GetValue("result"));
        try
        {
            engine.Execute("""
                console.log("aaa", "bbb");
                throw new Error("my-error");
                """);
        }
        catch (Exception e)
        {
            Console.Error.WriteLine($"Unhandled Exception({EasyObject.FullName(e)}): {e.Message}");
            Console.Error.WriteLine(e.StackTrace);
        }
    }
}
