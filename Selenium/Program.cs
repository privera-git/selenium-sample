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
    class Program
    {
        static void Main(string[] args)
        {
            // Crear una referencia a Google Chrome
            IWebDriver driver = new ChromeDriver();

            // Abrir el sitio de google
            driver.Navigate().GoToUrl("http://www.google.com");

            // Obtener la caja de texto de búsqueda y el botón Buscar
            IWebElement searchInput = driver.FindElement(By.Name("q"));

            // Escribir un texto en la caja de texto
            searchInput.SendKeys("videos de gatitos");

            // Cerrar el navegador
            driver.Close();
        }
    }
}
