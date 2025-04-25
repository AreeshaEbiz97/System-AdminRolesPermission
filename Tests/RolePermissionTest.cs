// using NUnit.Framework;
// using PlaywrightTests.Pages;

// namespace PlaywrightTests.Tests
// {
//     public class RolePermissionTest : BaseTest
//     {
//         [Test]
//         public async Task RolePermissionScenario()
//         {
//             var loginPage = new LoginPage(Page);
//             var dashboard = new DashboardPage(Page);
//             var rolePage = new RolePage(Page);
//             var userPage = new UserManagementPage(Page);
//             var userManagementPage = new UserManagementPage(Page);
//             var email1 = "testerequis.ition@gmail.com";
//             var Password1 = "Aa1234567";
//             var Product1 = "Intuit QuickBooks® Desktop";
//             // var Product2 = "Standalone";
//             // var Product3 = "Intuit QuickBooks® Online";
//             // Login to admin User and create a role with all permissions
//             await loginPage.GoToLoginPage();
//             await loginPage.Login(email1, Password1);
//             await loginPage.SelectProductAsync(Product1);
//             // await loginPage.SelectProductAsync(Product2);
//             // await loginPage.SelectProductAsync(Product3);
//             await loginPage.SelectMultiCompanyAndLoginAsync();
//             await dashboard.NavigateMenu();
//             await dashboard.RolePage();
//             // Create a new role with all permissions
//             await rolePage.CreateRole("PermissionRole23");

//             string[] permissionsTRX = {
//                 "Access Users", 
//                 "Access Roles", 
//                 "Review Workflow Processes",
//                  "Review Company Settings",
//                 "Access Subscription Details", 
//                 "Review sync with ERP",
//                  "View Billing Information",
//                   "Setup Users",
//                 "Setup Roles", 
//                 "Design Workflows", 
//                 "Modify Users", 
//                 "Modify Roles",
//                  "Modify Subscription Details",
//                  "Delete Users", "Modify Company Settings", "Delete Roles", "Email User Details"
//             };

//              string[] permissionsTXO = {
//                 "Access Users", 
//                 "Access Roles", 
//                 "Review Workflow Processes",
//                  "Review Company Settings",
//                 "Access Subscription Details", 
//                 "Review sync with ERP",
//                  "View Billing Information",
//                   "Setup Users",
//                 "Setup Roles", 
//                 "Design Workflows", 
//                 "Modify Users", 
//                 "Modify Roles",
//                  "Modify Subscription Details",
//                  "Delete Users", "Modify Company Settings", "Delete Roles", "Email User Details"
//             };

//              string[] permissionsStD = {
//                 "Access Users", 
//                 "Access Roles", 
//                 "Review Workflow Processes",
//                  "Review Company Settings",
//                 "Access Subscription Details", 
//                 "Review sync with ERP",
//                  "View Billing Information",
//                   "Setup Users",
//                 "Setup Roles", 
//                 "Design Workflows", 
//                 "Modify Users", 
//                 "Modify Roles",
//                  "Modify Subscription Details",
//                  "Delete Users", "Modify Company Settings", "Delete Roles", "Email User Details"
//             };

//             if (Product1 == "Intuit QuickBooks® Desktop")
//             {
//                 await rolePage.AssignPermissions(permissionsTRX);
//             }
//             else if (Product1 == "Standalone")
//             {
//                 await rolePage.AssignPermissions(permissionsStD);
//             }
//             else if (Product1 == "Intuit QuickBooks® Online")
//             {
//                 await rolePage.AssignPermissions(permissionsTXO);
//             }
//             else
//             {
//                 throw new Exception("Invalid product selected.");
//             }                                                               
           
            
//             await dashboard.NavigateMenu();
//             await dashboard.NavigateToAdminSettings();
//             // Create a new user and assign the role to the user
//             await userPage.NavigateToUserManagement();
//             await userPage.AddUser("Permission", "TestUser23", "permissiontestuser23@gmail.com", "Aa1234567", "PermissionRole23");

//             // await dashboard.Logout();


//             // Remove the permissions of view 
//             // await loginPage.Login("permissiontestuser23@gmail.com", "Aa1234567");
//             await dashboard.NavigateMenu();
//             await dashboard.NavigateToAdminSettings();
//             await dashboard.RolePage();
//             await rolePage.SelectRoleByName("PermissionRole23");
//             await rolePage.RemovePermissionByTitleAsync("Access Users");
//             await rolePage.RemovePermissionByTitleAsync("Access Roles");
//             await rolePage.RemovePermissionByTitleAsync("Review Workflow Processes");
//             await rolePage.RemovePermissionByTitleAsync("Review Company Settings");
//             await rolePage.RemovePermissionByTitleAsync("Access Subscription Details");
//             // if (Product1 == "Intuit QuickBooks® Desktop")
//             // {
               
//             await rolePage.RemovePermissionByTitleAsync("Review sync with ERP");
//             // }
            
//             await rolePage.RemovePermissionByTitleAsync("View Billing Information");
//             await dashboard.NavigateMenu();
//             await Task .Delay(2000);
//             await dashboard.Logout();

//         // Login as the new user and verify that the user has no permission of view 
//             await loginPage.Login("permissiontestuser23@gmail.com", "Aa1234567");
//             await dashboard.NavigateMenu();
//             // await dashboard.NavigateToAdminSettings();
//             // Assert.Fail("Setting page is visible.");
//             // await Task .Delay(2000);
//             await dashboard.Logout();

//             // Assign permission of view and remove permission or create 
//             await loginPage.Login("testerequis.ition@gmail.com", "Aa1234567");
//             await loginPage.SelectProductAsync("Intuit QuickBooks® Desktop");
//             await loginPage.SelectMultiCompanyAndLoginAsync();
//             await dashboard.NavigateMenu();
//             await dashboard.NavigateToAdminSettings();
//             await dashboard.RolePage();
//             await rolePage.SelectRoleByName("PermissionRole23");
           
//             string[] permissionsset1 = new[] { "Access Users","Review Workflow Processes", "Review Company Settings","Access Subscription Details"
//             , "Access Subscription Details", "Review sync with ERP", "View Billing Information" };
//             await rolePage.AssignPermissions(permissionsTRX);
//             await rolePage.RemovePermissionByTitleAsync("Setup Users");
//             await rolePage.RemovePermissionByTitleAsync("Setup Roles");
//             await rolePage.RemovePermissionByTitleAsync("Design Workflows");
//             await dashboard.NavigateMenu();
//             await dashboard.Logout();
            
//             // verify create permission
//             await loginPage.Login("permissiontestuser23@gmail.com", "Aa1234567");
//             await dashboard.NavigateMenu();
//             // await dashboard.NavigateToAdminSettings();  
//             await dashboard.Logout();


//             // Assign permission of create and remove permission of delete
//             await loginPage.Login("testerequis.ition@gmail.com", "Aa1234567");
//             await loginPage.SelectProductAsync("Intuit QuickBooks® Desktop");
//             await loginPage.SelectMultiCompanyAndLoginAsync();
//             await Task.Delay(2000);
//             await dashboard.NavigateMenu();
//             await Task.Delay(2000);
//             await dashboard.NavigateToAdminSettings();
//             await dashboard.RolePage();
//             await rolePage.SelectRoleByName("PermissionRole23");
//             string[] permissionsset2 = new[] { "Setup Users","Setup Roles", "Design Workflows" };
//             await rolePage.AssignPermissions(permissionsTRX);
//             await rolePage.RemovePermissionByTitleAsync("Delete Users");
//             await rolePage.RemovePermissionByTitleAsync("Delete Roles");
//             await Task .Delay(2000);
//             await dashboard.NavigateMenu();
//             await Task .Delay(2000);
//             await dashboard.Logout();
            

//             // Verfiy create permission and Delete permission
//             await loginPage.Login("permissiontestuser23@gmail.com", "Aa1234567");
//             await dashboard.NavigateMenu();
//             await dashboard.NavigateToAdminSettings();
//             await dashboard.RolePage();
//             await dashboard.NavigateMenu();
//             await dashboard.NavigateToAdminSettings();
//             await dashboard.NavigateToUserManagement();
//             await userPage.SelectUserByName("Permission TestUser23");
//             await dashboard.NavigateMenu();
//             await dashboard.Logout();




//             // Remove Permission Edited 
//             await loginPage.Login("testerequis.ition@gmail.com", "Aa1234567");
//             await loginPage.SelectProductAsync("Intuit QuickBooks® Desktop");
//             await loginPage.SelectMultiCompanyAndLoginAsync();
//             await dashboard.NavigateMenu();
//             await dashboard.NavigateToAdminSettings();
//             await dashboard.RolePage();
//             await rolePage.SelectRoleByName("PermissionRole23");
//             await rolePage.AssignPermissions(permissionsTRX);
//             await rolePage.RemovePermissionByTitleAsync("Modify Users");
//             await rolePage.RemovePermissionByTitleAsync("Modify Roles");
//             await rolePage.RemovePermissionByTitleAsync("Modify Subscription Details");
//             await dashboard.NavigateMenu();
//             await dashboard.Logout();


//             // Login as the new user and verify that the user has no permission of Edited 
//             await loginPage.Login("permissiontestuser23@gmail.com", "Aa1234567");
//             await dashboard.NavigateMenu();
//             await dashboard.NavigateToAdminSettings();
//             await dashboard.RolePage();
//             await dashboard.NavigateMenu();
//             await dashboard.NavigateToAdminSettings();
//             await dashboard.NavigateToUserManagement();
//             await userPage.SelectUserByName("Permission TestUser23");
//             await Task .Delay(2000);
//             await userPage.EditUserFirstName("Permission TestUser23", "PermissionTestUser234");
//             await dashboard.NavigateMenu();
//             await dashboard.Logout();

//         }
//     }
// }
    