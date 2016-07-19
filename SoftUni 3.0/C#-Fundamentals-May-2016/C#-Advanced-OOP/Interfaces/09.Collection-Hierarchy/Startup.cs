namespace _09.Collection_Hierarchy
{
    using System;
    using System.Text;

    using Models;

    class Startup
    {
        static void Main()
        {
            var elements = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var numberOfRemoves = int.Parse(Console.ReadLine());

            var addColectionsAdds = new StringBuilder();
            var addRemoveColectionsAdds = new StringBuilder();
            var myListAdds = new StringBuilder();
            var addRemoveColectionsRemoves = new StringBuilder();
            var myListRemoves = new StringBuilder();

            var addColection = new AddCollection();
            var addRemoveColectio = new AddRemoveCollection();
            var myListColection = new MyList();

            foreach (var element in elements)
            {
                addColectionsAdds.Append(addColection.Add(element) + " ");
                addRemoveColectionsAdds.Append(addRemoveColectio.Add(element) + " ");
                myListAdds.Append(myListColection.Add(element) + " ");
            }

            for (int i = 0; i < numberOfRemoves; i++)
            {
                addRemoveColectionsRemoves.Append(addRemoveColectio.Remove() + " ");
                myListRemoves.Append(myListColection.Remove() + " ");
            }

            Console.WriteLine(addColectionsAdds);
            Console.WriteLine(addRemoveColectionsAdds);
            Console.WriteLine(myListAdds);
            Console.WriteLine(addRemoveColectionsRemoves);
            Console.WriteLine(myListRemoves);
        }
    }
}
