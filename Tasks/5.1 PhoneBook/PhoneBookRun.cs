using System;
using System.Linq;

namespace Tasks
{
    class PhoneBookRun
    {
        static void Main(string[] args)
        {
            var requestsCount = int.Parse(Console.ReadLine());

            var sut = new PhoneBook();

            for (int i = 0; i < requestsCount; i++)
            {
                var command = Console.ReadLine().Split(' ').ToArray();

                switch(command[0])
                {
                    case "add":
                        //sut.Add(new PhoneBookOnLists.Contact(command[1],command[2]));
                        sut.Add(command[1], command[2]);
                        break;
                    case "find":
                        Console.WriteLine(sut.Find(command[1]));
                        break;
                    case "del":
                        sut.Delete(command[1]);
                        break;
                }
            }

            Console.ReadKey();
        }
    }
}
