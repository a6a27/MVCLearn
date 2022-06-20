using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest同步非同步
    {

        static async Task<string> MyDownloadPageAsync(string url)
        {
            using (var webClient = new WebClient())
            {
                Task<string> task = webClient.DownloadStringTaskAsync(url);
                string content = await task;
                return content;
            }
        }

        [TestMethod]
        public async Task 網頁內容()
        {
            var url = "https://www.huanlintalk.com";
            //// await 後就是接收 Result 的值
            string 我等待 = await MyDownloadPageAsync(url);
            string 我不等待 = MyDownloadPageAsync(url).Result;
        }



        #region Run 執行順序

        [TestMethod]
        public void 執行順序()
        {
            var t = Task.Run(() => ShowThreadInfo("其他執行序工作"));
            ShowThreadInfo("主執行序工作");
            t.Wait();
        }

        [TestMethod]
        public void 執行順序2()
        {
            var t = Task.Run(() => ShowThreadInfo("其他執行序工作"));
            t.Wait();
            ShowThreadInfo("主執行序工作");
        }

        static void ShowThreadInfo(string s)
        {
            Console.WriteLine("{0} thread ID: {1}",
                              s, Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(1000);
        }

        #endregion



        #region WaitAll

        [TestMethod]
        public void WaitAll()
        {
            var t0 = Task.Run(() => ShowThreadInfo("其他執行序工作"));
            var t1 = Task.Run(() => ShowThreadInfo("其他執行序工作"));
            var t2 = Task.Run(() => ShowThreadInfo("其他執行序工作"));
            var t3 = Task.Run(() => ShowThreadInfo("其他執行序工作"));
            var t4 = Task.Run(() => ShowThreadInfo("其他執行序工作"));
            Task.WaitAll();
            ShowThreadInfo("主執行序工作");
        }

        [TestMethod]
        public void WaitAll2()
        {
            var t0 = Task.Run(() => ShowThreadInfo("其他執行序工作"));
            var t1 = Task.Run(() => ShowThreadInfo("其他執行序工作"));
            var t2 = Task.Run(() => ShowThreadInfo("其他執行序工作"));
            var t3 = Task.Run(() => ShowThreadInfo("其他執行序工作"));
            var t4 = Task.Run(() => ShowThreadInfo("其他執行序工作"));
            ShowThreadInfo("主執行序工作");
            Task.WaitAll();
        }

        /// <summary>
        /// 進階應用 等待固定秒數
        /// </summary>
        [TestMethod]
        public void WaitAll3()
        {
            Task Task1 = Task.Run(() => Thread.Sleep(1000));
            Task Task2 = Task.Run(() => Thread.Sleep(2000));
            Task Task3 = Task.Run(() => Thread.Sleep(3000));

            Task.WaitAll(new Task[] { Task1, Task2, Task3 }, 2500);

            Console.WriteLine("Task1.IsCompleted:{0}", Task1.IsCompleted);
            Console.WriteLine("Task2.IsCompleted:{0}", Task2.IsCompleted);
            Console.WriteLine("Task3.IsCompleted:{0}", Task3.IsCompleted);
        }
        #endregion

    }
}
