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



            List<Class_Task> List_Task = new List<Class_Task>();
            List_Task = Class_Task.View_List_Task(@"C:\Users\nicol\OneDrive\Documentos\GitHub\Pratice-C#\To-do List\task2.json");
            Class_Task Task = new Class_Task();
            Task.Task_Name = "limpar cozinha a noite";
            Task.Task_Cheked = false;
            List_Task.Add(Task);
            Class_Task Task2 = new Class_Task();
            Task2.Task_Name = "limpar cozinha DNVVVVVV";
            Task2.Task_Cheked = false;
            List_Task.Add(Task2);


            /*
            var tasks = new Class_Task();
            if (tasks.Add_List_Task(List_Task, @"C:\Users\nicol\OneDrive\Documentos\GitHub\Pratice-C#\To-do List\task2.json"))
                Console.WriteLine("salvo");
            */
            List<string> Commands = new List<string> {"Add + Task", "Check + Task", "Del + Task" };

            int exit = 1;
            do
            {
                Console.Clear();
                string NewTask = " ";
                Console.WriteLine();
                Console.WriteLine(" TO-DO LIST");
                Console.WriteLine("==================");
                Console.WriteLine();


                foreach (var task in List_Task)
                {
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
                    Console.WriteLine(task.Task_Name);
                }
                Console.WriteLine();
                Console.WriteLine("Press the Commands :");
                Console.WriteLine("Press Ctrl + D to see the commands...");
                NewTask = Console.ReadLine();

                if(NewTask.ToLower() == "\u0004")
                {
                    Console.Clear();
                    Console.WriteLine("Comandos disponíveis:");
                    foreach (var command in Commands)
                    {
                        Console.WriteLine(command);
                    }
                    Console.ReadLine();

                }

            } while(exit != 0);
        }

        

        

    }
}
