using System;
using System.Threading;
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

            IWebElement MoveFirstElement = driver.FindElement(By.XPath("//*[@id='sortable']//*[text()='Item 1']"));
            Actions builderFirst = new Actions(driver);
            IAction dragAndDropFirst = builderFirst.ClickAndHold(MoveFirstElement).MoveByOffset(0, 120).Release(MoveFirstElement).Build();
            dragAndDropFirst.Perform();

            Thread.Sleep(2000);
            Console.WriteLine("test1 done");

            IWebElement MoveLastElement = driver.FindElement(By.XPath("//*[@id='sortable']//*[text()='Item 7']"));
            Actions builderLast = new Actions(driver);
            IAction dragAndDropLast = builderLast.ClickAndHold(MoveLastElement).MoveByOffset(0, -80).Release(MoveLastElement).Build();
            dragAndDropLast.Perform();

            Thread.Sleep(2000);
            Console.WriteLine("test2 done");

            // click on the Selectable link on sidebar: moves to the Selectable page
            driver.FindElement(By.PartialLinkText("Selectable")).Click();

            // select a selectable item
            driver.FindElement(By.XPath("//*[@id='selectable']//*[text()='Item 1']")).Click();
            Thread.Sleep(500);
            driver.FindElement(By.XPath("//*[@id='selectable']//*[text()='Item 3']")).Click();
            Thread.Sleep(500);
            driver.FindElement(By.XPath("//*[@id='selectable']//*[text()='Item 7']")).Click();
            Thread.Sleep(500);
            // clear last selected item in prep for multiple selection 
            IWebElement clearSelection = driver.FindElement(By.XPath("//*[@id='selectable']//*[text()='Item 7']"));
            new Actions(driver).MoveToElement(clearSelection).MoveByOffset(-125, 10).Click().Perform();
            
            Thread.Sleep(2000);

            Actions multiSelectBuild = new Actions(driver);
            IWebElement MultiSelectFirst = driver.FindElement(By.XPath("//*[@id='selectable']//*[text()='Item 1']"));
            IWebElement MultiSelectSecond = driver.FindElement(By.XPath("//*[@id='selectable']//*[text()='Item 3']"));
            IWebElement MultiSelectThird = driver.FindElement(By.XPath("//*[@id='selectable']//*[text()='Item 5']"));

            Actions multipleSelect = multiSelectBuild.KeyDown(Keys.Control).Click(MultiSelectFirst).Click(MultiSelectSecond).Click(MultiSelectThird).KeyUp(Keys.Control);
            multipleSelect.Perform();
            Thread.Sleep(2000);

            Console.WriteLine("Test 3");


            // click on the Resizable link on sidebar: moves to the resizable page
            driver.FindElement(By.PartialLinkText("Resizable")).Click();

            // resize box
           driver.FindElement(By.XPath("//*[@id='resizable']//*[contains(@class, 'ui-resizable-se')]")).Click();
           IWebElement findResizeControl = driver.FindElement(By.XPath("//*[@id='resizable']//*[contains(@class, 'ui-resizable-se')]"));
           new Actions(driver).DragAndDropToOffset(findResizeControl, 250, 500).Perform();
           Thread.Sleep(2000);
           new Actions(driver).DragAndDropToOffset(findResizeControl, -50, -625).Perform();
           Thread.Sleep(2000);
           new Actions(driver).DragAndDropToOffset(findResizeControl, 150, 125).Perform();
           Thread.Sleep(2000);


            // click on the Droppable link on sidebar
            driver.FindElement(By.PartialLinkText("Droppable")).Click();

            IWebElement draggableElement = driver.FindElement(By.XPath("//*[@id='draggable']"));
            IWebElement droppableElement = driver.FindElement(By.XPath("//*[@id='droppable']"));
            Thread.Sleep(500);
            new Actions(driver).ClickAndHold(draggableElement).DragAndDrop(draggableElement, droppableElement).Perform();
            Thread.Sleep(1000);


            //   Console.ReadKey();
            driver.Quit();
           

        }

    }
}
