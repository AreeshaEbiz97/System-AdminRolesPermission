using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using System.Threading.Tasks;


namespace PlaywrightTests.Pages
{
    public class LoginPage
    {
        private readonly IPage _page;

        public LoginPage(IPage page) => _page = page;

        public async Task GoToLoginPage() =>
            await _page.GotoAsync("https://qaerequisition.e-bizsoft.net/Login.aspx");

        public async Task Login(string email, string password)
        {
            await _page.GetByRole(AriaRole.Textbox, new() { Name = "Email Address" }).FillAsync(email);
            await _page.GetByRole(AriaRole.Textbox, new() { Name = "Password" }).FillAsync(password);
            await _page.GetByRole(AriaRole.Button, new() { Name = "Sign In" }).ClickAsync();
        }

       public async Task SelectProductAsync(string product)
{
    await _page.Locator("#cboProductSelection").SelectOptionAsync(new[] { product });
    await _page.GetByRole(AriaRole.Button, new() { Name = "Sign In" }).ClickAsync();



    
}

public async Task SelectMultiCompanyAndLoginAsync()
{
    await _page.GetByRole(AriaRole.Button, new() { Name = "Sign In" }).ClickAsync();
    await _page.SelectOptionAsync("#cboMultiCompany", new[] { "6588 single company" });
    await _page.GetByRole(AriaRole.Button, new() { Name = "Sign In" }).ClickAsync();
}


    }
}
