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
 
        public String InitProcess(String contact,String file_route,String title,String chrome_binary)
        {
            try
            {
                if (!System.IO.File.Exists(file_route))
                {
                    return "Error : Attachment not found!";
                }
                if (!System.IO.File.Exists(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "chromedriver.exe")))
                {
                    return "Error : Chromedriver.exe executable not found!\n chromedriver.exe file is missing\n update or reinstalling may fix the problem";
                }
                var chrome_driver_service = ChromeDriverService.CreateDefaultService(AppDomain.CurrentDomain.BaseDirectory, "chromedriver.exe");
                chrome_driver_service.HideCommandPromptWindow = true;
                ChromeOptions chromeOptions = new ChromeOptions();
                chromeOptions.UnhandledPromptBehavior = UnhandledPromptBehavior.Accept;
                if (File.Exists(chrome_binary))
                {
                    chromeOptions.BinaryLocation = chrome_binary;
                }
                chrome_driver = new ChromeDriver(chrome_driver_service, chromeOptions);
                IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)chrome_driver;
                foreach (string ct in contact.Split(','))
                {
                    if (string.IsNullOrEmpty(ct.Trim()))
                    {
                        break;
                    }
                    if(ct.Trim().Length != 12)
                    {
                        if (!(chrome_driver is null)) chrome_driver.Quit();
                        return "Error : Invalid contact number-" + ct;
                    }
                    chrome_driver.Url = "https://web.whatsapp.com/send?phone=" + ct.Trim();
                    try
                    {
                        chrome_driver.SwitchTo().Alert().Accept();
                    }
                    catch (NoAlertPresentException e1)
                    {
                        Console.WriteLine(e1.Message);
                    }

                    try
                    {
                        WebDriverWait wait = new WebDriverWait(chrome_driver, System.TimeSpan.FromSeconds(60));
                        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='main']/footer/div[1]/div[2]/div/div[2]")));
                    }
                    catch (WebDriverTimeoutException)
                    {
                        continue;
                    }
                    //sending file
                    IWebElement file_open = chrome_driver.FindElement(By.XPath("//*[@id='main']/footer/div[1]/div[1]/div[2]/div/div/span"));
                    javaScriptExecutor.ExecuteScript("arguments[0].click();", file_open);
                    chrome_driver.FindElement(By.CssSelector("input[type='file']")).SendKeys(file_route);
                    WebDriverWait wait2 = new WebDriverWait(chrome_driver, System.TimeSpan.FromSeconds(30));
                    wait2.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='app']/div/div/div[2]/div[2]/span/div/span/div/div/div[2]/span/div/div/span")));
                    IWebElement file_send = chrome_driver.FindElement(By.XPath("//*[@id='app']/div/div/div[2]/div[2]/span/div/span/div/div/div[2]/span/div/div/span"));
                    javaScriptExecutor.ExecuteScript("arguments[0].click();", file_send);

                    Thread.Sleep(1000);

                    //sending text
                    IWebElement typebox = chrome_driver.FindElement(By.XPath("//*[@id='main']/footer/div[1]/div[2]/div/div[2]"));//:chrome_driver.FindElements(By.CssSelector("div[class ='_3u328 copyable-text selectable-text']"))[0];
                    typebox.SendKeys(title);
                    IWebElement text_send = chrome_driver.FindElement(By.XPath("//*[@id='main']/footer/div[1]/div[3]/button/span"));
                    javaScriptExecutor.ExecuteScript("arguments[0].click();", text_send);
                    Thread.Sleep(3000);
                }
                chrome_driver.Quit();
                return "Process finished";

            }
            catch (Exception ex)
            {
                if (!(chrome_driver is null)) chrome_driver.Quit();
                return ex.Message;
            }
        }
    }
}
