using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium
{
    public class PageManipulator
    {
        /// <summary>
        /// Driver de la página que se desea manipular.
        /// </summary>
        private IWebDriver _driver;

        public PageManipulator(IWebDriver driver)
        {
            _driver = driver;
        }

        /// <summary>
        /// Ingresa un texto en una caja de texto.
        /// </summary>
        /// <param name="searchString">Texto con el que se busca el Elemento.</param>
        /// <param name="searchType">Tipo de búsqueda.</param>
        /// <param name="value">Valor que se desea ingresar.</param>
        public void EnterText(string searchString, SearchTypes searchType, string value)
        {
            IWebElement element = FindElement(searchString, searchType);
            
            element.Clear();
            element.SendKeys(value);
        }

        /// <summary>
        /// Hace clic en un control.
        /// </summary>
        /// <param name="searchString">Texto con el que se busca el Elemento.</param>
        /// <param name="searchType">Tipo de búsqueda.</param>
        public void Click(string searchString, SearchTypes searchType)
        {
            FindElement(searchString, searchType).Click();
        }

        /// <summary>
        /// Selecciona un elemento de un drop down por el texto de la opción.
        /// </summary>
        /// <param name="searchString">Texto con el que se busca el Elemento.</param>
        /// <param name="searchType">Tipo de búsqueda del elemento.</param>
        /// <param name="value">Texto que se desea seleccionar.</param>
        public void SelectDropDown(string searchString, SearchTypes searchType, string value)
        {
            IWebElement element = FindElement(searchString, searchType);

            // Esta clase requiere el paquete Selenium.Support
            new SelectElement(element).SelectByText(value);

        }

        /// <summary>
        /// Obtiene el texto de un control.
        /// </summary>
        /// <param name="searchString">Texto con el que se busca el Elemento.</param>
        /// <param name="searchType">Tipo de búsqueda.</param>
        /// <returns>Retorna el texto del control.</returns>
        public string GetText(string searchString, SearchTypes searchType)
        {
            return FindElement(searchString, searchType).GetAttribute("value");
        }

        /// <summary>
        /// Obtiene el texto de un drop down.
        /// </summary>
        /// <param name="searchString">Texto con el que se busca el Elemento.</param>
        /// <param name="searchType">Tipo de búsqueda.</param>
        /// <returns>Retorna el texto del drop down.</returns>
        public string GetTextFromDDL(string searchString, SearchTypes searchType)
        {
            IWebElement element = FindElement(searchString, searchType);

            // Esta clase requiere el paquete Selenium.Support
            return new SelectElement(element).SelectedOption.Text;
        }

        /// <summary>
        /// Busca un elemento en la página.
        /// </summary>
        /// <param name="searchString">Texto con el que se busca el Elemento.</param>
        /// <param name="searchType">Tipo de búsqueda.</param>
        /// <returns>Retorna el elemento encontrado.</returns>
        private IWebElement FindElement(string searchString, SearchTypes searchType)
        {
            switch (searchType)
            {
                case SearchTypes.ByName:
                    return _driver.FindElement(By.Name(searchString));
                case SearchTypes.ById:
                    return _driver.FindElement(By.Id(searchString));
                default:
                    throw new ArgumentOutOfRangeException("searchType");
            }
        }

        public enum SearchTypes
        {
            ById,
            ByName
        }
    }
}
