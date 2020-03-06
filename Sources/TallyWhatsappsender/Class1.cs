using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Threading;
 

namespace TallyWhatsappsender
{
    public class Class1
    {

        OpenQA.Selenium.IWebDriver chrome_driver;

        public String InitProcess(String contact,String file_route,String title,String time_wait)
        {
            try
            {
                if (!System.IO.File.Exists(file_route))
                {
                    return "Error : attachment not found!";
                }
                if(!System.IO.File.Exists(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "chromedriver.exe")))
                {
                    return "Error : chromedriver.exe executable not found! make sure you put all the files in tally working directory";
                }
                if(contact.Length != 12)
                {
                    return "Error : Invalid Contact, it should contain 12 digits with country code";
                }
                var chrome_driver_service = ChromeDriverService.CreateDefaultService(AppDomain.CurrentDomain.BaseDirectory, "chromedriver.exe");
                chrome_driver_service.HideCommandPromptWindow = true;
                chrome_driver = new ChromeDriver(chrome_driver_service)
                {
                    Url = "https://web.whatsapp.com/send?phone="+contact
                };
                
                WebDriverWait wait = new WebDriverWait(chrome_driver, System.TimeSpan.FromSeconds(60));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("input[class ='_2zCfw copyable-text selectable-text']")));
                IWebElement typebox = chrome_driver.FindElement(By.CssSelector("div[class ='_3u328 copyable-text selectable-text']"));
                typebox.SendKeys(title);
                chrome_driver.FindElement(By.CssSelector("button[class ='_3M-N-']")).Click();
                chrome_driver.FindElement(By.CssSelector("span[data-icon='clip']")).Click();
                chrome_driver.FindElement(By.CssSelector("input[type='file']")).SendKeys(file_route);
    
                WebDriverWait wait2 = new WebDriverWait(chrome_driver, System.TimeSpan.FromSeconds(30));
                wait2.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("span[data-icon='send-light']")));
                chrome_driver.FindElement(By.CssSelector("span[data-icon='send-light']")).Click();
                Thread.Sleep(int.Parse(time_wait)*1000);
                chrome_driver.Quit();
                return "process finished";

            }
            catch (Exception ex)
            {
                chrome_driver.Quit();
                return ex.Message;
            }
        }
    }
}
