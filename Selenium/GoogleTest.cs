using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium
{
    class GoogleTest
    {
        IWebDriver _driver;// = new ChromeDriver();

        [SetUp]
        public void Initialize()
        {
            Console.WriteLine("Abriendo el navegador.");

            // Abrir el sitio de google
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("http://www.google.com");

            Console.WriteLine("Abierto el navegador.");
        }

        [Test]
        public void ExecuteTest()
        {
            Console.WriteLine("Ejecutando la prueba.");

            // Obtener la caja de texto de búsqueda y el botón Buscar
            IWebElement searchInput = _driver.FindElement(By.Name("q"));

            // Escribir un texto en la caja de texto
            searchInput.SendKeys("videos de gatitos");

            Console.WriteLine("Prueba ejecutada.");
        }

        [TearDown]
        public void CleanUp()
        {
            Console.WriteLine("Cerrando el navegador.");

            // Cerrar el navegador
            _driver.Close();

            Console.WriteLine("Cerrado el navegador.");
        }
    }
}
