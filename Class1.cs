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

        OpenQA.Selenium.IWebDriver chrome_driver = null;

        public String InitProcess(String contact,String file_route,String title,String time_wait)
        {
            try
            {
                if (!System.IO.File.Exists(file_route))
                {
                    return "Error : attachment not found!";
                }
                if (!System.IO.File.Exists(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "chromedriver.exe")))
                {
                    return "Error : chromedriver.exe executable not found! make sure you put all the files in tally working directory";
                }
                if (contact.Length != 12)
                {
                    return "Error : Invalid Contact, it should contain 12 digits with country code";
                }
                var chrome_driver_service = ChromeDriverService.CreateDefaultService(AppDomain.CurrentDomain.BaseDirectory, "chromedriver.exe");
                chrome_driver_service.HideCommandPromptWindow = true;

                chrome_driver = new ChromeDriver(chrome_driver_service)
                {
                    Url = "https://web.whatsapp.com/send?phone=" + contact
                };

                WebDriverWait wait = new WebDriverWait(chrome_driver, System.TimeSpan.FromSeconds(60));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("div[class ='_2S1VP copyable-text selectable-text']")));
                if (chrome_driver.FindElements(By.CssSelector("div[class ='_2S1VP copyable-text selectable-text']")).Count == 1)
                {
                    chrome_driver.Quit();
                    return "Number not found in whatsapp database";
                }
                chrome_driver.FindElement(By.CssSelector("span[data-icon='clip']")).Click();
                chrome_driver.FindElement(By.CssSelector("input[type='file']")).SendKeys(file_route);
                WebDriverWait wait2 = new WebDriverWait(chrome_driver, System.TimeSpan.FromSeconds(30));
                wait2.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("span[data-icon='send']")));
                chrome_driver.FindElement(By.CssSelector("span[data-icon='send']")).Click();
                Thread.Sleep(1000);
                IWebElement typebox = chrome_driver.FindElements(By.CssSelector("div[class ='_2S1VP copyable-text selectable-text']"))[1];
                typebox.SendKeys(title);
                IWebElement msg_send = chrome_driver.FindElement(By.CssSelector("span[data-icon ='send']"));
                msg_send.Click();
                Thread.Sleep(int.Parse(time_wait) * 1000);
                chrome_driver.Quit();
                return "process finished";

            }
            catch (Exception ex)
            {
                if (!(chrome_driver is null)) chrome_driver.Quit();
                return ex.Message;
            }
        }
    }
}
