using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace YouGouWebGetData.Helpers
{
    public class YouGouHelper
    {
        public static void GetYouGou(string userName, string password, string country)
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(120));
                driver.Navigate().GoToUrl("https://app.yollgo.com/#/account/login");  //driver.Url = "http://www.baidu.com"是一样的                        
                var account = By.XPath("/html/body/div[1]/ion-nav-view/ion-nav-view/ion-view/ion-content/div[1]/div/div[2]/ion-list/div/label[2]/input");
                var key = By.XPath("/html/body/div[1]/ion-nav-view/ion-nav-view/ion-view/ion-content/div[1]/div/div[2]/ion-list/div/label[3]/input");
                var loadinded = false;
                while (!loadinded)
                {
                    try
                    {
                        Thread.Sleep(1000);
                        driver.FindElement(account).SendKeys(userName);
                        driver.FindElement(key).SendKeys(password);
                        loadinded = true;
                    }
                    catch (Exception)
                    {

                    }

                }
                Thread.Sleep(2000);
                driver.FindElement(By.Id("_label-0")).Click();


                wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/div[6]/div[2]/ion-modal-view/ion-content/div[1]/ion-list/div/ion-item")));
                Thread.Sleep(1000);
                var countryList = driver.FindElements(By.XPath("/html/body/div[6]/div[2]/ion-modal-view/ion-content/div[1]/ion-list/div/ion-item"));
                foreach (var item in countryList)
                {
                    try
                    {
                        if (item.Text.Split('+')[1].Trim() == country.Split('+')[1].Trim())
                        {
                            item.Click();
                        }

                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
                Thread.Sleep(2000);
                var loginBtn = driver.FindElement(By.XPath("/html/body/div[1]/ion-nav-view/ion-nav-view/ion-view/ion-content/div[1]/div/div[2]/div/button"));
                Thread.Sleep(2000);
                loginBtn.Click();
                var shopList = driver.FindElements(By.XPath("/html/body/div[1]/ion-nav-view/div/ion-tabs/ion-nav-view[1]/ion-view/ion-content/div[1]/div[2]/div/div"));
                while (shopList.Count == 0)
                {
                    Thread.Sleep(1000);
                    shopList = driver.FindElements(By.XPath("/html/body/div[1]/ion-nav-view/div/ion-tabs/ion-nav-view[1]/ion-view/ion-content/div[1]/div[2]/div/div"));
                }
                Thread.Sleep(1000);
                var shopName = new List<string>();
                foreach (var item in shopList)
                {
                    shopName.Add(item.Text.Split(new string[] { "\r\n" }, StringSplitOptions.None)[0]);
                }
                shopList[0].Click();

                var catalogList = driver.FindElements(By.XPath("/html/body/div[1]/ion-nav-view/div/ion-tabs/ion-nav-view[2]/ion-view/ion-content/div[1]/div[3]/div/ion-list/div/div"));


                while (catalogList.Count == 0)
                {
                    Thread.Sleep(1000);
                    catalogList = driver.FindElements(By.XPath("/html/body/div[1]/ion-nav-view/div/ion-tabs/ion-nav-view[2]/ion-view/ion-content/div[1]/div[3]/div/ion-list/div/div"));
                }
                Thread.Sleep(1000);
                catalogList[0].Click();
                Thread.Sleep(2000);
                var goodList = driver.FindElements(By.XPath("/html/body/div[1]/ion-nav-view/div/ion-tabs/ion-nav-view[2]/ion-view[2]/ion-content/div[1]/div/div"));
                while (goodList.Count == 0)
                {
                    Thread.Sleep(2000);
                    goodList = driver.FindElements(By.XPath("/html/body/div[1]/ion-nav-view/div/ion-tabs/ion-nav-view[2]/ion-view[2]/ion-content/div[1]/div/div"));
                }
                var categoryName = driver.FindElement(By.XPath("/html/body/div[1]/ion-nav-view/div/ion-nav-bar/div[2]/ion-header-bar/div[2]/span/div/div/p")).Text;

                try
                {
                    Thread.Sleep(1000);
                    goodList[1].Click();
                    Thread.Sleep(3000);
                }
                catch (Exception)
                {


                }



                var js = (IJavaScriptExecutor)driver;
                try
                {

                    var showImg = driver.FindElement(By.XPath("/html/body/div[1]/ion-nav-view/div/ion-tabs/ion-nav-view[2]/ion-view[3]/div/div[1]/ion-slide[2]/ion-scroll/div/div/div/div[2]/div[1]/img"));
                    showImg.Click();
                    Thread.Sleep(1000);
                    TakeScreenShotOfElement(driver, "E:", "first", "/html/body/div[7]/div[2]/ion-modal-view/ion-scroll/div[1]/div/img[2]");
                    Thread.Sleep(1000);
                    driver.FindElement(By.XPath("/html/body/div[7]/div[2]/ion-modal-view/ion-scroll/div[1]/div/img[2]")).Click();


                    var title = driver.FindElement(By.CssSelector("div.info-area > div > div > div.fx-hd7.ng-binding")).Text;
                    var barcode = driver.FindElement(By.CssSelector("div.info-area > div > div > div:nth-child(2) > div:nth-child(1)")).Text;
                    var packageQty = driver.FindElement(By.CssSelector("div.info-area > div > div > div:nth-child(3) > div:nth-child(1)")).Text;
                    var boxQty = driver.FindElement(By.CssSelector("div.info-area > div > div > div:nth-child(3) > div:nth-child(3)")).Text;
                    var price = driver.FindElement(By.CssSelector("div.panel-info > div.info-area > div > div > div:nth-child(4) > div")).Text;
                    var bianhao = driver.FindElement(By.CssSelector("div.info-area > div > div > div:nth-child(2) > div:nth-child(2)")).Text;

                }
                catch (Exception ex)
                {
                    var msg = ex.ToString();

                }

            }

        }


        public  static void Test()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(120));
                driver.Navigate().GoToUrl("https://www.baidudu.com");  //driver.Url = "http://www.baidu.com"是一样的      
            }

        }
        public static void TakeScreenShotOfElement(IWebDriver driver, string rootpath, string imgName, string element2)
        {

            string element3 = element2;
            var element = driver.FindElement(By.XPath(element3));
            Byte[] ba = ((ITakesScreenshot)driver).GetScreenshot().AsByteArray;
            using (var ss = new Bitmap(new MemoryStream(ba)))
            {
                var crop = new System.Drawing.Rectangle(element.Location.X, element.Location.Y, element.Size.Width, element.Size.Height);

                //create a new image by cropping the original screenshot
                Bitmap image2 = ss.Clone(crop, ss.PixelFormat);


                if (!Directory.Exists(rootpath))
                {
                    Directory.CreateDirectory(rootpath);
                }
                image2.Save(String.Format("{0}\\{1}.jpg", rootpath, imgName), System.Drawing.Imaging.ImageFormat.Jpeg);

            }

        }
    }
}
