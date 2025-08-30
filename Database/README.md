# Database Project for CompanySolution

This folder contains all the necessary scripts and documentation for the CompanySolution database.

## Overview

The database is designed to store information about employees, company branches, and job positions. It serves as the data backbone for the `CompanyAPI` and `CompanyWeb` applications.

## Folder Structure

-   `/Scripts`: Contains all SQL scripts required to build and populate the database.
    -   `01-CreateTables.sql`: Creates the main tables.
    -   `02-SampleData.sql`: Inserts sample data for testing and development.
    -   `03-StoredProcedures.sql`: Contains stored procedures for complex queries.
    -   `04-Views.sql`: Contains views for reporting.
-   `/Documentation`: Contains detailed documentation about the database and related processes.
    -   `DatabaseSchema.md`: ERD and schema details.
    -   `API-Documentation.md`: Placeholder for API endpoint documentation.
    -   `DeploymentGuide.md`: Instructions for production deployment.

## Development Environment Setup

To set up the database for a local development environment, follow these steps:

1.  **Ensure you have SQL Server installed** (SQL Server Express or Developer edition is recommended).
2.  **Create a new database** in your local SQL Server instance (e.g., `CompanySolution_Dev`).
3.  **Run the scripts** located in the `/Scripts` folder in the specified order (`01` to `04`).
4.  **Update the connection string** in the `appsettings.Development.json` file of the `CompanyAPI` project to point to your local database.

    ```json
    "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Database=CompanySolution_Dev;Trusted_Connection=True;MultipleActiveResultSets=true"
    }
    ```
