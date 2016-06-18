using BashSoft;
using System;
using System.IO;

namespace _04.Merging_two_files_into_third_one
{
    class Startup
    {
        static void Main(string[] args)
        {
            string outputPath = @"D:\SoftUni\Courses\AdvancedCSharp\May 2016\BashSoft\BashSoft\Resourses\MergeOutput\MyOutput.txt";
            string expectedOutputPath = @"D:\SoftUni\Courses\AdvancedCSharp\May 2016\BashSoft\BashSoft\Resourses\FilesAndDirectoriesTests\05_MergingFiles\01_Merged.txt";

            string firstFile = @"D:\SoftUni\Courses\AdvancedCSharp\May 2016\BashSoft\BashSoft\Resourses\FilesAndDirectoriesTests\05_MergingFiles\01_FileOne.txt";
            string SecondFile = @"D:\SoftUni\Courses\AdvancedCSharp\May 2016\BashSoft\BashSoft\Resourses\FilesAndDirectoriesTests\05_MergingFiles\01_FileTwo.txt";


            var firstFileLines = File.ReadAllLines(firstFile);
            var secondFileLines = File.ReadAllLines(SecondFile);

            int minCount;

            if (firstFileLines.Length < secondFileLines.Length)
            {
                minCount = firstFileLines.Length;
            }
            else
            {
                minCount = secondFileLines.Length;
            }

            using (var writer = File.AppendText(outputPath))
            {
                for (int i = 0; i < minCount; i++)
                {
                    writer.WriteLine(firstFileLines[i]);
                    writer.WriteLine(secondFileLines[i]);
                }

                if (firstFileLines.Length < secondFileLines.Length)
                {
                    for (int i = minCount; i < secondFileLines.Length; i++)
                    {
                        writer.WriteLine(secondFileLines[i]);
                    }
                }
                if (secondFileLines.Length < firstFileLines.Length)
                {
                    for (int i = minCount; i < firstFileLines.Length; i++)
                    {
                        writer.WriteLine(firstFileLines[i]);
                    }
                }
            }

            Tester.CompareContent(outputPath, expectedOutputPath);
            File.Delete(outputPath);
        }
    }
}
