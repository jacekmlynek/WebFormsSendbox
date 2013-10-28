using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using WatiN.Core;
using WatiN.Core.Interfaces;

namespace NunitTests
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void TestCase1()
        {
            Assert.That(true, Is.True);
        }

        [Test]
        public void FaildCase()
        {
            Assert.AreEqual("ola", "ala");
        }

        // STA is necessary to run test in separate thread.
        [Test, RequiresSTA]
        public void WpLoadingTest()
        {
            using (var browser = new IE("http://www.google.com"))
            {
                browser.TextField(Find.ByName("q")).TypeText("WatiN");
                browser.Button(Find.ByName("btnG")).Click();

                var waitForWithAssert = new WaitForPage(() =>
                {
                    Assert.IsTrue(browser.ContainsText("WatiN"));
                });
            }
        }

        class WaitForPage : IWait
        {
            private readonly Action action;

            public WaitForPage(Action action)
            {
                this.action = action;
            }

            #region IWait Members

            public void DoWait()
            {
                action.Invoke();
            }

            #endregion
        }
    }
}
