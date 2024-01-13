using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace To_do_List
{
    internal class Class_Task
    {
        public string Task_Name { get; set; }
        public bool Task_Cheked { get; set; }

        public bool Add_List_Task(List<Class_Task> list,string path)
        {
            var strJson = JsonConvert.SerializeObject(list, Formatting.Indented);
            return SaveFileTask(strJson, path);
        }
        public static List<Class_Task> View_List_Task(string json_path)
        {
            var srtJson = OpenFileTask(json_path);
            if(srtJson.Substring(0,5) != "ERROR")
            return JsonConvert.DeserializeObject<List<Class_Task>>(srtJson);
            else
                {
                List<Class_Task> List_Task = new List<Class_Task>();
                var task = new Class_Task();
                task.Task_Name = srtJson;
                List_Task.Add(task);
                task.Task_Name = srtJson;
                return List_Task;
            }
        }
        private static string OpenFileTask( string path)
        {
            try
            {
                var Task_Json = path;
                using (StreamReader sr = new StreamReader(path))
                {
                    Task_Json = sr.ReadToEnd();
                }
                
                return Task_Json;
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("json não salvo, eu odeio minha vida");
                return "ERROR: " + ex.Message;
            }
        }

        private bool SaveFileTask(string strjson, string path)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine(strjson);
                }
                return true;
               
            }
            catch (Exception ex)
            {
                Console.WriteLine("json não salvo, eu odeio minha vida");
                return false;
            }
        }
    }
}
