using System;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;

namespace MMTDigitalTechTest.SeleniumUtils
{
    class CommonUtils
    {
        public void PrintLogs(string LogType, IWebDriver driver)
        {
            var _logs = driver.Manage().Logs;

            try
            {
                var browserLogs = _logs.GetLog(LogType);
                if (browserLogs.Count > 0)
                {
                    var filePath = $"{Path.GetTempPath()}ConsoleLogs-{Guid.NewGuid()}.txt";
                    File.WriteAllText(filePath, "Begin Log: ");

                    foreach (var log in browserLogs)
                    {
                        //log message in a file
                        StreamWriter sw = File.AppendText(filePath);
                        sw.WriteLine(log.ToString());
                        sw.Close();
                    }
                    TestContext.AddTestAttachment(filePath, "Browser Console Logs")
                }
            }
            catch
            {
                Console.WriteLine("No Logs Present");
            }

        }
    }
}
