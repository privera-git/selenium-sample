using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium
{
    public class ExecAutomationPage
    {
        public ExecAutomationPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "TitleId")]
        public IWebElement Title { get; set; }

        private SelectElement _titleAsSelect;
        public SelectElement TitleAsSelect
        {
            get
            {
                if (_titleAsSelect == null)
                {
                    _titleAsSelect = new SelectElement(Title);
                }

                return _titleAsSelect;
            }
        }

        [FindsBy(How = How.Name, Using = "Initial")]
        public IWebElement Initial { get; set; }

        [FindsBy(How = How.Name, Using = "Save")]
        public IWebElement SaveButton { get; set; }
    }
}
