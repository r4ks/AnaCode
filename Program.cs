using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static System.Console;

/// https://docs.microsoft.com/en-us/dotnet/csharp/roslyn-sdk/get-started/syntax-analysis
public class Program
{
    private static void Main(string[] args)
    {
        const string programText =
@"using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(""Hello, World!"");
        }
    }
}";

        // Console.WriteLine("Hello, World!");

        SyntaxTree tree = CSharpSyntaxTree.ParseText(programText);
        CompilationUnitSyntax root = tree.GetCompilationUnitRoot();

        WriteLine($"The tree is a {root.Kind()} node.");
        WriteLine($"The tree has {root.Members.Count} elements in it.");
        WriteLine($"The tree has {root.Usings.Count} using statements. They are:");
        foreach (UsingDirectiveSyntax element in root.Usings)
            WriteLine($"\t{element.Name}");
    }
}