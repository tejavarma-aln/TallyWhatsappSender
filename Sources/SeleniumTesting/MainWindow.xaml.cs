using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows;
using Keys = OpenQA.Selenium.Keys;

namespace SeleniumTesting
{
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

       String log_file = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "runtimerror.log");
       IWebDriver chrome_driver;
       String file_path = @"C:\Users\Varma\Downloads\Get Coding Support.pdf";
       public List<String> contacts = new List<string>();

        private String Start_browser()
        {
            try
            {
                if (!System.IO.File.Exists(file_path))
                {
                    return "attachment not found!";
                }
                if (!System.IO.File.Exists(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "chromedriver.exe")))
                {
                    return "Error : Chrome driver  not found!";
                }
                var chrome_driver_service = ChromeDriverService.CreateDefaultService(AppDomain.CurrentDomain.BaseDirectory, "chromedriver.exe");
                chrome_driver_service.HideCommandPromptWindow = true;
                chrome_driver = new ChromeDriver(chrome_driver_service);
                
                //chrome_driver.SwitchTo().Alert().Accept();
                foreach (String ct in contacts)
                {
                    chrome_driver.Url = "https://web.whatsapp.com/send?phone=" + ct;
                    try
                    {
                        chrome_driver.SwitchTo().Alert().Dismiss();
                    }
                    catch (NoAlertPresentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    WebDriverWait wait = new WebDriverWait(chrome_driver, System.TimeSpan.FromSeconds(60));
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("input[class ='_2zCfw copyable-text selectable-text']")));

                    if (chrome_driver.FindElements(By.CssSelector("div[class ='_3u328 copyable-text selectable-text']")).Count == 0)
                    {
                        Console.WriteLine(ct + "  Not Found Moving to Next Contact");
                        continue;
                    }
                    IWebElement typebox = chrome_driver.FindElement(By.CssSelector("div[class ='_3u328 copyable-text selectable-text']"));
                    typebox.SendKeys("Coding Support Starts at 450/-*");
                    chrome_driver.FindElement(By.CssSelector("button[class ='_3M-N-']")).Click();
                    chrome_driver.FindElement(By.CssSelector("span[data-icon='clip']")).Click();
                    chrome_driver.FindElement(By.CssSelector("input[type='file']")).SendKeys(file_path);
                    WebDriverWait wait2 = new WebDriverWait(chrome_driver, System.TimeSpan.FromSeconds(30));
                    wait2.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("span[data-icon='send-light']")));
                    chrome_driver.FindElement(By.CssSelector("span[data-icon='send-light']")).Click();
                    Thread.Sleep(5 * 1000);
                    try
                    {
                        chrome_driver.SwitchTo().Alert().Dismiss();
                    }catch(NoAlertPresentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                chrome_driver.Quit();
                return "process finished";

            }
            catch (Exception ex)
            {

                if (File.Exists(log_file))
                {
                    using (StreamWriter sw = File.AppendText(log_file))
                    {
                        sw.WriteLine(ex.Message);
                    }
                }
                else
                {
                    using (var fs = new StreamWriter(log_file))
                    {
                        fs.Write(ex.Message);
                    }
                }
                chrome_driver.Quit();
                return  ex.Message + ex.StackTrace;

            }
        }

        private void Run_bt_Click(object sender, RoutedEventArgs e)
        {

            using (var csv_data = new StreamReader(@"C:\Users\Varma\Downloads\numbers list.csv"))
            {
                while (!csv_data.EndOfStream)
                {
                    var data_line = csv_data.ReadLine().Split();
                    contacts.Add("91"+data_line[0]);
                }
            }
            
             String reply = Start_browser();
             MessageBox.Show(reply);
        }
    }
}
