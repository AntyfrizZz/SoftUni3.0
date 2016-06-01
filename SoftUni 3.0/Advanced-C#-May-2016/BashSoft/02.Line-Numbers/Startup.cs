using BashSoft;
using System.IO;

namespace _02.Line_Numbers
{
    class Startup
    {
        static void Main()
        {           

            string outputPath = @"D:\SoftUni\Courses\AdvancedCSharp\May 2016\BashSoft\BashSoft\Resourses\LinesNumbersOutput\MyOutput.txt";
            string inputPath = @"D:\SoftUni\Courses\AdvancedCSharp\May 2016\BashSoft\BashSoft\Resourses\FilesAndDirectoriesTests\03_LineNumbers\01_LinesIn.txt";
            string expectedOutputPath = @"D:\SoftUni\Courses\AdvancedCSharp\May 2016\BashSoft\BashSoft\Resourses\FilesAndDirectoriesTests\03_LineNumbers\01_LinesOut.txt";

            var input = File.ReadAllLines(inputPath);

            using (var writer = File.AppendText(outputPath))
            {
                for (int line = 0; line < input.Length; line++)
                {
                    writer.WriteLine("{0}. {1}", line + 1, input[line]);
                }
            }

            Tester.CompareContent(outputPath, expectedOutputPath);
            File.Delete(outputPath);
        }
    }
}
