using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class Startup
{
    public static void Main()
    {
        var methodDeclarePattern = @"static\s+[\w<>\[\],]+\s+(\w*[A-Z]{1}\w*)";
        var methodInvokePattern = @"(\w*[A-Z]{1}\w*)\s*(?:\()";
        var inputLineCount = int.Parse(Console.ReadLine());
        var input = new StringBuilder();
        var methods = new Dictionary<string, List<string>>();
        for (var i = 0; i < inputLineCount; i++)
        {
            input.Append(Console.ReadLine());
        }

        var text = input.ToString();
        var declaredMethods = Regex.Matches(text, methodDeclarePattern);
        for (var i = 0; i < declaredMethods.Count; i++)
        {
            var method = declaredMethods[i].Groups[1].Value;
            methods.Add(method, new List<string>());
            string methodText;
            var startPos = text.IndexOf(declaredMethods[i].Groups[0].Value) +
                               declaredMethods[i].Groups[0].Value.Length;
            if (i < declaredMethods.Count - 1)
            {

                var length = text.IndexOf(declaredMethods[i + 1].Groups[0].Value) - startPos;
                methodText = text.Substring(startPos, length);
            }
            else
            {
                methodText = text.Substring(startPos);
            }
            var invokedMethods = Regex.Matches(methodText, methodInvokePattern);
            foreach (Match invokedMethod in invokedMethods)
            {
                methods[method].Add(invokedMethod.Groups[1].Value);
            }
        }

        var results = methods
            .OrderByDescending(m => m.Value.Count)
            .ThenBy(m => m.Key)
            .Select(
                m => new
                {
                    Name = m.Key,
                    InvokedMethodsCount = m.Value.Count,
                    InvokedMethods = string.Join(", ", m.Value.OrderBy(im => im))
                });

        foreach (var result in results)
        {
            if (result.InvokedMethodsCount > 0)
            {
                Console.WriteLine($"{result.Name} -> {result.InvokedMethodsCount} -> {result.InvokedMethods}");
            }
            else
            {
                Console.WriteLine($"{result.Name} -> None");
            }
        }
    }
}