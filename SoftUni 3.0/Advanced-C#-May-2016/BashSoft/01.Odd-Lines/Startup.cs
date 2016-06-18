using BashSoft;
using System.IO;

class Startup
{
    static void Main()
    {
        string outputPath = @"D:\SoftUni\Courses\AdvancedCSharp\May 2016\BashSoft\BashSoft\Resourses\OddLinesOutput\MyOutput.txt";
        string inputPath = @"D:\SoftUni\Courses\AdvancedCSharp\May 2016\BashSoft\BashSoft\Resourses\FilesAndDirectoriesTests\02_OddLines\03_OddLinesIn.txt";
        string expectedOutputPath = @"D:\SoftUni\Courses\AdvancedCSharp\May 2016\BashSoft\BashSoft\Resourses\FilesAndDirectoriesTests\02_OddLines\03_OddLinesOut.txt";

        var reader = File.OpenText(inputPath);
        var writer = File.AppendText(outputPath);


        using (reader)
        {
            using (writer)
            {
                string line = reader.ReadLine();
                int counter = 0;

                while (line != null)
                {
                    if (counter % 2 != 0)
                    {
                        writer.WriteLine(line);
                    }

                    counter++;

                    line = reader.ReadLine();
                }
            }

            Tester.CompareContent(outputPath, expectedOutputPath);
            File.Delete(outputPath);
        }


    }
}
