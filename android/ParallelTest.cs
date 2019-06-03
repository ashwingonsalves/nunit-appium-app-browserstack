using System;
using System.Threading;
using System.Collections.ObjectModel;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;

namespace android
{
  [TestFixture("parallel", "pixel-2")]
  [TestFixture("parallel", "pixel-3")]
  [TestFixture("parallel", "pixel-3-xl")]
  [TestFixture("parallel", "galaxy-s9-plus")]
  [TestFixture("parallel", "galaxy-s8-plus")]
  [Parallelizable(ParallelScope.Fixtures)]
  public class ParallelTest : BrowserStackNUnitTest
  {
    public ParallelTest(string profile, string environment) : base(profile, environment) { }

    [Test]
    public void searchWikipedia()
    {
      AndroidElement searchElement = (AndroidElement)new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(MobileBy.AccessibilityId("Search Wikipedia")));
      searchElement.Click();
      AndroidElement insertTextElement = (AndroidElement)new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(By.Id("org.wikipedia.alpha:id/search_src_text")));
      insertTextElement.SendKeys("Browserstack");
      Thread.Sleep(5000);

      ReadOnlyCollection<AndroidElement> allProductsName = driver.FindElements(By.ClassName("android.widget.TextView"));
      Assert.True(allProductsName.Count > 0);
    }
  }
}
