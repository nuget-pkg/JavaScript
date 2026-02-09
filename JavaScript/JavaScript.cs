using Acornima.Ast;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Xml.Linq;

// ReSharper disable once CheckNamespace
namespace Global;

// ReSharper disable once InconsistentNaming
public class JavaScript //: Global.IEasyScript
{
    private readonly JavaScriptInternals? _engine;
    public JavaScript(params Assembly[] assemblies)
    {
        _engine = new JavaScriptInternals(assemblies);
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
