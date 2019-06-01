using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium
{
    class ExecuteAutomationTest
    {
        IWebDriver _driver = new ChromeDriver();

        [SetUp]
        public void Initialize()
        {
            Console.WriteLine("Abriendo el navegador.");

            // Abrir el sitio de google
            _driver.Navigate().GoToUrl("http://executeautomation.com/demosite/index.html?UserName=&Password=&Login=Login");

            Console.WriteLine("Abierto el navegador.");
        }

        [Test]
        public void ExecuteTest()
        {
            Console.WriteLine("Ejecutando la prueba.");

            var expectedTitle = "Mr.";
            var expectedTitleValue = "1";
            var expectedInitial = "Ejemplo";

            var pm = new PageManipulator(_driver);
            pm.SelectDropDown("TitleId", PageManipulator.SearchTypes.ById, expectedTitle);
            pm.EnterText("Initial", PageManipulator.SearchTypes.ByName, expectedInitial);
            pm.Click("Save", PageManipulator.SearchTypes.ByName);

            var actualTitle = pm.GetText("TitleId", PageManipulator.SearchTypes.ById);
            var actualInitial = pm.GetText("Initial", PageManipulator.SearchTypes.ById);
            //Assert.AreEqual(expectedTitle, actualTitle);
            Assert.AreEqual(expectedTitleValue, actualTitle);
            Assert.AreEqual(expectedInitial, actualInitial);
            
            Console.WriteLine("Prueba ejecutada.");
        }

        [Test]
        public void ExecuteTest_PageObjects()
        {
            Console.WriteLine("Ejecutando la prueba.");

            var expectedTitle = "Mr.";
            var expectedInitial = "Ejemplo";

            var page = new ExecAutomationPage(_driver);            
            page.TitleAsSelect.SelectByText(expectedTitle);
            page.Initial.SendKeys(expectedInitial);
            page.SaveButton.Click();
            
            var actualTitle = page.TitleAsSelect.SelectedOption.Text;
            var actualInitial = page.Initial.GetAttribute("value");

            //Assert.AreEqual(expectedTitle, actualTitle);
            Assert.AreEqual(expectedTitle, actualTitle);
            Assert.AreEqual(expectedInitial, actualInitial);

            Console.WriteLine("Prueba ejecutada.");
        }

        [TearDown]
        public void CleanUp()
        {
            Console.WriteLine("Cerrando el navegador.");

            // Cerrar el navegador
            _driver.Close();
            _driver.Quit();

            Console.WriteLine("Cerrado el navegador.");
        }
    }
}
