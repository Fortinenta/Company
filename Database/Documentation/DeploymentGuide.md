# Deployment Guide

This guide provides instructions for deploying the CompanySolution database and applications (CompanyAPI, CompanyWeb) to a production environment using SQL Server and IIS.

## Part 1: Database Deployment

1.  **Prepare the Database Server**:
    *   Ensure you have a SQL Server instance running and accessible.
    *   Create a new, empty database (e.g., `CompanySolutionDB`).
    *   Create a SQL login with `db_owner` permissions on the new database.

2.  **Run the SQL Scripts**:
    *   Open SQL Server Management Studio (SSMS) and connect to your database server.
    *   Execute the following scripts from the `Database/Scripts/` folder in order:
        1.  `01-CreateTables.sql` - This will create the required table structures.
        2.  `02-SampleData.sql` - (Optional) This will populate the tables with initial data.
        3.  `03-StoredProcedures.sql` - This will create the necessary stored procedures.
        4.  `04-Views.sql` - This will create the views for reporting.

3.  **Update Connection Strings**:
    *   Update the `ConnectionStrings` section in the `appsettings.Production.json` files for both `CompanyAPI` and `CompanyWeb` to point to the newly created production database.

## Part 2: Application Deployment to IIS

### Prerequisites

*   Windows Server with IIS enabled.
*   .NET 9 Hosting Bundle installed. You can download it from the official Microsoft website.

### Steps for CompanyAPI

1.  **Publish the Application**:
    *   In Visual Studio, right-click the `CompanyAPI` project and select `Publish`.
    *   Choose `Folder` as the publish target and specify a local folder path.
    *   Click `Publish`. This will compile the application and place the necessary files in the target folder.

2.  **Configure IIS**:
    *   Open IIS Manager.
    *   In the `Connections` pane, right-click `Sites` and select `Add Website`.
    *   Enter a site name (e.g., `company-api`).
    *   Set the `Physical path` to the folder where you published the `CompanyAPI` application.
    *   Assign a port (e.g., `8081`) or configure bindings with a hostname.
    *   Click `OK`.

3.  **Configure Application Pool**:
    *   Go to `Application Pools`.
    *   Find the pool associated with your new site.
    *   Right-click it, select `Advanced Settings`, and ensure the `.NET CLR version` is set to `No Managed Code` (as it's a Core application).

### Steps for CompanyWeb

1.  **Publish the Application**:
    *   Follow the same publishing steps as for `CompanyAPI`, but for the `CompanyWeb` project.

2.  **Configure IIS**:
    *   Create another new website in IIS (e.g., `company-web`).
    *   Set the `Physical path` to the folder where you published the `CompanyWeb` application.
    *   Assign a different port (e.g., `80`) or configure bindings.

3.  **Verify API URL**:
    *   Ensure the `appsettings.Production.json` in the `CompanyWeb` published files contains the correct URL for the `CompanyAPI`.

4.  **Final Verification**:
    *   Browse to the URL of your `CompanyWeb` application to ensure it loads correctly and can communicate with the `CompanyAPI`.
