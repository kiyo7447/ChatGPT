using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Microsoft.VisualStudio.TextTemplating;

public class CustomTextTemplatingEngineHost : ITextTemplatingEngineHost
{
    private readonly Dictionary<string, string> _assemblyReferences = new();
    private readonly string _templateFilePath;

    public CustomTextTemplatingEngineHost(string templateFilePath)
    {
        _templateFilePath = templateFilePath;
        _assemblyReferences.Add(typeof(Uri).Assembly.Location, "System");
    }

    public string TemplateFile => _templateFilePath;

    public IList<string> StandardAssemblyReferences => new[]
    {
        typeof(Uri).Assembly.Location
    };

    public IList<string> StandardImports => new[]
    {
        "System"
    };

    public object GetHostOption(string optionName)
    {
        return null;
    }

    public bool LoadIncludeText(string requestFileName, out string content, out string location)
    {
        content = string.Empty;
        location = string.Empty;
        return false;
    }

    public void LogErrors(CompilerErrorCollection errors)
    {
        throw new NotImplementedException();
    }

    public AppDomain ProvideTemplatingAppDomain(string content)
    {
        return AppDomain.CurrentDomain;
    }

    public string ResolveAssemblyReference(string assemblyReference)
    {
        if (_assemblyReferences.TryGetValue(assemblyReference, out var resolvedReference))
        {
            return resolvedReference;
        }

        return string.Empty;
    }

    public Type ResolveDirectiveProcessor(string processorName)
    {
        throw new NotImplementedException();
    }

    public string ResolveParameterValue(string directiveId, string processorName, string parameterName)
    {
        return null;
    }

    public string ResolvePath(string path)
    {
        return path;
    }

    public void SetFileExtension(string extension)
    {
        throw new NotImplementedException();
    }

    public void SetOutputEncoding(Encoding encoding, bool fromOutputDirective)
    {
        throw new NotImplementedException();
    }
}
