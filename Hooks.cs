using Microsoft.Playwright;
using TechTalk.SpecFlow;

namespace Tests
{
    [Binding]
    public class Hooks
    {
        private readonly ScenarioContext _scenarioContext;

        public Hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public async Task BeforeScenario()
        {
            var playwright = await Microsoft.Playwright.Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
            var context = await browser.NewContextAsync();
            var page = await context.NewPageAsync();

            // Store the Playwright objects in the ScenarioContext for access across tests
            _scenarioContext["Playwright"] = playwright;
            _scenarioContext["Browser"] = browser;
            _scenarioContext["Page"] = page;
            _scenarioContext["Context"] = context;
        }

        [AfterScenario]
        public async Task AfterScenario()
        {
            // Retrieve and close the Playwright objects after the test scenario
            var browser = (IBrowser)_scenarioContext["Browser"];
            var playwright = (IPlaywright)_scenarioContext["Playwright"];
            var context = (IBrowserContext)_scenarioContext["Context"];

            await context.CloseAsync();
            await browser.CloseAsync();
            playwright.Dispose();
        }
    }
}
