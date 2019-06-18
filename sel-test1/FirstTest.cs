using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;



namespace sel_test1
{
    class FirstTest
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver(@"C:\source\selenium-chrome\");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Navigate().GoToUrl("http://www.demoqa.com/sortable");

            driver.Manage().Window.Maximize();

            IWebElement MoveFirstElement = driver.FindElement(By.XPath("//*[@id='sortable']//*[text()='Item 1']"));
            Actions builderFirst = new Actions(driver);
            IAction dragAndDropFirst = builderFirst.ClickAndHold(MoveFirstElement).MoveByOffset(0, 120).Release(MoveFirstElement).Build();
            dragAndDropFirst.Perform();

            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            Console.WriteLine("test1 done");

            IWebElement MoveLastElement = driver.FindElement(By.XPath("//*[@id='sortable']//*[text()='Item 7']"));
            Actions builderLast = new Actions(driver);
            IAction dragAndDropLast = builderLast.ClickAndHold(MoveLastElement).MoveByOffset(0, -80).Release(MoveLastElement).Build();
            dragAndDropLast.Perform();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            Console.WriteLine("test2 done");

            // click on the Selectable link on sidebar: moves to the Selectable page
            driver.FindElement(By.PartialLinkText("Selectable")).Click();

            // select a selectable item
            driver.FindElement(By.XPath("//*[@id='selectable']//*[text()='Item 1']")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);
            driver.FindElement(By.XPath("//*[@id='selectable']//*[text()='Item 3']")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);
            driver.FindElement(By.XPath("//*[@id='selectable']//*[text()='Item 7']")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);
            // clear last selected item in prep for multiple selection 
            IWebElement clearSelection = driver.FindElement(By.XPath("//*[@id='selectable']//*[text()='Item 7']"));
            new Actions(driver).MoveToElement(clearSelection).MoveByOffset(-125, 10).Click().Perform();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            Actions multiSelectBuild = new Actions(driver);
            IWebElement MultiSelectFirst = driver.FindElement(By.XPath("//*[@id='selectable']//*[text()='Item 1']"));
            IWebElement MultiSelectSecond = driver.FindElement(By.XPath("//*[@id='selectable']//*[text()='Item 3']"));
            IWebElement MultiSelectThird = driver.FindElement(By.XPath("//*[@id='selectable']//*[text()='Item 5']"));

            Actions multipleSelect = multiSelectBuild.KeyDown(Keys.Control).Click(MultiSelectFirst).Click(MultiSelectSecond).Click(MultiSelectThird).KeyUp(Keys.Control);
            multipleSelect.Perform();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            Console.WriteLine("Test 3");


            // click on the Resizable link on sidebar: moves to the resizable page
            driver.FindElement(By.PartialLinkText("Resizable")).Click();

            // resize box
            driver.FindElement(By.XPath("//*[@id='resizable']//*[contains(@class, 'ui-resizable-se')]")).Click();
            IWebElement findResizeControl = driver.FindElement(By.XPath("//*[@id='resizable']//*[contains(@class, 'ui-resizable-se')]"));
            new Actions(driver).DragAndDropToOffset(findResizeControl, 250, 500).Perform();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            new Actions(driver).DragAndDropToOffset(findResizeControl, -50, -625).Perform();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            new Actions(driver).DragAndDropToOffset(findResizeControl, 150, 125).Perform();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);


            // click on the Droppable link on sidebar
            driver.FindElement(By.PartialLinkText("Droppable")).Click();

            IWebElement draggableElement = driver.FindElement(By.XPath("//*[@id='draggable']"));
            IWebElement droppableElement = driver.FindElement(By.XPath("//*[@id='droppable']"));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);
            new Actions(driver).ClickAndHold(draggableElement).DragAndDrop(draggableElement, droppableElement).Perform();
            
       

            // select menu from Widgets section
            driver.FindElement(By.PartialLinkText("Selectmenu")).Click();
            
           
            driver.FindElement(By.XPath("//*[@id='speed-button']/span[@class='ui-selectmenu-text']")).Click();
            driver.FindElement(By.Id("ui-id-2")).Click();
            driver.FindElement(By.XPath("//*[@id='speed-button']/span[@class='ui-selectmenu-text']")).Click();
            driver.FindElement(By.Id("ui-id-5")).Click();

            //  dropListSpeedMenu = wait.Until(d => dropListSpeedMenu.FindElement(By.XPath("//*[@id='speed-button']/[@aria-expanded='true']")));
            //  dropListSpeedMenu = wait.Until(d => dropListSpeedMenu.FindElement(By.CssSelector("#speed-button[aria-expanded='true']")));

            driver.FindElement(By.XPath("//*[@id='number-button']/span[@class='ui-selectmenu-text']")).Click();
            driver.FindElement(By.Id("ui-id-4")).Click();


            Console.WriteLine("end of pull down menu testing"); 
            Console.ReadKey();
            driver.Quit();
           

        }

    }
}
