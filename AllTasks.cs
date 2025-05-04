using System;
using ConsoleTables;
using System.Collections.Generic;
namespace MyToDo_List
{

    public class AllTasks
    {
        string getDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
        string fileName = "ListOfTask.txt";
        private List<ToDoTask> tasks = new List<ToDoTask>();
        public void WriteToDoTaskToFile(ToDoTask toDoTask)
        {
            try
            {
                string filePath = Path.Combine(getDirectory, fileName);
                using (var streamWriter = new StreamWriter(filePath, true))
                {
                    streamWriter.WriteLine(toDoTask.ToString());
                }
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void AddTask()
        {

            int id = tasks.Count > 0 ? tasks.Count + 1 : 1;
            Console.WriteLine("Enter a task you're adding:");
            string taskInput = Console.ReadLine()!;
            Console.WriteLine("Enter date to end task:");
            DateTime endDate = DateTime.Parse( Console.ReadLine()!);

            var newTask = new ToDoTask(id, taskInput, DateTime.Now, false, endDate);

            tasks.Add(newTask);
            WriteToDoTaskToFile(newTask);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Your Task => '{newTask.Task}' and Id {newTask.Id} and The EndTine {newTask.EndTime} created successfully !");
            Console.ResetColor();
            Console.WriteLine(" ");

        }
        public void DeleteTax()
        {
            Console.Write("Enter the ID of Tax: ");
            int id = int.Parse(Console.ReadLine()!);
            var task = tasks.Find(x => x.Id == id);

            if (task is null)
            {
                Console.WriteLine("the Tax  you are trying to delete does not exist!", ConsoleColor.Red);
                Console.ResetColor();
            }
            else
            {
                //Added this 
                tasks.Remove(task);
                RefreshFile();
                Console.WriteLine($"Tax {task.Id} Deleted Sharp", ConsoleColor.Green);

            }

            Console.ResetColor();

        }


        public void MarkTask()
        {
            Console.WriteLine("Enter Id Of The Task You want to Mark");
            int id = int.Parse(Console.ReadLine()!);
            var task = GetById(id);

            if (task != null)
            {
                tasks[id - 1].MarkTask();
                RefreshFile();
                Console.WriteLine("Task Complete", ConsoleColor.Yellow);
                Console.ResetColor();

            }
            else
            {
                Console.WriteLine("Not Found");
            }
        }

        public void ViewAll()
        {
            if (tasks.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("There are no tasks in the database yet! Add new tasks bobo ");
                Console.ResetColor();
                return;
            }

            var table = new ConsoleTable("Id", "Task", "Created At", "End Time","Done");

            foreach (var task in tasks)
            {
                table.AddRow(task.Id, task.Task, task.CreatedAt.ToString("dd MMM yyyy HH:mm:ss"), task.EndTime.ToString("dd MMM yyyy HH:mm:ss"),task.IsDone);
            }

            table.Write();
            Console.WriteLine();
        }


        public void UpdateTask()
        {
            Console.Write("Enter the ID of the task to update: ");
            int id = int.Parse(Console.ReadLine()!);
            var task = GetById(id);

            if (task is null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The task you are trying to update does not exist!");
            }

            else
            {
                Console.WriteLine($"Current Task: {task.Task}");
                Console.Write("Enter the new task : ");
                string updatedTask = Console.ReadLine()!;

                task.Task = updatedTask;
                RefreshFile();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Task {task.Id} updated successfully To => '{task.Task}'.");

            }

            Console.ResetColor();

        }
        private ToDoTask? GetById(int id)
        {
            return tasks.Find(x => x.Id == id);

        }
        public void ReadTaskFromFile()
        {
            try
            {
                string filePath = Path.Combine(getDirectory, fileName);
                if (File.Exists(filePath))
                {
                    var bookings = File.ReadAllLines(filePath);
                    foreach (var booking in bookings)
                    {
                        var item = ToDoTask.ToBooking(booking);
                        tasks.Add(item);
                    }
                }
                else
                {
                    using (File.Create(filePath))
                    {
                        File.Create(filePath);
                    }
                }
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void RefreshFile()
        {
            try
            {
                string filePath = Path.Combine(getDirectory, fileName);
                File.WriteAllText(filePath, string.Empty);
                using (var streamWriter = new StreamWriter(filePath))
                {
                    foreach (var item in tasks)
                    {
                        streamWriter.WriteLine(item.ToString());
                    }
                }
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}




