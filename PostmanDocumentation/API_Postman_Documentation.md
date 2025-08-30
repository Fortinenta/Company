# Company Solution API - Postman Documentation

This document provides a guide for testing the Company Solution Backend API using Postman. It includes details for each endpoint, example requests, and expected responses.

**Base URL:** `http://localhost:5075`

---

## 1. Pegawai (Employee) Endpoints

### 1.1 Get All Pegawai
- **URL:** `/api/pegawai`
- **Method:** `GET`
- **Description:** Retrieves a list of all employees.
- **Request:**
  ```
  GET http://localhost:5075/api/pegawai
  ```
- **Success Response (200 OK):**
  ```json
  [
    {
      "pegawaiID": 1,
      "namaLengkap": "Budi Santoso",
      "email": "budi.santoso@example.com",
      "nomorTelepon": "081234567890",
      "tanggalLahir": "1985-05-10T00:00:00",
      "alamat": "Jl. Merdeka No. 10",
      "cabangID": 1,
      "jabatanID": 1,
      "tanggalMasuk": "2015-01-15T00:00:00",
      "statusKontrak": "Permanent",
      "namaCabang": "Kantor Pusat",
      "namaJabatan": "Manager"
    },
    // ... more pegawai objects
  ]
  ```

### 1.2 Get Pegawai by ID
- **URL:** `/api/pegawai/{id}`
- **Method:** `GET`
- **Description:** Retrieves a single employee by their ID.
- **Request:**
  ```
  GET http://localhost:5075/api/pegawai/1
  ```
- **Success Response (200 OK):**
  ```json
  {
    "pegawaiID": 1,
    "namaLengkap": "Budi Santoso",
    "email": "budi.santoso@example.com",
    "nomorTelepon": "081234567890",
    "tanggalLahir": "1985-05-10T00:00:00",
    "alamat": "Jl. Merdeka No. 10",
    "cabangID": 1,
    "jabatanID": 1,
    "tanggalMasuk": "2015-01-15T00:00:00",
    "statusKontrak": "Permanent",
    "namaCabang": "Kantor Pusat",
    "namaJabatan": "Manager"
  }
  ```
- **Error Response (404 Not Found):** If employee with ID is not found.

### 1.3 Create New Pegawai
- **URL:** `/api/pegawai`
- **Method:** `POST`
- **Description:** Creates a new employee record.
- **Request Body (application/json):**
  ```json
  {
    "namaLengkap": "Nama Pegawai Baru",
    "tanggalLahir": "1990-01-01T00:00:00",
    "alamat": "Jl. Contoh No. 1",
    "nomorTelepon": "081234567899",
    "email": "baru@example.com",
    "tanggalMasuk": "2023-01-01T00:00:00",
    "statusKontrak": "Contract",
    "cabangID": 1,
    "jabatanID": 2
  }
  ```
- **Success Response (201 Created):**
  ```json
  {
    "pegawaiID": 11, // New ID generated
    "namaLengkap": "Nama Pegawai Baru",
    "email": "baru@example.com",
    "nomorTelepon": "081234567899",
    "tanggalLahir": "1990-01-01T00:00:00",
    "alamat": "Jl. Contoh No. 1",
    "cabangID": 1,
    "jabatanID": 2,
    "tanggalMasuk": "2023-01-01T00:00:00",
    "statusKontrak": "Contract",
    "namaCabang": "Kantor Pusat",
    "namaJabatan": "Software Engineer"
  }
  ```
- **Error Response (400 Bad Request):** If validation fails (e.g., missing required fields).

### 1.4 Update Existing Pegawai
- **URL:** `/api/pegawai/{id}`
- **Method:** `PUT`
- **Description:** Updates an existing employee record.
- **Request Body (application/json):**
  ```json
  {
    "pegawaiID": 1, // Must match ID in URL
    "namaLengkap": "Budi Santoso Updated",
    "tanggalLahir": "1985-05-10T00:00:00",
    "alamat": "Jl. Merdeka No. 10 Updated",
    "nomorTelepon": "081234567890",
    "email": "budi.santoso@example.com",
    "tanggalMasuk": "2015-01-15T00:00:00",
    "statusKontrak": "Permanent",
    "cabangID": 1,
    "jabatanID": 1
  }
  ```
- **Success Response (204 No Content):**
- **Error Response (400 Bad Request):** If ID in URL and body do not match or validation fails.
- **Error Response (404 Not Found):** If employee with ID is not found.

### 1.5 Delete Pegawai
- **URL:** `/api/pegawai/{id}`
- **Method:** `DELETE`
- **Description:** Deletes an employee record by ID.
- **Request:**
  ```
  DELETE http://localhost:5075/api/pegawai/1
  ```
- **Success Response (204 No Content):**
- **Error Response (404 Not Found):** If employee with ID is not found.

### 1.6 Search Pegawai
- **URL:** `/api/pegawai/search?nama={nama}`
- **Method:** `GET`
- **Description:** Searches for employees by name.
- **Request:**
  ```
  GET http://localhost:5075/api/pegawai/search?nama=Budi
  ```
- **Success Response (200 OK):** (Same as Get All Pegawai, filtered)

---

## 2. Cabang (Branch) Endpoints

### 2.1 Get All Cabang
- **URL:** `/api/cabang`
- **Method:** `GET`
- **Description:** Retrieves a list of all branches.
- **Request:**
  ```
  GET http://localhost:5075/api/cabang
  ```
- **Success Response (200 OK):**
  ```json
  [
    {
      "cabangID": 1,
      "namaCabang": "Kantor Pusat",
      "alamat": "Jl. Jend. Sudirman Kav. 52-53",
      "kota": "Jakarta Selatan",
      "kodePos": "12190"
    },
    // ... more cabang objects
  ]
  ```

### 2.2 Get Cabang by ID
- **URL:** `/api/cabang/{id}`
- **Method:** `GET`
- **Description:** Retrieves a single branch by its ID.
- **Request:**
  ```
  GET http://localhost:5075/api/cabang/1
  ```
- **Success Response (200 OK):**
  ```json
  {
    "cabangID": 1,
    "namaCabang": "Kantor Pusat",
    "alamat": "Jl. Jend. Sudirman Kav. 52-53",
    "kota": "Jakarta Selatan",
    "kodePos": "12190"
  }
  ```
- **Error Response (404 Not Found):** If branch with ID is not found.

### 2.3 Create New Cabang
- **URL:** `/api/cabang`
- **Method:** `POST`
- **Description:** Creates a new branch record.
- **Request Body (application/json):**
  ```json
  {
    "namaCabang": "Cabang Baru",
    "alamat": "Jl. Baru No. 1",
    "kota": "Kota Baru",
    "kodePos": "12345"
  }
  ```
- **Success Response (201 Created):**
  ```json
  {
    "cabangID": 11, // New ID generated
    "namaCabang": "Cabang Baru",
    "alamat": "Jl. Baru No. 1",
    "kota": "Kota Baru",
    "kodePos": "12345"
  }
  ```
- **Error Response (400 Bad Request):** If validation fails.

### 2.4 Update Existing Cabang
- **URL:** `/api/cabang/{id}`
- **Method:** `PUT`
- **Description:** Updates an existing branch record.
- **Request Body (application/json):**
  ```json
  {
    "cabangID": 1, // Must match ID in URL
    "namaCabang": "Kantor Pusat Updated",
    "alamat": "Jl. Jend. Sudirman Kav. 52-53 Updated",
    "kota": "Jakarta Selatan",
    "kodePos": "12190"
  }
  ```
- **Success Response (204 No Content):**
- **Error Response (400 Bad Request):** If ID in URL and body do not match or validation fails.
- **Error Response (404 Not Found):** If branch with ID is not found.

### 2.5 Delete Cabang
- **URL:** `/api/cabang/{id}`
- **Method:** `DELETE`
- **Description:** Deletes a branch record by ID.
- **Request:**
  ```
  DELETE http://localhost:5075/api/cabang/1
  ```
- **Success Response (204 No Content):**
- **Error Response (404 Not Found):** If branch with ID is not found.

---

## 3. Jabatan (Position) Endpoints

### 3.1 Get All Jabatan
- **URL:** `/api/jabatan`
- **Method:** `GET`
- **Description:** Retrieves a list of all job positions.
- **Request:**
  ```
  GET http://localhost:5075/api/jabatan
  ```
- **Success Response (200 OK):**
  ```json
  [
    {
      "jabatanID": 1,
      "namaJabatan": "Manager",
      "deskripsi": "Manages a team or department."
    },
    // ... more jabatan objects
  ]
  ```

### 3.2 Get Jabatan by ID
- **URL:** `/api/jabatan/{id}`
- **Method:** `GET`
- **Description:** Retrieves a single job position by its ID.
- **Request:**
  ```
  GET http://localhost:5075/api/jabatan/1
  ```
- **Success Response (200 OK):**
  ```json
  {
    "jabatanID": 1,
    "namaJabatan": "Manager",
    "deskripsi": "Manages a team or department."
  }
  ```
- **Error Response (404 Not Found):** If position with ID is not found.

### 3.3 Create New Jabatan
- **URL:** `/api/jabatan`
- **Method:** `POST`
- **Description:** Creates a new job position record.
- **Request Body (application/json):**
  ```json
  {
    "namaJabatan": "Jabatan Baru",
    "deskripsi": "Deskripsi jabatan baru."
  }
  ```
- **Success Response (201 Created):**
  ```json
  {
    "jabatanID": 11, // New ID generated
    "namaJabatan": "Jabatan Baru",
    "deskripsi": "Deskripsi jabatan baru."
  }
  ```
- **Error Response (400 Bad Request):** If validation fails.

### 3.4 Update Existing Jabatan
- **URL:** `/api/jabatan/{id}`
- **Method:** `PUT`
- **Description:** Updates an existing job position record.
- **Request Body (application/json):**
  ```json
  {
    "jabatanID": 1, // Must match ID in URL
    "namaJabatan": "Manager Updated",
    "deskripsi": "Manages a team or department. (Updated)"
  }
  ```
- **Success Response (204 No Content):**
- **Error Response (400 Bad Request):** If ID in URL and body do not match or validation fails.
- **Error Response (404 Not Found):** If position with ID is not found.

### 3.5 Delete Jabatan
- **URL:** `/api/jabatan/{id}`
- **Method:** `DELETE`
- **Description:** Deletes a job position record by ID.
- **Request:**
  ```
  DELETE http://localhost:5075/api/jabatan/1
  ```
- **Success Response (204 No Content):**
- **Error Response (404 Not Found):** If position with ID is not found.

---

## 4. Report Endpoints

### 4.1 Get Pegawai Report (View)
- **URL:** `/api/report/pegawaireport`
- **Method:** `GET`
- **Description:** Retrieves a comprehensive report of employees including branch and position details, based on `vw_PegawaiReport` view.
- **Request:**
  ```
  GET http://localhost:5075/api/report/pegawaireport
  ```
- **Success Response (200 OK):** (Same structure as Get All Pegawai)

### 4.2 Get Pegawai by Contract Status (Stored Procedure)
- **URL:** `/api/report/pegawaibystatus?status={status}`
- **Method:** `GET`
- **Description:** Retrieves employees filtered by their contract status using `sp_GetPegawaiByContract` stored procedure.
- **Request:**
  ```
  GET http://localhost:5075/api/report/pegawaibystatus?status=Permanent
  ```
- **Success Response (200 OK):** (Same structure as Get All Pegawai, filtered)

### 4.3 Import Pegawai Data
- **URL:** `/api/report/importpegawai`
- **Method:** `POST`
- **Description:** Imports a list of employee data. (Note: This is a basic implementation; for large imports, consider file upload or TVP).
- **Request Body (application/json):**
  ```json
  [
    {
      "namaLengkap": "Imported Employee 1",
      "tanggalLahir": "1990-01-01T00:00:00",
      "alamat": "Jl. Import No. 1",
      "nomorTelepon": "081111111111",
      "email": "import1@example.com",
      "tanggalMasuk": "2023-01-01T00:00:00",
      "statusKontrak": "Permanent",
      "cabangID": 1,
      "jabatanID": 1
    },
    {
      "namaLengkap": "Imported Employee 2",
      "tanggalLahir": "1991-02-02T00:00:00",
      "alamat": "Jl. Import No. 2",
      "nomorTelepon": "082222222222",
      "email": "import2@example.com",
      "tanggalMasuk": "2023-02-02T00:00:00",
      "statusKontrak": "Contract",
      "cabangID": 2,
      "jabatanID": 2
    }
  ]
  ```
- **Success Response (200 OK):**
  ```json
  "Import successful."
  ```
- **Error Response (400 Bad Request):** If validation fails.
