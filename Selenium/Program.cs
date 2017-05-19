using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;

namespace Selenium
{
    class Program
    {        
        static void Main(string[] args)
        {
            //IWebDriver driver = new ChromeDriver(@"c:/users/alexander/documents/visual studio 2015/Projects/Selenium/Selenium/media/");
            IWebDriver driver = new RemoteWebDriver(new Uri("http://127.0.0.1:4444/wd/hub"), DesiredCapabilities.Chrome());
            //IWebDriver driver = new RemoteWebDriver(new Uri("http://127.0.0.1:4444/wd/hub"), new DesiredCapabilities("Chrome", "", new Platform(PlatformType.XP)));
            driver.Url = "https://www.ilimitada.com.co/es/contenidos/cursosonline/login/";
            driver.FindElement(By.Id("id_email")).SendKeys("alex-12-04@hotmail.com");
            driver.FindElement(By.Id("id_password")).SendKeys("xxxxxxxxx");
            driver.FindElement(By.Id("btnacceder")).Submit();
            var listamenu = driver.FindElements(By.CssSelector("#footer #datosIlimitada .contenedorMenu a"));
            for (int i = 0; i < listamenu.Count; i++)
            {
                listamenu = driver.FindElements(By.CssSelector("#footer #datosIlimitada .contenedorMenu a"));//se cargan las opciones de menu por el click
                Console.WriteLine(listamenu[i].Text);
                listamenu[i].Click();    //hacer click y refrescar la nueva pagina ya no se tienen cargadas las opciones del menu            
            }            
        }
    }
}
