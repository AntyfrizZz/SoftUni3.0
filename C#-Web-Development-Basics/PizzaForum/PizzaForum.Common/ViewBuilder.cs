namespace PizzaForum.Common
{
    using System.IO;
    using System.Text;

    public static class ViewBuilder
    {
        public static string CreateView(params string[] parts)
        {
            var result = new StringBuilder();

            foreach (var part in parts)
            {
                result.Append(part);
            }

            return result.ToString();
        }

        public static string ReadFile(string fileName)
        {
            return File.ReadAllText(GlobalConstants.ContentPath + fileName + GlobalConstants.HTML);
        }
    }
}
