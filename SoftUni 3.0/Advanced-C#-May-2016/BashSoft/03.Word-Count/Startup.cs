using BashSoft;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace WordCount
{
    class Startup
    {
        static void Main()
        {
            string outputPath = @"D:\SoftUni\Courses\AdvancedCSharp\May 2016\BashSoft\BashSoft\Resourses\WordCountOutput\MyOutput.txt";
            string expectedOutputPath = @"D:\SoftUni\Courses\AdvancedCSharp\May 2016\BashSoft\BashSoft\Resourses\FilesAndDirectoriesTests\04_WordCount\02_WordCountOut.txt";

            string wordsPath = @"D:\SoftUni\Courses\AdvancedCSharp\May 2016\BashSoft\BashSoft\Resourses\FilesAndDirectoriesTests\04_WordCount\words2.txt";
            string inputPath = @"D:\SoftUni\Courses\AdvancedCSharp\May 2016\BashSoft\BashSoft\Resourses\FilesAndDirectoriesTests\04_WordCount\text2.txt";


            var words = File.ReadAllText(wordsPath)
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var input = File.ReadAllText(inputPath);

            var result = new Dictionary<string, int>();

            for (int i = 0; i < words.Length; i++)
            {
                MatchCollection wordCount = Regex.Matches(input, words[i]);

                result.Add(words[i], wordCount.Count);
            }

            using (var writer = File.AppendText(outputPath))
            {
                foreach (var kvp in result)
                {
                    writer.WriteLine("{0} - {1}", kvp.Key, kvp.Value);
                }
            }

            Tester.CompareContent(outputPath, expectedOutputPath);
            //File.Delete(outputPath);
        }
    }
}
