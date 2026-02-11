using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace re
{
    public class Tsk
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }
    }

    public class Program
    {
        static List<Tsk> tsks = new List<Tsk>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("==== Tsk Manager ====");
                Console.WriteLine("1. View Tsks");
                Console.WriteLine("2. Add Tsk");
                Console.WriteLine("3. Update Tsk");
                Console.WriteLine("4. Delete Tsk");
                Console.WriteLine("5. Mark Tsk as Completed");
                Console.WriteLine("6. Exit");
                Console.WriteLine("======================");
                Console.Write("Enter your choice (1-6): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ViewTsks();
                        break;
                    case "2":
                        AddTsk();
                        break;
                    case "3":
                        UpdateTsk();
                        break;
                    case "4":
                        DeleteTsk();
                        break;
                    case "5":
                        MarkTskAsCompleted();
                        break;
                    case "6":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        static void ViewTsks()
        {
            Console.Clear();
            Console.WriteLine("==== View Tsks ====");

            if (tsks.Count == 0)
            {
                Console.WriteLine("No tsks found.");
                return;
            }

            for (int i = 0; i < tsks.Count; i++)
            {
                var tsk = tsks[i];
                Console.WriteLine($"{i + 1}. {tsk.Name}");
                Console.WriteLine($"   Description: {tsk.Description}");
                Console.WriteLine($"   Due Date: {tsk.DueDate.ToString("MM/dd/yyyy")}");
                Console.WriteLine($"   Status: {(tsk.IsCompleted ? "Completed" : "Not Completed")}");
                Console.WriteLine();
            }
        }

        static void AddTsk()
        {
            Console.Clear();
            Console.WriteLine("==== Add Tsk ====");
            Console.Write("Enter the tsk name: ");
            string name = Console.ReadLine();
            Console.Write("Enter the tsk description: ");
            string description = Console.ReadLine();
            Console.Write("Enter the due date (MM/dd/yyyy): ");
            DateTime dueDate = DateTime.Parse(Console.ReadLine());

            tsks.Add(new Tsk
            {
                Name = name,
                Description = description,
                DueDate = dueDate,
                IsCompleted = false
            });

            Console.WriteLine("Tsk added successfully.");
        }

        static void UpdateTsk()
        {
            Console.Clear();
            Console.WriteLine("==== Update Tsk ====");
            Console.Write("Enter the tsk number to update: ");
            int tskNumber = int.Parse(Console.ReadLine());

            if (tskNumber < 1 || tskNumber > tsks.Count)
            {
                Console.WriteLine("Invalid tsk number.");
                return;
            }

            var tsk = tsks[tskNumber - 1];

            Console.Write("Enter the updated tsk name: ");
            tsk.Name = Console.ReadLine();
            Console.Write("Enter the updated tsk description: ");
            tsk.Description = Console.ReadLine();
            Console.Write("Enter the updated due date (MM/dd/yyyy): ");
            tsk.DueDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Tsk updated successfully.");
        }

        static void DeleteTsk()
        {
            Console.Clear();
            Console.WriteLine("==== Delete Tsk ====");
            Console.Write("Enter the tsk number to delete: ");
            int tskNumber = int.Parse(Console.ReadLine());

            if (tskNumber < 1 || tskNumber > tsks.Count)
            {
                Console.WriteLine("Invalid tsk number.");
                return;
            }

            tsks.RemoveAt(tskNumber - 1);

            Console.WriteLine("Tsk deleted successfully.");
        }

        static void MarkTskAsCompleted()
        {
            Console.Clear();
            Console.WriteLine("==== Mark Tsk as Completed ====");
            Console.Write("Enter the tsk number to mark as completed: ");
            int tskNumber = int.Parse(Console.ReadLine());

            if (tskNumber < 1 || tskNumber > tsks.Count)
            {
                Console.WriteLine("Invalid tsk number.");
                return;
            }

            var tsk = tsks[tskNumber - 1];
            tsk.IsCompleted = true;

            Console.WriteLine("Tsk marked as completed.");
        }
    }
}