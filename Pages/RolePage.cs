using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using System.Threading.Tasks;

namespace PlaywrightTests.Pages
{
    public class RolePage
    {
        private readonly IPage _page;

        public RolePage(IPage page) => _page = page;

        public async Task NavigateToRoles()
        {
            await _page.GetByRole(AriaRole.Link, new() { Name = "Roles" }).ClickAsync();
        }

        public async Task CreateRole(string roleName)
        {
            await _page.GetByRole(AriaRole.Button, new() { Name = "+" }).ClickAsync();
            await _page.GetByRole(AriaRole.Textbox, new() { Name = "* Role Name Role Name:" }).FillAsync(roleName);
            await _page.GetByRole(AriaRole.Button, new() { Name = "Save" }).ClickAsync();
            await _page.GetByRole(AriaRole.Button, new() { Name = "OK" }).ClickAsync();
        }

        public async Task AssignPermissions(string[] permissions)
        {
            foreach (var permission in permissions)
            {
                await _page.GetByRole(AriaRole.Cell, new() { Name = permission }).GetByRole(AriaRole.Checkbox).CheckAsync();
            }

             await _page.GetByRole(AriaRole.Cell, new() { Name = "Email Billing Information" }).Locator("div").ClickAsync();
            await _page.Locator("tr:nth-child(9) > td:nth-child(8)").ClickAsync(new LocatorClickOptions { Button = MouseButton.Right });
            await _page.GetByRole(AriaRole.Button, new() { Name = " Save" }).ClickAsync();
            await _page.GetByRole(AriaRole.Button, new() { Name = "OK" }).ClickAsync();
        }

            public async Task SelectRoleByName(string roleName)
        {
            // Click to open the dropdown
            await _page.Locator("#ddlRoles").ClickAsync();

            // Wait for the role option to be available
            await _page.WaitForSelectorAsync($"text={roleName}");

            // Click the role
            await _page.GetByText(roleName).ClickAsync();
        }


        public async Task RemovePermissionByTitleAsync(string permissionTitle)
    {
        // Locate checkbox using td[title] and checkbox input
         string selector = $"td[title='{permissionTitle}'] input[type='checkbox']";
        await _page.WaitForSelectorAsync(selector, new PageWaitForSelectorOptions { Timeout = 5000 });


         var checkbox = await _page.QuerySelectorAsync(selector);
        if (checkbox == null)
        {
            throw new Exception($"Checkbox with title '{permissionTitle}' not found.");
        }
        
            // If it's checked, uncheck it
        if (await checkbox.IsCheckedAsync())
        {
         await checkbox.UncheckAsync();
        }
        await _page.GetByRole(AriaRole.Button, new() { Name = " Save" }).ClickAsync();
        await _page.GetByRole(AriaRole.Button, new() { Name = "OK" }).ClickAsync();
        }
       
    }

}





























