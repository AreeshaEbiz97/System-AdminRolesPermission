Feature: Role Permission Management
  Validate permission creation, removal, and verification scenarios for a user role.

  Scenario: Full Role Permission Workflow
    Given I login as the admin with email "testerequis.ition@gmail.com" and password "Aa1234567"
    And I select the product "Intuit QuickBooks® Desktop" and log in to the company
    And I navigate to the Role Management page
    When I create a new role named "PermissionRole23" with all permissions
    And I assign this role to a user with email "permissiontestuser23@gmail.com"
    And I remove all view permissions from "PermissionRole23"
    And I login as the user "permissiontestuser23@gmail.com" and verify no view permissions are accessible
    And I login back as the admin and update the role to remove create permissions
    And I login as the user again and verify create options are not available
    And I login back as the admin and update the role to remove delete permissions
    And I login as the user and verify delete actions are not accessible
    And I login as admin and remove edit permissions
    Then the user should not be able to edit their profile or other users
