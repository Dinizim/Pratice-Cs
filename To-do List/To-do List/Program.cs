using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_do_List
{
    internal class Program
    {

        static void Main(string[] args)
        {



            List<string> Commands = new List<string>
        {
            "ADD + Task",
            "CHECK + Task",
            "DEL + Task",
            "ENABLE FILTER",
            "DISABLE FILTER",
            "Exit = Ctrl + N"
        };

            int exit = 1;
            List<Class_Task> List_Task = new List<Class_Task>();
            List_Task = Class_Task.View_List_Task(@"C:\Users\nicol\OneDrive\Documentos\GitHub\Pratice-C#\To-do List\task2.json");
            bool Filter = true;
            do
            {
               
                Console.Clear();
                string NewTask = " ";
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Press Ctrl + D to see the commands...");
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine(" ╔══════════════════════╗ ");
                Console.WriteLine(" ║      TO-DO LIST      ║ ");
                Console.WriteLine(" ╚══════════════════════╝ ");
                Console.WriteLine();
                
                if (Filter)
                {
                    foreach (var task in List_Task)
                    {
                       task.Task_Name = task.Task_Name.ToUpper();
                        if (!task.Task_Cheked)
                        {

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("[ ] ");


                            Console.ResetColor();
                            Console.WriteLine($" {task.Task_Name}");
                        }
                    }
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Filter Enabled");
                    Console.ResetColor();
                }
                else {
                    foreach (var task in List_Task)
                    {
                        task.Task_Name = task.Task_Name.ToUpper();
                        if (task.Task_Cheked)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("[x] ");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("[ ] ");
                        }

                        Console.ResetColor();
                        Console.WriteLine($" {task.Task_Name}");
                    }
                }
                Console.WriteLine();
                Console.WriteLine("Press the Command :");



               
                NewTask = Console.ReadLine();
                if (NewTask != "\u0004" && NewTask != "\u000e")
                {
                    
                    if (NewTask.Substring(0, 3).Equals("DEL"))
                    {
                        string task = NewTask.Substring(4);
                        for (int i = 0; i < List_Task.Count; i++)
                        {
                            string Task_Name_WithoutSpaces = List_Task[i].Task_Name.Replace(" ", "");
                            if (Task_Name_WithoutSpaces.Equals(task))
                            {
                                List_Task.RemoveAt(i);
                            }
                        }
                    }
                    if (NewTask.Substring(0, 5).Equals("CHECK"))
                    {
                        string task = NewTask.Substring(6);     

                        for (int i = 0; i < List_Task.Count; i++)
                        {
                            string Task_Name_WithoutSpaces = List_Task[i].Task_Name.Replace(" ", "");
                            if (Task_Name_WithoutSpaces.Equals(task))
                            {
                                List_Task[i].Task_Cheked = true;
                            }
                        }
                    }

                    if (NewTask.Substring(0, 4).Equals("ADD "))
                    {


                        Class_Task Task = new Class_Task();
                        string Addtask = NewTask.Substring(4);
                        Task.Task_Name = Addtask;
                        Task.Task_Cheked = false;
                        List_Task.Add(Task);
                    }
                }
                switch (NewTask)
                    {


                    case "\u000e":
                        exit = 0;
                        break;



                    case "ENABLE FILTER":
                        Filter = true;
                        break;

                    case "DISABLE FILTER":
                        Filter = false;
                        break;


                    case "\u0004":

                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Comandos disponíveis:");
                        Console.ResetColor();

                        foreach (var command in Commands)
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine($"- {command}");
                            Console.ResetColor();
                        }
                        Console.ReadLine();
                        break;
                    }
                


            } while(exit != 0);


           
            var tasks = new Class_Task();

            if (tasks.Add_List_Task(List_Task, @"C:\Users\nicol\OneDrive\Documentos\GitHub\Pratice-C#\To-do List\task2.json"))
                Console.WriteLine("Todo list Salva!");
            Console.ReadLine();
           
        }





    }
}
