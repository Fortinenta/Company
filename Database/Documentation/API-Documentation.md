# API Documentation

This document provides detailed documentation for the CompanyAPI endpoints. The API is currently under development.

## Base URL
`http://localhost:<port>/api`

---

## Pegawai Controller

**Base Path**: `/api/pegawai`

### GET /api/pegawai
- **Description**: Retrieves a list of all employees.
- **Response**: `200 OK` - A JSON array of employee objects.

### GET /api/pegawai/{id}
- **Description**: Retrieves a specific employee by their ID.
- **Response**: `200 OK` - A JSON object of the employee.

### POST /api/pegawai
- **Description**: Creates a new employee.
- **Request Body**: A JSON object representing the new employee.
- **Response**: `201 Created` - The created employee object.

### PUT /api/pegawai/{id}
- **Description**: Updates an existing employee.
- **Request Body**: A JSON object with the updated employee data.
- **Response**: `204 No Content`.

### DELETE /api/pegawai/{id}
- **Description**: Deletes an employee by their ID.
- **Response**: `204 No Content`.

---

## Cabang Controller

**Base Path**: `/api/cabang`

_(Endpoints for CRUD operations on branches will be documented here.)_

---

## Jabatan Controller

**Base Path**: `/api/jabatan`

_(Endpoints for CRUD operations on job positions will be documented here.)_

---

## Report Controller

**Base Path**: `/api/report`

_(Endpoints for reporting and dashboards will be documented here.)_
