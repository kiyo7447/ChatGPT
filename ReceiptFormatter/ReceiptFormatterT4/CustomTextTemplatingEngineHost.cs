using System;
using System.IO;
using Mono.TextTemplating;

public class CustomTextTemplatingEngineHost : TemplateGenerator
{
    private readonly string _templateFilePath;

    public CustomTextTemplatingEngineHost(string templateFilePath)
    {
        _templateFilePath = templateFilePath;
        //ReferenceAssemblies.Add(typeof(Uri).Assembly.GetName());
        //Assemblies.Add(typeof(Uri).Assembly.Location);
    }

    public string TemplateFile => _templateFilePath;

    protected override string ResolvePath(string path)
    {
        return path;
    }
}
