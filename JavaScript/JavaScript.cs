namespace Global
{
    using System;
    using System.Reflection;
    public class JavaScript //: Global.IEasyScript
    {
        private readonly dynamic? _engine;
        static readonly Assembly? assembly = null;
        public static readonly Type myType;
        //public static readonly dynamic? instance = null;
        static JavaScript()
        {
            var thisAssembly = typeof(JavaScript).Assembly;
            assembly = Sys.LoadFromResource(thisAssembly, "Javascript:JavaScriptInternals.dll");
            myType = assembly!.GetType("Global.JavaScriptInternals")!;
        }
        public JavaScript(params Assembly[] assemblies)
        {
            _engine = Activator.CreateInstance(myType!, [assemblies])!;
        }
        public dynamic? Call(string name, params object[] vars)
        {
            return _engine!.Call(name, vars);
        }
        public dynamic? Evaluate(string script, params object[] vars)
        {
            return _engine!.Evaluate(script, vars);
        }
        public dynamic? EvaluateFile(string fileName, string script, params object[] vars)
        {
            return _engine!.EvaluateFile(fileName, script, vars);
        }

        public void Execute(string script, params object[] vars)
        {
            _engine!.Execute(script, vars);
        }

        public void ExecuteFile(string fileName, string script, params object[] vars)
        {
            _engine!.ExecuteFile(fileName, script, vars);
        }

        public dynamic? GetValue(string name)
        {
            return _engine!.GetValue(name);
        }

        public void SetValue(string name, dynamic? value)
        {
            _engine!.SetValue(name, value);
        }
    }
}

