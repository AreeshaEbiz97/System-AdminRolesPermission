using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using System.Threading.Tasks;

namespace PlaywrightTests
{
    public class BaseTest : PageTest
    {
        protected new IBrowser Browser = default!;
        protected new IBrowserContext Context = default!;
        protected new  IPage Page = default!;

        [SetUp]
        public async Task Setup()
        {
            Browser = await Playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
                SlowMo = 50
            });
            Context = await Browser.NewContextAsync();
            Page = await Context.NewPageAsync();
        }

        [TearDown]
        public async Task TearDown()
        {
            await Context.CloseAsync();
            await Browser.CloseAsync();
        }
    }
}
