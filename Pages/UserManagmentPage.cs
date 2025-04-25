using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using System.Threading.Tasks;



namespace PlaywrightTests.Pages
{
    public class UserManagementPage
    {
        private readonly IPage _page;

        public UserManagementPage(IPage page) => _page = page;

        public async Task NavigateToUserManagement()
        {
            await _page.GetByRole(AriaRole.Link, new() { Name = "User Management" }).ClickAsync();
        }

        public async Task AddUser(string firstName, string lastName, string email, string password, string role)
        {
            await _page.GetByRole(AriaRole.Button, new() { Name = "Add New" }).ClickAsync();
            await _page.GetByRole(AriaRole.Textbox, new() { Name = "First Name" }).FillAsync(firstName);
            await _page.GetByRole(AriaRole.Textbox, new() { Name = "Last Name" }).FillAsync(lastName);
            await _page.GetByRole(AriaRole.Textbox, new() { Name = "Username / Email" }).FillAsync(email);
            await _page.GetByRole(AriaRole.Textbox, new() { Name = "Password", Exact = true }).FillAsync(password);
            await _page.GetByRole(AriaRole.Textbox, new() { Name = "Confirm Password" }).FillAsync(password);

            await _page.Locator("#ddlDepartments").Filter(new() { HasText = "Select Departments" }).First.ClickAsync();
            await _page.GetByRole(AriaRole.Option, new() { Name = "Purchasing" }).Locator("span").ClickAsync();
            await _page.GetByText("Purchasing Search ×").ClickAsync();

            await _page.Locator("#ddlRoles").ClickAsync();
            await _page.GetByRole(AriaRole.Option, new() { Name = role }).Locator("span").First.ClickAsync();

            await _page.GetByRole(AriaRole.Button, new() { Name = " Save" }).ClickAsync();
            await _page.GetByRole(AriaRole.Button, new() { Name = "OK" }).ClickAsync();
        }


            public async Task SelectUserByName(string userName)
        {
            // Wait for the dropdown to be visible
            await _page.Locator("#ddlUser").WaitForAsync();

            // Select by visible text (label)
            await _page.SelectOptionAsync("#ddlUser", new SelectOptionValue { Label = userName });
    }


        public async Task EditUserFirstName(string existingEmail, string newFirstName)
{
    // Select user by Email from dropdown
    await _page.Locator("#ddlUser").SelectOptionAsync(new SelectOptionValue { Label = existingEmail });

    // Wait for the first name textbox to be visible
    await _page.GetByRole(AriaRole.Textbox, new() { Name = "First Name" }).WaitForAsync();

    // Clear and fill the new first name
    await _page.GetByRole(AriaRole.Textbox, new() { Name = "First Name" }).FillAsync(newFirstName);

    // Click Save and then OK
    await _page.GetByRole(AriaRole.Button, new() { Name = " Save" }).ClickAsync();
    await _page.GetByRole(AriaRole.Button, new() { Name = "OK" }).ClickAsync();
}
    }
}
