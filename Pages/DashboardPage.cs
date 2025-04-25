using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using System.Threading.Tasks;

namespace PlaywrightTests.Pages
{
    public class DashboardPage
    {
        private readonly IPage _page;

        public DashboardPage(IPage page) => _page = page;

        public async Task NavigateMenu()
        {
            var menuButton = _page.Locator("#menuimage");
            await menuButton.WaitForAsync();
            await menuButton.ClickAsync();
        }
        public async Task NavigateToAdminSettings()
        {
        // try{
        await _page.GetByRole(AriaRole.Link, new() { Name = "Admin & Settings" }).ClickAsync();
    //     try{} catch (TimeoutException )
    //     {
    //     Console.WriteLine("Admin & Settings link was not found within the expected time");
    //     }
    //     }

    //     catch
    // {
    //     // Just swallow the exception and move on
    // //     Console.WriteLine("Could not find or click 'Admin & Settings'. Continuing test...");
    // }
        }

        public async Task RolePage()
        {
            await _page.GotoAsync("https://qaerequisition.e-bizsoft.net/Pages/Setups/Roles.aspx");

        }
        public async Task NavigateToUserManagement()
        {
            await NavigateMenu();
            await _page.GetByRole(AriaRole.Link, new() { Name = "User Management" }).ClickAsync();
        }
        public async Task Logout()
        {
            await _page.Locator("#menuimage").ClickAsync();
            await _page.GetByRole(AriaRole.Link, new() { Name = "Logout" }).ClickAsync();
        }
    }
}
