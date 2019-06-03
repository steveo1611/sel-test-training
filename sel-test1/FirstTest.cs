using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;


namespace sel_test1
{
    class FirstTest
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver(@"C:\source\selenium-chrome\");
            driver.Navigate().GoToUrl("http://www.demoqa.com/sortable");

            driver.Manage().Window.Maximize();

            IWebElement MoveFirstElement = driver.FindElement(By.XPath("//*[@id='sortable']/li[1]/span[text()='Item1']"));

            Actions builderFirst = new Actions(driver);
            IAction dragAndDropFirst = builderFirst.ClickAndHold(MoveFirstElement).MoveByOffset(0, 120).Release(MoveFirstElement).Build();

            dragAndDropFirst.Perform();

            Console.WriteLine("test1 done");

            IWebElement MoveLastElement = driver.FindElement(By.XPath("//*[@id='sortable']/li[7]/span"));

            Actions builderLast = new Actions(driver);
            IAction dragAndDropLast = builderLast.ClickAndHold(MoveLastElement).MoveByOffset(0, -80).Release(MoveLastElement).Build();
            dragAndDropLast.Perform();

            Console.WriteLine("test2 done");


            Console.WriteLine("Test 3");
            Console.WriteLine("Click the 'ANY' key to end the test");
            Console.ReadKey();


            driver.Quit();
           

        }

    }
}
