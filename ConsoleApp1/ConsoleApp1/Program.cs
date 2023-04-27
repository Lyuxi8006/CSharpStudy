// See https://aka.ms/new-console-template for more information
using System;
using System.Diagnostics;
using System.IO;

namespace AsyncAwaitTest
{
    class Program
    {
        private void Test()
        {
            Debug.WriteLine("主线程--开始");
            TestVoidAsync();
            Debug.WriteLine("主线程--结束");
        }

        private async void TestVoidAsync()
        {
            Debug.WriteLine("开始执行TestVoidAsync方法");
            Task task = new Task(() =>
            {
                Debug.WriteLine("开始子线程耗时操作");
                Thread.Sleep(4000);
                Debug.WriteLine("结束子线程耗时操作");

            });
            task.Start();
            await task;
            Debug.WriteLine("await关键字后面的内容 1");
            Debug.WriteLine("await关键字后面的内容 2");

        }


        static void Main(string[] args)
        {
            Program p = new Program();
            p.Test();
            Console.ReadKey();

        }
    }
}