using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyToDo_List
{
    public class Menu
    {
        AllTasks allTasks = new AllTasks();
        public void TaskMenu()
        {
            allTasks.ReadTaskFromFile();
            bool executing = true;
            while (executing)
            {
                Console.WriteLine(" == Welcome Bro ==");
                Console.WriteLine(" ");
                Console.WriteLine(" - Input 1 => Add Task\n - Input 2 => Delete Task\n - Input 3 => View All Task\n - Input 4 => Mark Taxs \n - Input 5 => Update Taxs\n - Input 6 => Exit Task");
                int UserInput = int.Parse(Console.ReadLine()!);

                switch (UserInput)
                {

                    case 1:
                        allTasks.AddTask();
                        break;
                    case 2:
                        allTasks.DeleteTax();
                        break;
                    case 3:
                        allTasks.ViewAll();
                        break;
                    case 4:
                        allTasks.MarkTask();
                        break;
                    case 5:
                        allTasks.UpdateTask();
                        break;
                    case 6:
                        executing = false;
                        Console.WriteLine("Exiting.......", ConsoleColor.Yellow);
                        break;
                    default:
                        Console.WriteLine("Invalid Input From Range 1-6 boboyii", ConsoleColor.Red);
                        break;

                }
            }
        }
    }
}