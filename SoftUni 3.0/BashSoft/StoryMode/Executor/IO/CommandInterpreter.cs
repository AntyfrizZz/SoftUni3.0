using System;
using System.Diagnostics;
using System.Text;
using Executor.Network;

namespace Executor
{
    public static class CommandInterpreter
    {
        public static void InterpredCommand(string input)
        {
            string[] data = input.Split(' ');
            string command = data[0];
            command = command.ToLower();
            switch (command)
            {
                case "show":
                    TryShowWantedData(input, data);
                    break;
                case "open":
                    TryOpenFile(input, data);
                    break;
                case "mkdir":
                    TryCreateDirectory(input, data);
                    break;
                case "ls":
                    TryTraverseFolders(input, data);
                    break;
                case "cmp":
                    TryCompareFiles(input, data);
                    break;
                case "cdrel":
                    TryChangePathRelatively(input, data);
                    break;
                case "cdabs":
                    TryChangePathAbsolute(input, data);
                    break;
                case "readdb":
                    TryReadDatabaseFromFile(input, data);
                    break;
                case "help":
                    TryGetHelp(input, data);
                    break;
                case "filter":
                    TryFilterAndTake(input, data);
                    break;
                case "order":
                    TryOrderAndTake(input, data);
                    break;
                case "download":
                    TryDownloadRequestedFile(input, data);
                    break;
                case "downloadasynch":
                    TryDownloadRequestedFileAsync(input, data);
                    break;
                default:
                    DisplayInvalidCommandMessage(input);
                    break;
            }
        }

        private static void TryDownloadRequestedFileAsync(string input, string[] data)
        {
            if (data.Length == 2)
            {
                string url = data[1];
                DownloadManager.DownloadAsync(url);
            }
            else
            {
                DisplayInvalidCommandMessage(input);
            }
        }

        private static void TryDownloadRequestedFile(string input, string[] data)
        {
            if (data.Length == 2)
            {
                string url = data[1];
                DownloadManager.Download(url);
            }
            else
            {
                DisplayInvalidCommandMessage(input);
            }
        }

        private static void TryShowWantedData(string input, string[] data)
        {
            if (data.Length == 2)
            {
                string courseName = data[1];
                StudentsRepository.GetAllStudentsFromCourse(courseName);
            }
            else if (data.Length == 3)
            {
                string courseName = data[1];
                string userName = data[2];
                StudentsRepository.GetStudentScoresFromCourse(courseName, userName);
            }
            else
            {
                DisplayInvalidCommandMessage(input);
            }
        }

        private static void TryFilterAndTake(string input, string[] data)
        {
            if (data.Length == 5)
            {
                string courseName = data[1];
                string filter = data[2].ToLower();
                string takeCommand = data[3].ToLower();
                string takeQuantity = data[4].ToLower();

                TryParseParametersForFilterAndTake(takeCommand, takeQuantity, courseName, filter);
            }
            else
            {
                DisplayInvalidCommandMessage(input);
            }
        }

        private static void TryParseParametersForFilterAndTake(
            string takeCommand, string takeQuantity, string courseName, string filter)
        {
            if (takeCommand == "take")
            {
                if (takeQuantity == "all")
                {
                    StudentsRepository.FilterAndTake(courseName, filter);
                }
                else
                {
                    int studentsToTake;
                    bool hasParsed = int.TryParse(takeQuantity, out studentsToTake);
                    if (hasParsed)
                    {
                        StudentsRepository.FilterAndTake(courseName, filter, studentsToTake);
                    }
                    else
                    {
                        OutputWriter.DisplayException(ExceptionMessages.InvalidTakeQuantityParameter);
                    }
                }
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidTakeCommand);
            }
        }

        private static void TryOrderAndTake(string input, string[] data)
        {
            if (data.Length == 5)
            {
                string courseName = data[1];
                string orderType = data[2].ToLower();
                string takeCommand = data[3].ToLower();
                string takeQuantity = data[4].ToLower();

                TryParseParametersForOrderAndTake(takeCommand, takeQuantity, courseName, orderType);
            }
            else
            {
                DisplayInvalidCommandMessage(input);
            }
        }

        private static void TryParseParametersForOrderAndTake(string takeCommand, string takeQuantity, string courseName, string orderType)
        {
            if (takeCommand == "take")
            {
                if (takeQuantity == "all")
                {
                    StudentsRepository.OrderAndTake(courseName, orderType);
                }
                else
                {
                    int studentsToTake;
                    bool hasParsed = int.TryParse(takeQuantity, out studentsToTake);
                    if (hasParsed)
                    {
                        StudentsRepository.OrderAndTake(courseName, orderType, studentsToTake);
                    }
                    else
                    {
                        OutputWriter.DisplayException(ExceptionMessages.InvalidTakeQuantityParameter);
                    }
                }
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidTakeCommand);
            }
        }

        private static void TryOpenFile(string input, string[] data)
        {
            if (data.Length == 2)
            {
                string fileName = data[1];
                Process.Start(SessionData.currentPath + "\\" + fileName);
            }
            else
            {
                DisplayInvalidCommandMessage(input);
            }
        }

        private static void TryCompareFiles(string input, string[] data)
        {
            if (data.Length == 3)
            {
                string firstPath = data[1];
                string secondPath = data[2];

                Tester.CompareContent(firstPath, secondPath);
            }
            else
            {
                DisplayInvalidCommandMessage(input);
            }
        }

        private static void TryGetHelp(string input, string[] data)
        {
            if (data.Length == 1)
            {
                DisplayHelp();
            }
            else
            {
                DisplayInvalidCommandMessage(input);
            }
        }

        private static void TryReadDatabaseFromFile(string input, string[] data)
        {
            if (data.Length == 2)
            {
                string fileName = data[1];
                StudentsRepository.InitializeData(fileName);
            }
            else
            {
                DisplayInvalidCommandMessage(input);
            }
        }

        private static void TryChangePathAbsolute(string input, string[] data)
        {
            if (data.Length == 2)
            {
                string absolutePath = data[1];
                IOManager.ChangeCurrentDirectoryAbsolute(absolutePath);
            }
            else
            {
                DisplayInvalidCommandMessage(input);
            }
        }

        private static void TryChangePathRelatively(string input, string[] data)
        {
            if (data.Length == 2)
            {
                string relPath = data[1];
                IOManager.ChangeCurrentDirectoryRelative(relPath);
            }
            else
            {
                DisplayInvalidCommandMessage(input);
            }
        }

        private static void TryTraverseFolders(string input, string[] data)
        {
            if (data.Length == 1)
            {
                IOManager.TraverseDirectory(0);
            }
            else if (data.Length == 2)
            {
                int depth;
                bool hasParsed = int.TryParse(data[1], out depth);
                if (hasParsed)
                {
                    IOManager.TraverseDirectory(depth);
                }
                else
                {
                    DisplayInvalidCommandMessage(input);
                }
            }
            else
            {
                DisplayInvalidCommandMessage(input);
            }
        }

        private static void TryCreateDirectory(string input, string[] data)
        {
            if (data.Length == 2)
            {
                string folderName = data[1];
                IOManager.CreateDirectoryInCurrentFolder(folderName);
            }
            else
            {
                DisplayInvalidCommandMessage(input);
            }
        }

        public static void DisplayInvalidCommandMessage(string input)
        {
            OutputWriter.DisplayException($"The command '{input}' is invalid");
        }

        public static void DisplayHelp()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"{new string('_', 100)}");
            stringBuilder.AppendLine(string.Format("|{0, -98}|", "make directory - mkdir nameOfFolder"));
            stringBuilder.AppendLine(string.Format("|{0, -98}|", "traverse directory - ls depth"));
            stringBuilder.AppendLine(string.Format("|{0, -98}|", "comparing files - cmp absolutePath1 absolutePath2"));
            stringBuilder.AppendLine(string.Format("|{0, -98}|", "change directory - cdRel relativePath or \"..\" for level up"));
            stringBuilder.AppendLine(string.Format("|{0, -98}|", "change directory - cdAbs absolutePath"));
            stringBuilder.AppendLine(string.Format("|{0, -98}|", "read students data base - readDb fileName"));
            stringBuilder.AppendLine(string.Format("|{0, -98}|", "filter {courseName} excelent/average/poor  take 2/5/all students - filterExcelent (the output is written on the console)"));
            stringBuilder.AppendLine(string.Format("|{0, -98}|", "order increasing students - order {courseName} ascending/descending take 20/10/all (the output is written on the console)"));
            stringBuilder.AppendLine(string.Format("|{0, -98}|", "download file - download URL (saved in current directory)"));
            stringBuilder.AppendLine(string.Format("|{0, -98}|", "download file asinchronously - downloadAsynch URL (saved in the current directory)"));
            stringBuilder.AppendLine(string.Format("|{0, -98}|", "get help – help"));
            stringBuilder.AppendLine($"{new string('_', 100)}");
            stringBuilder.AppendLine();
            OutputWriter.WriteMessageOnNewLine(stringBuilder.ToString());
        }
    }
}
