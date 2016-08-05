namespace Executor.IO.Commands
{
    using System.Text;
    using Attributes;
    using Exceptions;

    [Alias("help")]
    public class GetHelpCommand : Command
    {
        public GetHelpCommand(string input, string[] data)
            : base(input, data)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length != 1)
            {
                throw new InvalidCommandException(this.Input);
            }

            this.DisplayHelp();
        }

        private void DisplayHelp()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"{new string('_', 100)}");
            stringBuilder.AppendLine($"|{"make directory - mkdir nameOfFolder",-98}|");
            stringBuilder.AppendLine($"|{"traverse directory - ls depth",-98}|");
            stringBuilder.AppendLine($"|{"comparing files - cmp absolutePath1 absolutePath2",-98}|");
            stringBuilder.AppendLine($"|{"change directory - cdRel relativePath or \"..\" for level up",-98}|");
            stringBuilder.AppendLine($"|{"change directory - cdAbs absolutePath",-98}|");
            stringBuilder.AppendLine($"|{"read students data base - readDb fileName",-98}|");
            stringBuilder.AppendLine(
                $"|{"filter {courseName} excelent/average/poor  take 2/5/all students - filterExcelent (the output is written on the console)",-98}|");
            stringBuilder.AppendLine(
                $"|{"order increasing students - order {courseName} ascending/descending take 20/10/all (the output is written on the console)",-98}|");
            stringBuilder.AppendLine($"|{"download file - download URL (saved in current directory)",-98}|");
            stringBuilder.AppendLine(
                $"|{"download file asinchronously - downloadAsynch URL (saved in the current directory)",-98}|");
            stringBuilder.AppendLine($"|{"get help – help",-98}|");
            stringBuilder.AppendLine($"|{"display data entities - display students/courses ascending/descending",-98}");
            stringBuilder.AppendLine($"{new string('_', 100)}");
            stringBuilder.AppendLine();
            OutputWriter.WriteMessageOnNewLine(stringBuilder.ToString());
        }
    }
}