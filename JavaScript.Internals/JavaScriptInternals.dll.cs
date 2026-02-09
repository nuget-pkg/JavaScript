//css_nuget EasyScript
namespace Global;

public class JavaScriptInternals : Global.IEasyScript
{
    private readonly EasyScript _engine;
    public JavaScriptInternals()
    {
        _engine = new EasyScript(
            assemblies: [ typeof(JavaScriptInternals).Assembly ],
            debug: true
            );
    }
    public dynamic? Call(string name, params object[] vars)
    {
        return _engine.Call(name, vars);
    }
    public dynamic? Evaluate(string script, params object[] vars)
    {
        return _engine.Evaluate(script, vars);
    }

    public dynamic? EvaluateFile(string fileName, string script, params object[] vars)
    {
        throw new System.NotImplementedException();
    }

    public void Execute(string script, params object[] vars)
    {
        _engine.Execute(script, vars);
    }

    public void ExecuteFile(string fileName, string script, params object[] vars)
    {
        throw new System.NotImplementedException();
    }

    public dynamic? GetValue(string name)
    {
        return _engine.GetValue(name);
    }
    public void SetValue(string name, dynamic? value)
    {
        _engine.SetValue(name, value);
    }
}
