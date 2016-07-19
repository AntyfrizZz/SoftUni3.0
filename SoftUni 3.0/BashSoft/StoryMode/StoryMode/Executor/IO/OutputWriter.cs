﻿namespace Executor.IO
{
    using System;
    using System.Collections.Generic;

    public static class OutputWriter
    {
        public static void WriteMessage(string message)
        {
            Console.Write(message);
        }

        public static void WriteMessageOnNewLine(string message)
        {
            Console.WriteLine(message);
        }

        public static void WriteEmptyLine()
        {
            Console.WriteLine();
        }

        public static void DisplayException(string message)
        {
            ConsoleColor currentColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = currentColor;
        }

        [Obsolete(@"This method doesn't belong in the OutputWriter. Use WriteMessageOnNewLine(String message) with String.Format() and methods from the Student class instead.")]
        public static void PrintStudent(KeyValuePair<string, double> student)
        {
            WriteMessageOnNewLine($"{student.Key} - {student.Value}");
        }
    }
}