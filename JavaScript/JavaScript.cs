namespace Global
{
    using System;
    using System.Reflection;
    public class JavaScript //: Global.IEasyScript
    {
        private static readonly Assembly? assembly = null;
        private static readonly Type engineType;
        private readonly dynamic? engine;
        static JavaScript()
        {
            var thisAssembly = typeof(JavaScript).Assembly;
            assembly = Sys.LoadFromResource(thisAssembly, "JavaScript:JavaScriptInternals.dll");
            engineType = assembly!.GetType("Global.JavaScriptInternals")!;
        }
        public JavaScript(params Assembly[] assemblies)
        {
            //assemblies ??= new Assembly[0];
            engine = Activator.CreateInstance(engineType!, [assemblies])!;
        }
        public dynamic? Call(string name, params object[] vars)
        {
            return engine!.Call(name, vars);
        }
        public dynamic? Evaluate(string script, params object[] vars)
        {
            return engine!.Evaluate(script, vars);
        }
        public dynamic? EvaluateFile(string fileName, string script, params object[] vars)
        {
            return engine!.EvaluateFile(fileName, script, vars);
        }

        public void Execute(string script, params object[] vars)
        {
            engine!.Execute(script, vars);
        }

        public void ExecuteFile(string fileName, string script, params object[] vars)
        {
            engine!.ExecuteFile(fileName, script, vars);
        }

        public dynamic? GetValue(string name)
        {
            return engine!.GetValue(name);
        }

        public void SetValue(string name, dynamic? value)
        {
            engine!.SetValue(name, value);
        }
    }
}

