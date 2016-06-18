
namespace BashSoft
{
    public static class ExceptionMessages
    {
        public const string ExampleExceptionMessage = "Example message!";
        public const string DataAlreadyInitialisedException = "Data is already initialized!";
        public const string DataNotInitializedExceptionMessage = "The data structure must be initialised first in order to make any operations with it!";
        public const string InexistingCourseInDataBase = "The course you are trying to get does not exist in the data base!";
        public const string InexistingStudentInDataBase = "The user name for the student you are trying to get does not exist!";
        public const string InvalidPath = "The folder/file you are trying to acces at the current address, does not exist!";

        public const string UnautorizedAccessExceptionMessage = "The folder/file you are trying to get access needs a higher level of rights than you currently have!";
        public const string ComparisonOfFilesWithDifferentSizes = "Files not of equal size, certain mismatch!";
        public static string ForbiddenSymbolContainedInName = "Forbiden symbol contained in name!";
        public static string UnableToGoHigherInPartitionHierarchy = "Unable to go higher in partition hierarchy!";
        public static string UnableToParseNumber = "The sequence you've written is not a valid number!";

        public static string InvalidStudentsFilter =
            "The given filter is not one of the following: excellent/average/poor";

        public static string InvalidComparisonQuery =
            "The comparison query you want, does not exist in the context of the current program!";

        public static string InvalidTakeCommand = "The take command expected does not match the format wanted!";
        public static string InvalidTakeQuantityParameter = "The take command expected does not match the format wanted!";
        public static string InvalidCommandMessage = "Invalid command message";
    }
}
