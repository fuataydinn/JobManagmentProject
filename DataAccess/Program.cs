using DataAccess.Models;
using System;

namespace DataAccess
{
    class Program
    {
        static void Main(string[] args)
        {
             var mainTask = new MainTask()
            {
                Name = "Ana iş"
            };

            var sub01 = new SubTask();
            sub01.Start();
            sub01.Complete();

            //System.Threading.Thread.Sleep(1000);

            var sub02 = new SubTask();
            //sub02.Start();
            sub02.Complete();

            //System.Threading.Thread.Sleep(1000);


            var sub03 = new SubTask();
            sub03.Start();
            sub03.Complete();

            mainTask.SubTasks.Add(sub01);
            mainTask.SubTasks.Add(sub02);
            mainTask.SubTasks.Add(sub03);

            Console.WriteLine($"StartedOn:{mainTask.StartedOn}");
            Console.WriteLine($"CompletedOn:{mainTask.CompletedOn}");
            Console.WriteLine($"Status:{mainTask.Status}");
        }
    }
}
