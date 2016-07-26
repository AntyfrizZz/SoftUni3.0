namespace _01HarestingFields
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            var harvestingFields = typeof(HarvestingFields);
            var fields = harvestingFields
                .GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            List<FieldInfo> privateFields = new List<FieldInfo>();
            List<FieldInfo> protectedFields = new List<FieldInfo>();
            List<FieldInfo> publicFields = new List<FieldInfo>();

            foreach (var fieldInfo in fields)
            {
                if (fieldInfo.IsPrivate)
                {
                    privateFields.Add(fieldInfo);
                }
                else if (fieldInfo.IsFamily)
                {
                    protectedFields.Add(fieldInfo);
                }
                else if (fieldInfo.IsPublic)
                {
                    publicFields.Add(fieldInfo);
                }
                else
                {
                    throw new Exception("Fields other than private, protected or public!");
                }
            }

            var input = Console.ReadLine();

            while (!input.Equals("HARVEST"))
            {
                switch (input)
                {
                    case "private":
                        foreach (var privateField in privateFields)
                        {
                            Console.WriteLine($"private {privateField.FieldType.Name} {privateField.Name}");
                        }
                        break;
                    case "protected":
                        foreach (var protectedField in protectedFields)
                        {
                            Console.WriteLine($"protected {protectedField.FieldType.Name} {protectedField.Name}");
                        }
                        break;
                    case "public":
                        foreach (var publicField in publicFields)
                        {
                            Console.WriteLine($"public {publicField.FieldType.Name} {publicField.Name}");
                        }
                        break;
                    case "all":
                        foreach (var fieldInfo in fields)
                        {
                            var access = string.Empty;
                            if (fieldInfo.IsPrivate)
                            {
                                access += "private";
                            }
                            else if (fieldInfo.IsFamily)
                            {
                                access += "protected";
                            }
                            else if (fieldInfo.IsPublic)
                            {
                                access += "public";
                            }

                            Console.WriteLine($"{access} {fieldInfo.FieldType.Name} {fieldInfo.Name}");
                        }
                        break;
                }

                input = Console.ReadLine();
            }
        }
    }
}
