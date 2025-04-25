using NUnit.Framework;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using PlaywrightTests.Pages;

[Binding]

    public class RolePermissionSteps
    
{
    private readonly ScenarioContext _context;
    private readonly LoginPage loginPage;
    private readonly DashboardPage dashboardPage;
    private readonly RolePage rolePage;
    private readonly UserManagementPage userPage;

    public RolePermissionSteps(ScenarioContext context)
    {
        _context = context;
        var page = (Microsoft.Playwright.IPage)_context["Page"];
        loginPage = new LoginPage(page);
        dashboardPage = new DashboardPage(page);
        rolePage = new RolePage(page);
        userPage = new UserManagementPage(page);
    }

    [Given(@"I login as the admin with email ""(.*)"" and password ""(.*)""")]
    public async Task GivenILoginAsTheAdmin(string email, string password)
    {
        await loginPage.GoToLoginPage();
        await loginPage.Login(email, password);
    }

    [Given(@"I select the product ""(.*)"" and log in to the company")]
    public async Task GivenISelectProductAndLogin(string product)
    {
        await loginPage.SelectProductAsync(product);
        await loginPage.SelectMultiCompanyAndLoginAsync();
    }

    [Given(@"I navigate to the Role Management page")]
    public async Task GivenINavigateToRolePage()
    {
        await dashboardPage.NavigateMenu();
        await dashboardPage.RolePage();
    }

    [When(@"I create a new role named ""(.*)"" with all permissions")]
    public async Task WhenICreateNewRoleWithAllPermissions(string roleName)
    {
        await rolePage.CreateRole(roleName);
        await rolePage.AssignPermissions(new[] {
            "Access Users", "Access Roles", "Review Workflow Processes", "Review Company Settings",
            "Access Subscription Details", "Review sync with ERP", "View Billing Information",
            "Setup Users", "Setup Roles", "Design Workflows", "Modify Users", "Modify Roles",
            "Modify Subscription Details", "Delete Users", "Modify Company Settings",
            "Delete Roles", "Email User Details"
        });
    }

    [When(@"I assign this role to a user with email ""(.*)""")]
    public async Task WhenIAssignRoleToUser(string userEmail)
    {
        await dashboardPage.NavigateMenu();
        await dashboardPage.NavigateToAdminSettings();
        await userPage.NavigateToUserManagement();
        await userPage.AddUser("Permission", "TestUser23", userEmail, "Aa1234567", "PermissionRole23");
    }

    [When(@"I remove all view permissions from ""(.*)""")]
    public async Task WhenIRemoveViewPermissions(string roleName)
    {
        await dashboardPage.NavigateMenu();
        await dashboardPage.NavigateToAdminSettings();
        await dashboardPage.RolePage();
        await rolePage.SelectRoleByName(roleName);

        string[] viewPermissions = {
            "Access Users", "Access Roles", "Review Workflow Processes", "Review Company Settings",
            "Access Subscription Details", "Review sync with ERP", "View Billing Information"
        };

        foreach (var perm in viewPermissions)
        {
            await rolePage.RemovePermissionByTitleAsync(perm);
        }
        await dashboardPage.NavigateMenu();
        await dashboardPage.Logout();
    }

    [When(@"I login as the user ""(.*)"" and verify no view permissions are accessible")]
    public async Task WhenILoginAsUserAndVerifyNoViews(string userEmail)
    {
        await loginPage.Login(userEmail, "Aa1234567");
        await dashboardPage.NavigateMenu();
        await dashboardPage.Logout();
    }

    [When(@"I login back as the admin and update the role to remove create permissions")]
    public async Task WhenIRemoveCreatePermissions()
    {
        await loginPage.Login("testerequis.ition@gmail.com", "Aa1234567");
        await loginPage.SelectProductAsync("Intuit QuickBooks® Desktop");
        await loginPage.SelectMultiCompanyAndLoginAsync();
        await dashboardPage.NavigateMenu();
        await dashboardPage.NavigateToAdminSettings();
        await dashboardPage.RolePage();
        await rolePage.SelectRoleByName("PermissionRole23");

        await rolePage.AssignPermissions(new[] {
            "Access Users", "Review Workflow Processes", "Review Company Settings",
            "Access Subscription Details", "Review sync with ERP", "View Billing Information"
        });

        await rolePage.RemovePermissionByTitleAsync("Setup Users");
        await rolePage.RemovePermissionByTitleAsync("Setup Roles");
        await rolePage.RemovePermissionByTitleAsync("Design Workflows");
        await dashboardPage.Logout();
    }

    [When(@"I login as the user again and verify create options are not available")]
    public async Task WhenIVerifyCreatePermissions()
    {
        await loginPage.Login("permissiontestuser23@gmail.com", "Aa1234567");
        await dashboardPage.NavigateMenu();
        await dashboardPage.Logout();
    }

    [When(@"I login back as the admin and update the role to remove delete permissions")]
    public async Task WhenIRemoveDeletePermissions()
    {
        await loginPage.Login("testerequis.ition@gmail.com", "Aa1234567");
        await loginPage.SelectProductAsync("Intuit QuickBooks® Desktop");
        await loginPage.SelectMultiCompanyAndLoginAsync();
        await dashboardPage.NavigateMenu();
        await dashboardPage.NavigateToAdminSettings();
        await dashboardPage.RolePage();
        await rolePage.SelectRoleByName("PermissionRole23");

        await rolePage.AssignPermissions(new[] { "Setup Users", "Setup Roles", "Design Workflows" });
        await rolePage.RemovePermissionByTitleAsync("Delete Users");
        await rolePage.RemovePermissionByTitleAsync("Delete Roles");
        await dashboardPage.Logout();
    }

    [When(@"I login as the user and verify delete actions are not accessible")]
    public async Task WhenIVerifyDeletePermissions()
    {
        await loginPage.Login("permissiontestuser23@gmail.com", "Aa1234567");
        await dashboardPage.NavigateMenu();
        await dashboardPage.NavigateToAdminSettings();
        await dashboardPage.NavigateToUserManagement();
        await userPage.SelectUserByName("Permission TestUser23");
        await dashboardPage.Logout();
    }

    [When(@"I login as admin and remove edit permissions")]
    public async Task WhenIRemoveEditPermissions()
    {
        await loginPage.Login("testerequis.ition@gmail.com", "Aa1234567");
        await loginPage.SelectProductAsync("Intuit QuickBooks® Desktop");
        await loginPage.SelectMultiCompanyAndLoginAsync();
        await dashboardPage.NavigateMenu();
        await dashboardPage.NavigateToAdminSettings();
        await dashboardPage.RolePage();
        await rolePage.SelectRoleByName("PermissionRole23");
        await rolePage.AssignPermissions(new[] {
            "Modify Users", "Modify Roles", "Modify Subscription Details"
        });

        await rolePage.RemovePermissionByTitleAsync("Modify Users");
        await rolePage.RemovePermissionByTitleAsync("Modify Roles");
        await rolePage.RemovePermissionByTitleAsync("Modify Subscription Details");
        await dashboardPage.Logout();
    }

    [Then(@"the user should not be able to edit their profile or other users")]
    public async Task ThenUserShouldNotBeAbleToEdit()
    {
        await loginPage.Login("permissiontestuser23@gmail.com", "Aa1234567");
        await dashboardPage.NavigateMenu();
        await dashboardPage.NavigateToAdminSettings();
        await dashboardPage.NavigateToUserManagement();
        await userPage.SelectUserByName("Permission TestUser23");

        await Task.Delay(2000);
        await userPage.EditUserFirstName("Permission TestUser23", "PermissionTestUser234");

        await dashboardPage.Logout();
    }
}
