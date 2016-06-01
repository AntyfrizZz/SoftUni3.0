
namespace BashSoft
{
    class Startup
    {
        static void Main()
        {
            //Data.InitializeData();
            //Data.GetAllStudentsFromCourse("Unity");
            //Data.GetStudentScoresFromCourse("Unity", "Ivan");

            //IOManager.TraverseDirectory(1);
            //Tester.CompareContent(@"D:\SoftUni\Courses\AdvancedCSharp\May 2016\BashSoft\BashSoft\Resourses\test2.txt", @"D:\SoftUni\Courses\AdvancedCSharp\May 2016\BashSoft\BashSoft\Resourses\test3.txt");
            //IOManager.CreateDirectoryInCurrentFolder("pesho");

            IOManager.ChangeCurrentDirectoryAbsolute(@"D:\MoviezZz");
            IOManager.TraverseDirectory(2);


        }        
    }
}
