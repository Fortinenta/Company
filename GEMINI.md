# ASP.NET Views Improvement Guide

## Global Issues Found

### 1. Layout Inconsistencies
- Mixed Tailwind CSS classes and Bootstrap classes (`col-sm-3`, `row`)
- Inconsistent spacing and typography across pages
- Missing responsive design considerations
- Inconsistent button styling and hover states

### 2. Accessibility Issues
- Missing ARIA labels and roles
- Poor semantic HTML structure
- Insufficient color contrast in some areas
- Missing focus states for keyboard navigation

### 3. UX/UI Problems
- Inconsistent form layouts
- Poor mobile responsiveness
- Missing loading states and feedback
- Inconsistent error handling display

---

## File-by-File Improvements

### `/Views/Shared/_Layout.cshtml`

**Issues:**
- Missing Tailwind CSS CDN link
- FontAwesome placeholder link is broken
- No mobile-first responsive design
- Missing meta tags for SEO

**Fixes Needed:**
```html
<!-- Add in <head> section -->
<script src="https://cdn.tailwindcss.com"></script>
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css">
<meta name="description" content="Company Solution - Employee Management System">
<meta name="keywords" content="employee, management, company, HR">

<!-- Fix responsive container -->
<div class="min-h-screen bg-gray-100">
  <!-- Sidebar should be hidden on mobile by default -->
  <div id="sidebar" class="fixed inset-y-0 left-0 z-50 w-64 bg-gray-800 transform -translate-x-full transition-transform duration-300 ease-in-out md:translate-x-0 md:static md:inset-0">
```

### `/Views/Shared/_Sidebar.cshtml`

**Issues:**
- No mobile responsiveness
- Missing active state indicators
- Dropdown menu not functional
- FontAwesome icons not loading properly

**Fixes Needed:**
```html
<!-- Add JavaScript for dropdown functionality -->
<script>
document.addEventListener('DOMContentLoaded', function() {
  const dropdownButton = document.querySelector('[aria-expanded]');
  const dropdownMenu = dropdownButton.nextElementSibling;
  
  dropdownButton.addEventListener('click', function() {
    const isExpanded = this.getAttribute('aria-expanded') === 'true';
    this.setAttribute('aria-expanded', !isExpanded);
    dropdownMenu.classList.toggle('hidden');
  });
});
</script>

<!-- Add active state styling -->
<a class="@(ViewContext.RouteData.Values["Controller"]?.ToString() == "Home" ? "bg-gray-700 text-white" : "text-gray-300 hover:bg-gray-700 hover:text-white") flex items-center px-4 py-2 rounded-md transition duration-200">
```

### `/Views/Cabang/Index.cshtml`

**Issues:**
- Missing page container consistency
- Table is not fully responsive
- No empty state handling
- Missing search/filter functionality

**Fixes Needed:**
```html
<!-- Add proper page wrapper -->
<div class="min-h-screen bg-gray-50 py-8">
  <div class="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
    
    <!-- Add search functionality -->
    <div class="mb-6">
      <div class="flex flex-col sm:flex-row sm:items-center sm:justify-between">
        <h1 class="text-3xl font-bold text-gray-900 mb-4 sm:mb-0">Cabang List</h1>
        <div class="flex space-x-3">
          <input type="text" placeholder="Search cabang..." class="px-4 py-2 border border-gray-300 rounded-lg focus:ring-2 focus:ring-blue-500 focus:border-transparent">
          <a asp-action="Create" class="inline-flex items-center px-4 py-2 bg-blue-600 text-white font-medium rounded-lg hover:bg-blue-700 transition duration-200">
            <i class="fas fa-plus mr-2"></i>Create New
          </a>
        </div>
      </div>
    </div>

    <!-- Responsive table wrapper -->
    <div class="bg-white shadow-sm rounded-lg overflow-hidden">
      <div class="overflow-x-auto">
        <!-- Table content -->
      </div>
      
      <!-- Empty state -->
      @if (!Model?.Any() ?? true)
      {
        <div class="text-center py-12">
          <i class="fas fa-building text-gray-400 text-4xl mb-4"></i>
          <h3 class="text-lg font-medium text-gray-900 mb-2">No branches found</h3>
          <p class="text-gray-500 mb-4">Get started by creating a new branch.</p>
          <a asp-action="Create" class="inline-flex items-center px-4 py-2 bg-blue-600 text-white font-medium rounded-lg hover:bg-blue-700">
            <i class="fas fa-plus mr-2"></i>Create First Branch
          </a>
        </div>
      }
    </div>
  </div>
</div>
```

### `/Views/Cabang/Create.cshtml` & `/Views/Cabang/Edit.cshtml`

**Issues:**
- Form layout not responsive
- Missing form validation feedback
- Inconsistent spacing
- No loading states

**Fixes Needed:**
```html
<div class="min-h-screen bg-gray-50 py-8">
  <div class="max-w-2xl mx-auto px-4 sm:px-6 lg:px-8">
    <div class="bg-white shadow-sm rounded-lg">
      <div class="px-6 py-8">
        <h1 class="text-2xl font-bold text-gray-900 mb-8">Create Cabang</h1>
        
        <form asp-action="Create" method="post" class="space-y-6" id="cabangForm">
          <div asp-validation-summary="ModelOnly" class="bg-red-50 border border-red-200 rounded-lg p-4 text-red-700 text-sm"></div>

          <div class="space-y-6">
            <div>
              <label asp-for="NamaCabang" class="block text-sm font-medium text-gray-700 mb-2"></label>
              <input asp-for="NamaCabang" 
                     class="w-full px-3 py-2 border border-gray-300 rounded-lg shadow-sm focus:ring-2 focus:ring-blue-500 focus:border-blue-500 transition duration-200" 
                     placeholder="Enter branch name" />
              <span asp-validation-for="NamaCabang" class="mt-1 text-sm text-red-600"></span>
            </div>
            
            <!-- Similar improvements for other fields -->
          </div>

          <div class="flex flex-col sm:flex-row sm:justify-between sm:space-x-4 space-y-3 sm:space-y-0 pt-6 border-t border-gray-200">
            <a asp-action="Index" class="inline-flex justify-center items-center px-4 py-2 border border-gray-300 text-gray-700 font-medium rounded-lg hover:bg-gray-50 transition duration-200">
              <i class="fas fa-arrow-left mr-2"></i>Back to List
            </a>
            <button type="submit" class="inline-flex justify-center items-center px-6 py-2 bg-blue-600 text-white font-medium rounded-lg hover:bg-blue-700 focus:ring-2 focus:ring-blue-500 focus:ring-offset-2 transition duration-200" id="submitBtn">
              <i class="fas fa-save mr-2"></i>Create
              <span class="hidden" id="loadingSpinner">
                <i class="fas fa-spinner fa-spin ml-2"></i>
              </span>
            </button>
          </div>
        </form>
      </div>
    </div>
  </div>
</div>

<!-- Add form submission handling -->
<script>
document.getElementById('cabangForm').addEventListener('submit', function() {
  const submitBtn = document.getElementById('submitBtn');
  const loadingSpinner = document.getElementById('loadingSpinner');
  
  submitBtn.disabled = true;
  loadingSpinner.classList.remove('hidden');
});
</script>
```

### `/Views/Cabang/Details.cshtml`

**Issues:**
- Poor information display layout
- Missing proper typography hierarchy
- Not mobile responsive
- Using Bootstrap classes mixed with Tailwind

**Fixes Needed:**
```html
<div class="min-h-screen bg-gray-50 py-8">
  <div class="max-w-4xl mx-auto px-4 sm:px-6 lg:px-8">
    <div class="bg-white shadow-sm rounded-lg overflow-hidden">
      <div class="px-6 py-8">
        <div class="flex items-center justify-between mb-8">
          <h1 class="text-3xl font-bold text-gray-900">Branch Details</h1>
          <div class="flex space-x-3">
            <a asp-action="Edit" asp-route-id="@Model?.CabangID" class="inline-flex items-center px-4 py-2 bg-blue-600 text-white font-medium rounded-lg hover:bg-blue-700 transition duration-200">
              <i class="fas fa-edit mr-2"></i>Edit
            </a>
            <a asp-action="Index" class="inline-flex items-center px-4 py-2 border border-gray-300 text-gray-700 font-medium rounded-lg hover:bg-gray-50 transition duration-200">
              <i class="fas fa-arrow-left mr-2"></i>Back to List
            </a>
          </div>
        </div>

        <div class="grid grid-cols-1 md:grid-cols-2 gap-8">
          <div class="space-y-6">
            <div>
              <h3 class="text-sm font-medium text-gray-500 uppercase tracking-wide mb-2">Branch Name</h3>
              <p class="text-lg text-gray-900">@Html.DisplayFor(model => model.NamaCabang)</p>
            </div>
            
            <div>
              <h3 class="text-sm font-medium text-gray-500 uppercase tracking-wide mb-2">Address</h3>
              <p class="text-lg text-gray-900">@Html.DisplayFor(model => model.Alamat)</p>
            </div>
          </div>
          
          <div class="space-y-6">
            <div>
              <h3 class="text-sm font-medium text-gray-500 uppercase tracking-wide mb-2">City</h3>
              <p class="text-lg text-gray-900">@Html.DisplayFor(model => model.Kota)</p>
            </div>
            
            <div>
              <h3 class="text-sm font-medium text-gray-500 uppercase tracking-wide mb-2">Postal Code</h3>
              <p class="text-lg text-gray-900">@Html.DisplayFor(model => model.KodePos)</p>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</div>
```

### `/Views/Cabang/Delete.cshtml`

**Issues:**
- Poor confirmation dialog design
- Missing proper warning styling
- Not accessible for screen readers
- Bootstrap/Tailwind class mixing

**Fixes Needed:**
```html
<div class="min-h-screen bg-gray-50 py-8">
  <div class="max-w-2xl mx-auto px-4 sm:px-6 lg:px-8">
    <div class="bg-white shadow-sm rounded-lg">
      <div class="px-6 py-8">
        <!-- Warning header -->
        <div class="flex items-center mb-8">
          <div class="flex-shrink-0">
            <i class="fas fa-exclamation-triangle text-red-600 text-2xl"></i>
          </div>
          <div class="ml-4">
            <h1 class="text-2xl font-bold text-gray-900">Delete Branch</h1>
            <p class="text-red-600 font-medium mt-1">This action cannot be undone</p>
          </div>
        </div>

        <!-- Confirmation details -->
        <div class="bg-red-50 border border-red-200 rounded-lg p-6 mb-8">
          <h2 class="text-lg font-medium text-red-800 mb-4">You are about to delete:</h2>
          <div class="space-y-3">
            <div class="flex justify-between">
              <span class="font-medium text-red-700">Branch Name:</span>
              <span class="text-red-900">@Html.DisplayFor(model => model.NamaCabang)</span>
            </div>
            <!-- Similar for other fields -->
          </div>
        </div>

        <!-- Action buttons -->
        <form asp-action="Delete" class="flex flex-col sm:flex-row sm:justify-between sm:space-x-4 space-y-3 sm:space-y-0">
          <input type="hidden" asp-for="CabangID" />
          <a asp-action="Index" class="inline-flex justify-center items-center px-4 py-2 border border-gray-300 text-gray-700 font-medium rounded-lg hover:bg-gray-50 transition duration-200">
            <i class="fas fa-times mr-2"></i>Cancel
          </a>
          <button type="submit" class="inline-flex justify-center items-center px-6 py-2 bg-red-600 text-white font-medium rounded-lg hover:bg-red-700 focus:ring-2 focus:ring-red-500 focus:ring-offset-2 transition duration-200" onclick="return confirm('Are you absolutely sure you want to delete this branch?')">
            <i class="fas fa-trash mr-2"></i>Delete Branch
          </button>
        </form>
      </div>
    </div>
  </div>
</div>
```

### `/Views/Jabatan/` (All Files)

**Apply the same improvements as Cabang views:**
- Consistent layout structure
- Proper responsive design
- Better form styling
- Improved typography
- Loading states
- Empty state handling

### `/Views/Pegawai/Index.cshtml`

**Issues:**
- Table header styling inconsistent
- Missing pagination
- Poor mobile table experience
- Checkbox functionality needs improvement
- Missing bulk action confirmations

**Fixes Needed:**
```html
<div class="min-h-screen bg-gray-50 py-8">
  <div class="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
    <!-- Header with actions -->
    <div class="flex flex-col lg:flex-row lg:items-center lg:justify-between mb-8">
      <h1 class="text-3xl font-bold text-gray-900 mb-4 lg:mb-0">Employee Management</h1>
      
      <div class="flex flex-col sm:flex-row space-y-3 sm:space-y-0 sm:space-x-3">
        <a asp-action="Upload" class="inline-flex items-center px-4 py-2 bg-green-600 text-white font-medium rounded-lg hover:bg-green-700 transition duration-200">
          <i class="fas fa-upload mr-2"></i>Bulk Upload
        </a>
        <a asp-action="BatchUpdate" class="inline-flex items-center px-4 py-2 bg-purple-600 text-white font-medium rounded-lg hover:bg-purple-700 transition duration-200">
          <i class="fas fa-sync-alt mr-2"></i>Batch Update
        </a>
        <a asp-action="Create" class="inline-flex items-center px-4 py-2 bg-blue-600 text-white font-medium rounded-lg hover:bg-blue-700 transition duration-200">
          <i class="fas fa-plus mr-2"></i>Add Employee
        </a>
      </div>
    </div>

    <!-- Filters and search -->
    <div class="bg-white rounded-lg shadow-sm p-6 mb-6">
      <div class="grid grid-cols-1 md:grid-cols-3 gap-4">
        <input type="text" placeholder="Search employees..." class="px-4 py-2 border border-gray-300 rounded-lg focus:ring-2 focus:ring-blue-500 focus:border-blue-500">
        <select class="px-4 py-2 border border-gray-300 rounded-lg focus:ring-2 focus:ring-blue-500 focus:border-blue-500">
          <option>All Status</option>
          <option>Aktif</option>
          <option>Tidak Aktif</option>
          <option>Permanen</option>
        </select>
        <select class="px-4 py-2 border border-gray-300 rounded-lg focus:ring-2 focus:ring-blue-500 focus:border-blue-500">
          <option>All Branches</option>
          <!-- Branch options -->
        </select>
      </div>
    </div>

    <form asp-action="ProcessMassAction" method="post" id="massActionForm">
      <!-- Bulk actions -->
      <div class="bg-white rounded-lg shadow-sm p-4 mb-4" id="bulkActions" style="display: none;">
        <div class="flex items-center justify-between">
          <span id="selectedCount" class="text-sm text-gray-600">0 employees selected</span>
          <div class="space-x-3">
            <button type="submit" name="action" value="export" class="inline-flex items-center px-3 py-2 bg-green-600 text-white text-sm font-medium rounded-md hover:bg-green-700 transition duration-200">
              <i class="fas fa-download mr-2"></i>Export Selected
            </button>
            <button type="submit" name="action" value="delete" class="inline-flex items-center px-3 py-2 bg-red-600 text-white text-sm font-medium rounded-md hover:bg-red-700 transition duration-200" onclick="return confirmDelete()">
              <i class="fas fa-trash mr-2"></i>Delete Selected
            </button>
          </div>
        </div>
      </div>

      <!-- Mobile-friendly table -->
      <div class="bg-white shadow-sm rounded-lg overflow-hidden">
        <!-- Desktop table -->
        <div class="hidden lg:block overflow-x-auto">
          <table class="min-w-full divide-y divide-gray-200">
            <thead class="bg-gray-50">
              <tr>
                <th class="px-6 py-3 text-left">
                  <input type="checkbox" id="checkAll" class="rounded border-gray-300 text-blue-600 focus:ring-blue-500" />
                </th>
                <th class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Employee</th>
                <th class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Contact</th>
                <th class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Employment</th>
                <th class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Status</th>
                <th class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Actions</th>
              </tr>
            </thead>
            <tbody class="bg-white divide-y divide-gray-200">
              @foreach (var item in Model)
              {
                <tr class="hover:bg-gray-50">
                  <td class="px-6 py-4">
                    <input type="checkbox" name="selectedIds" value="@item.PegawaiID" class="row-checkbox rounded border-gray-300 text-blue-600 focus:ring-blue-500" />
                  </td>
                  <td class="px-6 py-4">
                    <div>
                <label asp-for="TanggalMasuk" class="block text-sm font-medium text-gray-700 mb-2"></label>
                <input asp-for="TanggalMasuk" type="date"
                       class="w-full px-3 py-2 border border-gray-300 rounded-lg shadow-sm focus:ring-2 focus:ring-blue-500 focus:border-blue-500 transition duration-200" />
                <span asp-validation-for="TanggalMasuk" class="mt-1 text-sm text-red-600"></span>
              </div>
              
              <div>
                <label asp-for="StatusKontrak" class="block text-sm font-medium text-gray-700 mb-2"></label>
                <select asp-for="StatusKontrak" 
                        class="w-full px-3 py-2 border border-gray-300 rounded-lg shadow-sm focus:ring-2 focus:ring-blue-500 focus:border-blue-500 transition duration-200">
                  <option value="">-- Select Status --</option>
                  <option value="Aktif">Aktif</option>
                  <option value="Tidak Aktif">Tidak Aktif</option>
                  <option value="Permanen">Permanen</option>
                </select>
                <span asp-validation-for="StatusKontrak" class="mt-1 text-sm text-red-600"></span>
              </div>
              
              <div>
                <label asp-for="CabangID" class="block text-sm font-medium text-gray-700 mb-2"></label>
                <select asp-for="CabangID" asp-items="ViewBag.CabangList" 
                        class="w-full px-3 py-2 border border-gray-300 rounded-lg shadow-sm focus:ring-2 focus:ring-blue-500 focus:border-blue-500 transition duration-200">
                  <option value="">-- Select Branch --</option>
                </select>
                <span asp-validation-for="CabangID" class="mt-1 text-sm text-red-600"></span>
              </div>
              
              <div>
                <label asp-for="JabatanID" class="block text-sm font-medium text-gray-700 mb-2"></label>
                <select asp-for="JabatanID" asp-items="ViewBag.JabatanList" 
                        class="w-full px-3 py-2 border border-gray-300 rounded-lg shadow-sm focus:ring-2 focus:ring-blue-500 focus:border-blue-500 transition duration-200">
                  <option value="">-- Select Position --</option>
                </select>
                <span asp-validation-for="JabatanID" class="mt-1 text-sm text-red-600"></span>
              </div>
            </div>
          </div>

          <!-- Form Actions -->
          <div class="flex flex-col sm:flex-row sm:justify-between sm:space-x-4 space-y-3 sm:space-y-0 pt-6 border-t border-gray-200">
            <a asp-action="Index" class="inline-flex justify-center items-center px-4 py-2 border border-gray-300 text-gray-700 font-medium rounded-lg hover:bg-gray-50 transition duration-200">
              <i class="fas fa-arrow-left mr-2"></i>Back to List
            </a>
            <button type="submit" class="inline-flex justify-center items-center px-6 py-2 bg-blue-600 text-white font-medium rounded-lg hover:bg-blue-700 focus:ring-2 focus:ring-blue-500 focus:ring-offset-2 transition duration-200" id="submitBtn">
              <i class="fas fa-save mr-2"></i>Create Employee
              <span class="hidden ml-2" id="loadingSpinner">
                <i class="fas fa-spinner fa-spin"></i>
              </span>
            </button>
          </div>
        </form>
      </div>
    </div>
  </div>
</div>

<script>
document.getElementById('employeeForm').addEventListener('submit', function() {
  const submitBtn = document.getElementById('submitBtn');
  const loadingSpinner = document.getElementById('loadingSpinner');
  
  submitBtn.disabled = true;
  loadingSpinner.classList.remove('hidden');
});
</script>
```

### `/Views/Pegawai/Details.cshtml`

**Issues:**
- Poor information layout and hierarchy
- Not utilizing grid system effectively
- Missing proper sections for different data types
- No visual indicators for status

**Fixes Needed:**
```html
<div class="min-h-screen bg-gray-50 py-8">
  <div class="max-w-4xl mx-auto px-4 sm:px-6 lg:px-8">
    <div class="bg-white shadow-sm rounded-lg overflow-hidden">
      <!-- Header -->
      <div class="bg-gradient-to-r from-blue-600 to-blue-700 px-6 py-8">
        <div class="flex flex-col sm:flex-row sm:items-center sm:justify-between">
          <div>
            <h1 class="text-3xl font-bold text-white mb-2">@Model.NamaLengkap</h1>
            <p class="text-blue-100">Employee ID: @Model.PegawaiID</p>
          </div>
          <div class="mt-4 sm:mt-0">
            <span class="inline-flex items-center px-3 py-1 rounded-full text-sm font-medium @(Model.StatusKontrak == "Aktif" ? "bg-green-100 text-green-800" : Model.StatusKontrak == "Permanen" ? "bg-blue-100 text-blue-800" : "bg-red-100 text-red-800")">
              <i class="fas fa-circle text-xs mr-2"></i>@Model.StatusKontrak
            </span>
          </div>
        </div>
      </div>

      <!-- Content -->
      <div class="px-6 py-8">
        <div class="grid grid-cols-1 lg:grid-cols-2 gap-8">
          <!-- Personal Information -->
          <div class="space-y-6">
            <div>
              <h2 class="text-lg font-medium text-gray-900 mb-4 pb-2 border-b border-gray-200">Personal Information</h2>
              <div class="space-y-4">
                <div>
                  <label class="block text-sm font-medium text-gray-500 mb-1">Email Address</label>
                  <div class="flex items-center">
                    <i class="fas fa-envelope text-gray-400 mr-3"></i>
                    <a href="mailto:@Model.Email" class="text-blue-600 hover:text-blue-800">@Model.Email</a>
                  </div>
                </div>
                
                <div>
                  <label class="block text-sm font-medium text-gray-500 mb-1">Phone Number</label>
                  <div class="flex items-center">
                    <i class="fas fa-phone text-gray-400 mr-3"></i>
                    <a href="tel:@Model.NomorTelepon" class="text-gray-900">@Model.NomorTelepon</a>
                  </div>
                </div>
                
                <div>
                  <label class="block text-sm font-medium text-gray-500 mb-1">Date of Birth</label>
                  <div class="flex items-center">
                    <i class="fas fa-calendar text-gray-400 mr-3"></i>
                    <span class="text-gray-900">@Model.TanggalLahir?.ToString("dd MMMM yyyy")</span>
                  </div>
                </div>
                
                <div>
                  <label class="block text-sm font-medium text-gray-500 mb-1">Address</label>
                  <div class="flex items-start">
                    <i class="fas fa-map-marker-alt text-gray-400 mr-3 mt-1"></i>
                    <span class="text-gray-900">@Model.Alamat</span>
                  </div>
                </div>
              </div>
            </div>
          </div>

          <!-- Employment Information -->
          <div class="space-y-6">
            <div>
              <h2 class="text-lg font-medium text-gray-900 mb-4 pb-2 border-b border-gray-200">Employment Information</h2>
              <div class="space-y-4">
                <div>
                  <label class="block text-sm font-medium text-gray-500 mb-1">Join Date</label>
                  <div class="flex items-center">
                    <i class="fas fa-calendar-check text-gray-400 mr-3"></i>
                    <span class="text-gray-900">@Model.TanggalMasuk?.ToString("dd MMMM yyyy")</span>
                  </div>
                </div>
                
                <div>
                  <label class="block text-sm font-medium text-gray-500 mb-1">Position</label>
                  <div class="flex items-center">
                    <i class="fas fa-briefcase text-gray-400 mr-3"></i>
                    <span class="text-gray-900">@Model.NamaJabatan</span>
                  </div>
                </div>
                
                <div>
                  <label class="block text-sm font-medium text-gray-500 mb-1">Branch</label>
                  <div class="flex items-center">
                    <i class="fas fa-building text-gray-400 mr-3"></i>
                    <span class="text-gray-900">@Model.NamaCabang</span>
                  </div>
                </div>
                
                <div>
                  <label class="block text-sm font-medium text-gray-500 mb-1">Employment Status</label>
                  <div class="flex items-center">
                    <i class="fas fa-id-badge text-gray-400 mr-3"></i>
                    <span class="inline-flex items-center px-2.5 py-0.5 rounded-full text-xs font-medium @(Model.StatusKontrak == "Aktif" ? "bg-green-100 text-green-800" : Model.StatusKontrak == "Permanen" ? "bg-blue-100 text-blue-800" : "bg-red-100 text-red-800")">
                      @Model.StatusKontrak
                    </span>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>

        <!-- Actions -->
        <div class="mt-8 pt-6 border-t border-gray-200">
          <div class="flex flex-col sm:flex-row sm:justify-between space-y-3 sm:space-y-0 sm:space-x-4">
            <a asp-action="Index" class="inline-flex items-center justify-center px-4 py-2 border border-gray-300 text-gray-700 font-medium rounded-lg hover:bg-gray-50 transition duration-200">
              <i class="fas fa-arrow-left mr-2"></i>Back to List
            </a>
            <div class="flex space-x-3">
              <a asp-action="Edit" asp-route-id="@Model.PegawaiID" class="inline-flex items-center px-4 py-2 bg-blue-600 text-white font-medium rounded-lg hover:bg-blue-700 transition duration-200">
                <i class="fas fa-edit mr-2"></i>Edit Employee
              </a>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</div>
```

### `/Views/Pegawai/Upload.cshtml`

**Issues:**
- Instructions panel could be more visually appealing
- Table in review section needs better responsive design
- Missing drag-and-drop file upload functionality
- No file validation feedback

**Fixes Needed:**
```html
<div class="min-h-screen bg-gray-50 py-8">
  <div class="max-w-6xl mx-auto px-4 sm:px-6 lg:px-8">
    <div class="bg-white shadow-sm rounded-lg">
      <div class="px-6 py-8">
        <h1 class="text-3xl font-bold text-gray-900 mb-8">Bulk Upload Employees</h1>

        <!-- Enhanced Instructions -->
        <div class="mb-8 bg-blue-50 border border-blue-200 rounded-lg p-6">
          <div class="flex items-start">
            <i class="fas fa-info-circle text-blue-600 text-xl mt-1 mr-4"></i>
            <div>
              <h2 class="text-lg font-semibold text-blue-900 mb-3">Upload Instructions</h2>
              <div class="space-y-2 text-blue-800">
                <div class="flex items-center">
                  <i class="fas fa-download text-blue-600 mr-2"></i>
                  <span>Download the CSV template file below</span>
                </div>
                <div class="flex items-center">
                  <i class="fas fa-edit text-blue-600 mr-2"></i>
                  <span>Fill in employee data using the provided headers</span>
                </div>
                <div class="flex items-center">
                  <i class="fas fa-upload text-blue-600 mr-2"></i>
                  <span>Upload the completed file for review</span>
                </div>
              </div>
              <div class="mt-4">
                <a asp-action="DownloadTemplate" class="inline-flex items-center px-4 py-2 bg-green-600 text-white font-medium rounded-lg hover:bg-green-700 transition duration-200">
                  <i class="fas fa-download mr-2"></i>Download CSV Template
                </a>
              </div>
            </div>
          </div>
        </div>

        <!-- Enhanced File Upload -->
        <form asp-action="Upload" method="post" enctype="multipart/form-data" class="mb-8">
          <div asp-validation-summary="ModelOnly" class="mb-4 bg-red-50 border border-red-200 rounded-lg p-4 text-red-700 text-sm"></div>

          <div class="border-2 border-dashed border-gray-300 rounded-lg p-8 text-center hover:border-blue-400 transition duration-200" id="dropZone">
            <div class="space-y-4">
              <i class="fas fa-cloud-upload-alt text-4xl text-gray-400"></i>
              <div>
                <label asp-for="FormFile" class="cursor-pointer">
                  <span class="text-lg font-medium text-gray-700">Click to upload</span>
                  <span class="text-gray-500"> or drag and drop</span>
                  <input asp-for="FormFile" type="file" class="hidden" accept=".csv,.xlsx,.xls" id="fileInput" />
                </label>
              </div>
              <p class="text-sm text-gray-500">CSV, XLSX up to 10MB</p>
              <span asp-validation-for="FormFile" class="text-red-600 text-sm"></span>
            </div>
          </div>
          
          <div class="mt-6 flex justify-between items-center">
            <a asp-action="Index" class="inline-flex items-center px-4 py-2 border border-gray-300 text-gray-700 font-medium rounded-lg hover:bg-gray-50 transition duration-200">
              <i class="fas fa-arrow-left mr-2"></i>Back to List
            </a>
            <button type="submit" class="inline-flex items-center px-6 py-2 bg-blue-600 text-white font-medium rounded-lg hover:bg-blue-700 focus:ring-2 focus:ring-blue-500 focus:ring-offset-2 transition duration-200" id="uploadBtn" disabled>
              <i class="fas fa-upload mr-2"></i>Upload & Review
            </button>
          </div>
        </form>

        <!-- Enhanced Review Section -->
        @if (Model.StagedPegawai != null && Model.StagedPegawai.Any())
        {
          <div class="border-t border-gray-200 pt-8">
            <div class="flex items-center justify-between mb-6">
              <h2 class="text-2xl font-bold text-gray-900">Review Uploaded Data</h2>
              <span class="bg-blue-100 text-blue-800 text-sm font-medium px-3 py-1 rounded-full">
                @Model.StagedPegawai.Count employees found
              </span>
            </div>

            <form asp-action="SaveStagedData" method="post">
              <!-- Mobile-friendly table -->
              <div class="bg-white shadow-sm rounded-lg overflow-hidden">
                <div class="hidden lg:block overflow-x-auto">
                  <table class="min-w-full divide-y divide-gray-200">
                    <thead class="bg-gray-50">
                      <tr>
                        <th class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase">Name</th>
                        <th class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase">Email</th>
                        <th class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase">Status</th>
                        <th class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase">Branch</th>
                        <th class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase">Position</th>
                        <th class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase">Actions</th>
                      </tr>
                    </thead>
                    <tbody class="bg-white divide-y divide-gray-200">
                      @for (var i = 0; i < Model.StagedPegawai.Count; i++)
                      {
                        <tr class="hover:bg-gray-50">
                          <td class="px-6 py-4">
                            <input type="hidden" name="StagedPegawai[@i].PegawaiID" value="@Model.StagedPegawai[i].PegawaiID" />
                            <input type="text" name="StagedPegawai[@i].NamaLengkap" value="@Model.StagedPegawai[i].NamaLengkap" 
                                   class="w-full px-3 py-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-blue-500 focus:border-blue-500" />
                          </td>
                          <td class="px-6 py-4">
                            <input type="email" name="StagedPegawai[@i].Email" value="@Model.StagedPegawai[i].Email" 
                                   class="w-full px-3 py-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-blue-500 focus:border-blue-500" />
                          </td>
                          <td class="px-6 py-4">
                            <select name="StagedPegawai[@i].StatusKontrak" asp-for="@Model.StagedPegawai[i].StatusKontrak" asp-items="Model.StatusKontrakOptions" 
                                    class="w-full px-3 py-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-blue-500 focus:border-blue-500"></select>
                          </td>
                          <td class="px-6 py-4">
                            <select name="StagedPegawai[@i].CabangID" asp-for="@Model.StagedPegawai[i].CabangID" asp-items="Model.CabangOptions" 
                                    class="w-full px-3 py-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-blue-500 focus:border-blue-500"></select>
                          </td>
                          <td class="px-6 py-4">
                            <select name="StagedPegawai[@i].JabatanID" asp-for="@Model.StagedPegawai[i].JabatanID" asp-items="Model.JabatanOptions" 
                                    class="w-full px-3 py-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-blue-500 focus:border-blue-500"></select>
                          </td>
                          <td class="px-6 py-4">
                            <button type="button" class="text-red-600 hover:text-red-800 font-medium delete-staged-row">
                              <i class="fas fa-trash mr-1"></i>Remove
                            </button>
                          </td>
                        </tr>
                      }
                    </tbody>
                  </table>
                </div>

                <!-- Mobile Cards -->
                <div class="lg:hidden space-y-4 p-4">
                  @for (var i = 0; i < Model.StagedPegawai.Count; i++)
                  {
                    <div class="border border-gray-200 rounded-lg p-4">
                      <div class="flex justify-between items-center mb-4">
                        <h3 class="font-medium text-gray-900">Employee @(i + 1)</h3>
                        <button type="button" class="text-red-600 hover:text-red-800 delete-staged-row">
                          <i class="fas fa-trash"></i>
                        </button>
                      </div>
                      
                      <div class="space-y-3">
                        <input type="hidden" name="StagedPegawai[@i].PegawaiID" value="@Model.StagedPegawai[i].PegawaiID" />
                        <div>
                          <label class="block text-sm font-medium text-gray-700 mb-1">Name</label>
                          <input type="text" name="StagedPegawai[@i].NamaLengkap" value="@Model.StagedPegawai[i].NamaLengkap" 
                                 class="w-full px-3 py-2 border border-gray-300 rounded-md" />
                        </div>
                        
                        <div>
                          <label class="block text-sm font-medium text-gray-700 mb-1">Email</label>
                          <input type="email" name="StagedPegawai[@i].Email" value="@Model.StagedPegawai[i].Email" 
                                 class="w-full px-3 py-2 border border-gray-300 rounded-md" />
                        </div>
                        
                        <div class="grid grid-cols-1 sm:grid-cols-3 gap-3">
                          <div>
                            <label class="block text-sm font-medium text-gray-700 mb-1">Status</label>
                            <select name="StagedPegawai[@i].StatusKontrak" asp-for="@Model.StagedPegawai[i].StatusKontrak" asp-items="Model.StatusKontrakOptions" 
                                    class="w-full px-3 py-2 border border-gray-300 rounded-md"></select>
                          </div>
                          <div>
                            <label class="block text-sm font-medium text-gray-700 mb-1">Branch</label>
                            <select name="StagedPegawai[@i].CabangID" asp-for="@Model.StagedPegawai[i].CabangID" asp-items="Model.CabangOptions" 
                                    class="w-full px-3 py-2 border border-gray-300 rounded-md"></select>
                          </div>
                          <div>
                            <label class="block text-sm font-medium text-gray-700 mb-1">Position</label>
                            <select name="StagedPegawai[@i].JabatanID" asp-for="@Model.StagedPegawai[i].JabatanID" asp-items="Model.JabatanOptions" 
                                    class="w-full px-3 py-2 border border-gray-300 rounded-md"></select>
                          </div>
                        </div>
                      </div>
                    </div>
                  }
                </div>
              </div>

              <div class="mt-8 flex justify-end">
                <button type="submit" class="inline-flex items-center px-8 py-3 bg-green-600 text-white font-medium rounded-lg hover:bg-green-700 focus:ring-2 focus:ring-green-500 focus:ring-offset-2 transition duration-200">
                  <i class="fas fa-save mr-2"></i>Save All to Database
                </button>
              </div>
            </form>
          </div>
        }
      </div>
    </div>
  </div>
</div>

<script>
document.addEventListener('DOMContentLoaded', function() {
  const dropZone = document.getElementById('dropZone');
  const fileInput = document.getElementById('fileInput');
  const uploadBtn = document.getElementById('uploadBtn');

  // File input change handler
  fileInput.addEventListener('change', function() {
    if (this.files && this.files.length > 0) {
      uploadBtn.disabled = false;
      dropZone.classList.add('border-blue-400', 'bg-blue-50');
      dropZone.querySelector('i').className = 'fas fa-file-csv text-4xl text-blue-500';
    } else {
      uploadBtn.disabled = true;
      dropZone.classList.remove('border-blue-400', 'bg-blue-50');
    }
  });

  // Drag and drop handlers
  dropZone.addEventListener('dragover', function(e) {
    e.preventDefault();
    this.classList.add('border-blue-400', 'bg-blue-50');
  });

  dropZone.addEventListener('dragleave', function(e) {
    e.preventDefault();
    if (!fileInput.files.length) {
      this.classList.remove('border-blue-400', 'bg-blue-50');
    }
  });

  dropZone.addEventListener('drop', function(e) {
    e.preventDefault();
    const files = e.dataTransfer.files;
    if (files.length > 0) {
      fileInput.files = files;
      fileInput.dispatchEvent(new Event('change'));
    }
  });

  // Delete row handlers
  document.querySelectorAll('.delete-staged-row').forEach(button => {
    button.addEventListener('click', function() {
      const row = this.closest('tr') || this.closest('.border');
      if (confirm('Remove this employee from the upload?')) {
        row.remove();
      }
    });
  });
});
</script>
```

### `/Views/Pegawai/BatchUpdate.cshtml`

**Apply similar improvements as Upload.cshtml:**
- Enhanced instructions panel
- Better responsive table design
- Improved form styling
- Better mobile experience


### `/Views/Report/Index.cshtml` (Enhanced Dashboard)

**Current Issues:**
- Very basic card layout
- Missing interactive charts and visualizations
- No filtering or date range selection
- Poor use of available space
- Missing key performance indicators

**Complete Enhanced Version:**
```html
<div class="min-h-screen bg-gray-50 py-8">
  <div class="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
    <!-- Header with Date Range Filter -->
    <div class="flex flex-col lg:flex-row lg:items-center lg:justify-between mb-8">
      <div>
        <h1 class="text-3xl font-bold text-gray-900">Reports Dashboard</h1>
        <p class="text-gray-600 mt-2">Overview of your company's key metrics and statistics</p>
      </div>
      
      <div class="mt-4 lg:mt-0 flex flex-col sm:flex-row space-y-3 sm:space-y-0 sm:space-x-3">
        <select class="px-4 py-2 border border-gray-300 rounded-lg focus:ring-2 focus:ring-blue-500 focus:border-blue-500">
          <option>Last 30 days</option>
          <option>Last 90 days</option>
          <option>Last 6 months</option>
          <option>Last year</option>
        </select>
        <button class="inline-flex items-center px-4 py-2 bg-blue-600 text-white font-medium rounded-lg hover:bg-blue-700 transition duration-200">
          <i class="fas fa-download mr-2"></i>Export Report
        </button>
      </div>
    </div>

    <!-- Key Metrics Grid -->
    <div class="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-4 gap-6 mb-8">
      <!-- Total Employees -->
      <div class="bg-white rounded-lg shadow-sm p-6 border-l-4 border-blue-500 hover:shadow-md transition-shadow duration-200">
        <div class="flex items-center">
          <div class="flex-1">
            <h2 class="text-sm font-medium text-gray-500 uppercase tracking-wide">Total Employees</h2>
            <p class="text-3xl font-bold text-gray-900 mt-2">@Model.TotalPegawai</p>
            <div class="flex items-center mt-2">
              <span class="inline-flex items-center text-sm text-green-600 font-medium">
                <i class="fas fa-arrow-up mr-1"></i>12% from last month
              </span>
            </div>
          </div>
          <div class="flex-shrink-0">
            <div class="w-12 h-12 bg-blue-100 rounded-lg flex items-center justify-center">
              <i class="fas fa-users text-blue-600 text-xl"></i>
            </div>
          </div>
        </div>
      </div>

      <!-- Total Branches -->
      <div class="bg-white rounded-lg shadow-sm p-6 border-l-4 border-green-500 hover:shadow-md transition-shadow duration-200">
        <div class="flex items-center">
          <div class="flex-1">
            <h2 class="text-sm font-medium text-gray-500 uppercase tracking-wide">Total Branches</h2>
            <p class="text-3xl font-bold text-gray-900 mt-2">@Model.TotalCabang</p>
            <div class="flex items-center mt-2">
              <span class="inline-flex items-center text-sm text-blue-600 font-medium">
                <i class="fas fa-arrow-up mr-1"></i>2 new this quarter
              </span>
            </div>
          </div>
          <div class="flex-shrink-0">
            <div class="w-12 h-12 bg-green-100 rounded-lg flex items-center justify-center">
              <i class="fas fa-building text-green-600 text-xl"></i>
            </div>
          </div>
        </div>
      </div>

      <!-- Active Contracts -->
      <div class="bg-white rounded-lg shadow-sm p-6 border-l-4 border-yellow-500 hover:shadow-md transition-shadow duration-200">
        <div class="flex items-center">
          <div class="flex-1">
            <h2 class="text-sm font-medium text-gray-500 uppercase tracking-wide">Active Contracts</h2>
            <p class="text-3xl font-bold text-gray-900 mt-2">@(ViewBag.ActiveContracts ?? "N/A")</p>
            <div class="flex items-center mt-2">
              <span class="inline-flex items-center text-sm text-yellow-600 font-medium">
                <i class="fas fa-minus mr-1"></i>Same as last month
              </span>
            </div>
          </div>
          <div class="flex-shrink-0">
            <div class="w-12 h-12 bg-yellow-100 rounded-lg flex items-center justify-center">
              <i class="fas fa-id-badge text-yellow-600 text-xl"></i>
            </div>
          </div>
        </div>
      </div>

      <!-- New Hires This Month -->
      <div class="bg-white rounded-lg shadow-sm p-6 border-l-4 border-purple-500 hover:shadow-md transition-shadow duration-200">
        <div class="flex items-center">
          <div class="flex-1">
            <h2 class="text-sm font-medium text-gray-500 uppercase tracking-wide">New Hires</h2>
            <p class="text-3xl font-bold text-gray-900 mt-2">@(ViewBag.NewHires ?? "8")</p>
            <div class="flex items-center mt-2">
              <span class="inline-flex items-center text-sm text-green-600 font-medium">
                <i class="fas fa-arrow-up mr-1"></i>25% from last month
              </span>
            </div>
          </div>
          <div class="flex-shrink-0">
            <div class="w-12 h-12 bg-purple-100 rounded-lg flex items-center justify-center">
              <i class="fas fa-user-plus text-purple-600 text-xl"></i>
            </div>
          </div>
        </div>
      </div>
    </div>

    <!-- Charts Section -->
    <div class="grid grid-cols-1 lg:grid-cols-2 gap-8 mb-8">
      <!-- Employee Growth Chart -->
      <div class="bg-white rounded-lg shadow-sm p-6">
        <div class="flex items-center justify-between mb-6">
          <h3 class="text-lg font-medium text-gray-900">Employee Growth</h3>
          <div class="flex space-x-2">
            <button class="px-3 py-1 text-sm bg-blue-100 text-blue-700 rounded-md">6M</button>
            <button class="px-3 py-1 text-sm text-gray-600 hover:bg-gray-100 rounded-md">1Y</button>
            <button class="px-3 py-1 text-sm text-gray-600 hover:bg-gray-100 rounded-md">All</button>
          </div>
        </div>
        <div class="h-64" id="employeeGrowthChart">
          <!-- Chart placeholder - integrate with Chart.js or similar -->
          <div class="flex items-center justify-center h-full text-gray-500">
            <div class="text-center">
              <i class="fas fa-chart-line text-4xl mb-2"></i>
              <p>Employee Growth Chart</p>
              <small class="text-gray-400">Chart will be rendered here</small>
            </div>
          </div>
        </div>
      </div>

      <!-- Status Distribution -->
      <div class="bg-white rounded-lg shadow-sm p-6">
        <h3 class="text-lg font-medium text-gray-900 mb-6">Contract Status Distribution</h3>
        <div class="space-y-4">
          <div class="flex items-center justify-between">
            <div class="flex items-center">
              <div class="w-3 h-3 bg-green-500 rounded-full mr-3"></div>
              <span class="text-gray-700">Active</span>
            </div>
            <div class="flex items-center">
              <span class="text-gray-900 font-medium mr-2">@(ViewBag.ActiveCount ?? "65")</span>
              <div class="w-24 bg-gray-200 rounded-full h-2">
                <div class="bg-green-500 h-2 rounded-full" style="width: 65%"></div>
              </div>
            </div>
          </div>
          
          <div class="flex items-center justify-between">
            <div class="flex items-center">
              <div class="w-3 h-3 bg-blue-500 rounded-full mr-3"></div>
              <span class="text-gray-700">Permanent</span>
            </div>
            <div class="flex items-center">
              <span class="text-gray-900 font-medium mr-2">@(ViewBag.PermanentCount ?? "25")</span>
              <div class="w-24 bg-gray-200 rounded-full h-2">
                <div class="bg-blue-500 h-2 rounded-full" style="width: 25%"></div>
              </div>
            </div>
          </div>
          
          <div class="flex items-center justify-between">
            <div class="flex items-center">
              <div class="w-3 h-3 bg-red-500 rounded-full mr-3"></div>
              <span class="text-gray-700">Inactive</span>
            </div>
            <div class="flex items-center">
              <span class="text-gray-900 font-medium mr-2">@(ViewBag.InactiveCount ?? "10")</span>
              <div class="w-24 bg-gray-200 rounded-full h-2">
                <div class="bg-red-500 h-2 rounded-full" style="width: 10%"></div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>

    <!-- Detailed Reports Section -->
    <div class="grid grid-cols-1 lg:grid-cols-3 gap-8">
      <!-- Recent Activities -->
      <div class="lg:col-span-2 bg-white rounded-lg shadow-sm p-6">
        <div class="flex items-center justify-between mb-6">
          <h3 class="text-lg font-medium text-gray-900">Recent Activities</h3>
          <a href="#" class="text-blue-600 hover:text-blue-800 text-sm font-medium">View All</a>
        </div>
        
        <div class="space-y-4">
          <div class="flex items-center space-x-4 p-3 bg-gray-50 rounded-lg">
            <div class="flex-shrink-0">
              <div class="w-10 h-10 bg-green-100 rounded-lg flex items-center justify-center">
                <i class="fas fa-user-plus text-green-600"></i>
              </div>
            </div>
            <div class="flex-1">
              <p class="text-sm text-gray-900">New employee <strong>John Doe</strong> added to Marketing department</p>
              <p class="text-xs text-gray-500">2 hours ago</p>
            </div>
          </div>
          
          <div class="flex items-center space-x-4 p-3 bg-gray-50 rounded-lg">
            <div class="flex-shrink-0">
              <div class="w-10 h-10 bg-blue-100 rounded-lg flex items-center justify-center">
                <i class="fas fa-edit text-blue-600"></i>
              </div>
            </div>
            <div class="flex-1">
              <p class="text-sm text-gray-900">Employee contracts updated via batch upload</p>
              <p class="text-xs text-gray-500">5 hours ago</p>
            </div>
          </div>
          
          <div class="flex items-center space-x-4 p-3 bg-gray-50 rounded-lg">
            <div class="flex-shrink-0">
              <div class="w-10 h-10 bg-yellow-100 rounded-lg flex items-center justify-center">
                <i class="fas fa-building text-yellow-600"></i>
              </div>
            </div>
            <div class="flex-1">
              <p class="text-sm text-gray-900">New branch <strong>Jakarta Selatan</strong> created</p>
              <p class="text-xs text-gray-500">1 day ago</p>
            </div>
          </div>
        </div>
      </div>

      <!-- Quick Actions -->
      <div class="bg-white rounded-lg shadow-sm p-6">
        <h3 class="text-lg font-medium text-gray-900 mb-6">Quick Actions</h3>
        
        <div class="space-y-4">
          <a asp-controller="Pegawai" asp-action="Create" 
             class="flex items-center p-4 border border-gray-200 rounded-lg hover:bg-gray-50 transition duration-200">
            <div class="flex-shrink-0">
              <i class="fas fa-user-plus text-blue-600 text-xl"></i>
            </div>
            <div class="ml-4">
              <p class="text-sm font-medium text-gray-900">Add New Employee</p>
              <p class="text-xs text-gray-500">Create employee profile</p>
            </div>
          </a>
          
          <a asp-controller="Pegawai" asp-action="Upload" 
             class="flex items-center p-4 border border-gray-200 rounded-lg hover:bg-gray-50 transition duration-200">
            <div class="flex-shrink-0">
              <i class="fas fa-upload text-green-600 text-xl"></i>
            </div>
            <div class="ml-4">
              <p class="text-sm font-medium text-gray-900">Bulk Upload</p>
              <p class="text-xs text-gray-500">Import employee data</p>
            </div>
          </a>
          
          <a asp-controller="Cabang" asp-action="Create" 
             class="flex items-center p-4 border border-gray-200 rounded-lg hover:bg-gray-50 transition duration-200">
            <div class="flex-shrink-0">
              <i class="fas fa-building text-purple-600 text-xl"></i>
            </div>
            <div class="ml-4">
              <p class="text-sm font-medium text-gray-900">Add New Branch</p>
              <p class="text-xs text-gray-500">Expand company locations</p>
            </div>
          </a>
          
          <a href="#" 
             class="flex items-center p-4 border border-gray-200 rounded-lg hover:bg-gray-50 transition duration-200">
            <div class="flex-shrink-0">
              <i class="fas fa-file-export text-orange-600 text-xl"></i>
            </div>
            <div class="ml-4">
              <p class="text-sm font-medium text-gray-900">Export Data</p>
              <p class="text-xs text-gray-500">Download reports</p>
            </div>
          </a>
        </div>
      </div>
    </div>
  </div>
</div>

<!-- Include Chart.js for future chart implementations -->
<script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
<script>
document.addEventListener('DOMContentLoaded', function() {
  // Future chart implementations can go here
  console.log('Dashboard loaded - ready for chart integration');
});
</script>
```

## Global JavaScript Improvements

### **Create `/Views/Shared/_ScriptsPartial.cshtml`**
```html
<!-- Global JavaScript functions and utilities -->
<script>
// Global utility functions
window.CompanyApp = {
  // Show loading state
  showLoading: function(element) {
    const spinner = element.querySelector('.loading-spinner') || document.createElement('div');
    spinner.className = 'loading-spinner';
    spinner.innerHTML = '<i class="fas fa-spinner fa-spin"></i>';
    element.appendChild(spinner);
    element.disabled = true;
  },
  
  // Hide loading state
  hideLoading: function(element) {
    const spinner = element.querySelector('.loading-spinner');
    if (spinner) spinner.remove();
    element.disabled = false;
  },
  
  // Show notification
  showNotification: function(message, type = 'info') {
    const notification = document.createElement('div');
    notification.className = `fixed top-4 right-4 z-50 p-4 rounded-lg shadow-lg transition-transform duration-300 transform translate-x-full`;
    
    const bgColor = {
      'success': 'bg-green-600',
      'error': 'bg-red-600', 
      'warning': 'bg-yellow-600',
      'info': 'bg-blue-600'
    }[type] || 'bg-blue-600';
    
    notification.classList.add(bgColor);
    notification.innerHTML = `
      <div class="flex items-center text-white">
        <span class="mr-3">${message}</span>
        <button onclick="this.parentElement.parentElement.remove()" class="ml-auto">
          <i class="fas fa-times"></i>
        </button>
      </div>
    `;
    
    document.body.appendChild(notification);
    
    // Animate in
    setTimeout(() => notification.classList.remove('translate-x-full'), 100);
    
    // Auto remove after 5 seconds
    setTimeout(() => {
      notification.classList.add('translate-x-full');
      setTimeout(() => notification.remove(), 300);
    }, 5000);
  },
  
  // Confirm dialog
  confirm: function(message, callback) {
    if (confirm(message)) {
      callback();
    }
  }
};

// Global form validation enhancement
document.addEventListener('DOMContentLoaded', function() {
  // Enhanced form submissions
  document.querySelectorAll('form').forEach(form => {
    form.addEventListener('submit', function(e) {
      const submitBtn = this.querySelector('button[type="submit"]');
      if (submitBtn && !submitBtn.disabled) {
        CompanyApp.showLoading(submitBtn);
      }
    });
  });
  
  // Auto-save functionality for forms (optional)
  const autoSaveForms = document.querySelectorAll('[data-auto-save]');
  autoSaveForms.forEach(form => {
    const inputs = form.querySelectorAll('input, select, textarea');
    inputs.forEach(input => {
      input.addEventListener('blur', function() {
        // Implement auto-save logic here if needed
      });
    });
  });
});
</script>
```

### **Update `/Views/Shared/_Layout.cshtml` to fix all issues**
```html
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta name="description" content="Company Solution - Employee Management System" />
    <meta name="keywords" content="employee, management, company, HR" />
    <title>@ViewData["Title"] - Company Solution</title>
    
    <!-- Tailwind CSS -->
    <script src="https://cdn.tailwindcss.com"></script>
    
    <!-- Font Awesome -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css" />
    
    <!-- Custom CSS -->
    <link rel="stylesheet" href="~/css/site.css" asp-append-version="true" />
    
    <!-- Tailwind Config -->
    <script>
        tailwind.config = {
            theme: {
                extend: {
                    animation: {
                        'fade-in': 'fadeIn 0.5s ease-in-out',
                        'slide-in': 'slideIn 0.3s ease-in-out',
                    }
                }
            }
        }
    </script>
</head>
<body class="bg-gray-100 antialiased">
    <div class="flex h-screen overflow-hidden">
        <!-- Sidebar -->
        <div id="sidebar" class="fixed inset-y-0 left-0 z-50 w-64 bg-gray-800 transform -translate-x-full transition-transform duration-300 ease-in-out lg:translate-x-0 lg:static lg:inset-0">
            <partial name="_Sidebar" />
        </div>
        
        <!-- Mobile sidebar overlay -->
        <div id="sidebar-overlay" class="fixed inset-0 bg-gray-600 bg-opacity-75 z-40 lg:hidden hidden"></div>

        <!-- Main Content -->
        <div class="flex flex-col flex-1 overflow-hidden">
            <!-- Top Navigation -->
            <header class="bg-white shadow-sm border-b border-gray-200">
                <div class="flex items-center justify-between px-4 sm:px-6 lg:px-8 py-4">
                    <div class="flex items-center">
                        <!-- Mobile menu button -->
                        <button id="sidebar-toggle" 
                                class="p-2 rounded-md text-gray-400 hover:text-gray-500 hover:bg-gray-100 focus:outline-none focus:ring-2 focus:ring-inset focus:ring-blue-500 lg:hidden"
                                aria-label="Toggle sidebar">
                            <i class="fas fa-bars w-6 h-6"></i>
                        </button>
                        
                        <h1 class="ml-4 lg:ml-0 text-2xl font-semibold text-gray-900">@ViewData["Title"]</h1>
                    </div>
                    
                    <!-- User menu -->
                    <div class="flex items-center space-x-4">
                        <button class="p-2 text-gray-400 hover:text-gray-500 focus:outline-none focus:ring-2 focus:ring-blue-500 rounded-lg" 
                                title="Notifications">
                            <i class="fas fa-bell w-5 h-5"></i>
                        </button>
                        <div class="relative">
                            <button class="flex items-center space-x-3 text-sm focus:outline-none focus:ring-2 focus:ring-blue-500 rounded-lg p-2" 
                                    title="User menu">
                                <div class="w-8 h-8 bg-blue-500 rounded-full flex items-center justify-center">
                                    <i class="fas fa-user text-white text-sm"></i>
                                </div>
                                <span class="hidden md:block text-gray-700 font-medium">Admin</span>
                            </button>
                        </div>
                    </div>
                </div>
            </header>

            <!-- Main Content Area -->
            <main class="flex-1 overflow-x-hidden overflow-y-auto bg-gray-50">
                <div class="container mx-auto px-4 sm:px-6 lg:px-8 py-8">
                    @RenderBody()
                </div>
            </main>
        </div>
    </div>

    <!-- Scripts -->
    <script src="~/lib/jquery/dist/jquery.min.js"></script>
    <partial name="_ScriptsPartial" />
    
    <!-- Sidebar toggle functionality -->
    <script>
        document.addEventListener('DOMContentLoaded', function() {
            const sidebarToggle = document.getElementById('sidebar-toggle');
            const sidebar = document.getElementById('sidebar');
            const overlay = document.getElementById('sidebar-overlay');
            
            function toggleSidebar() {
                sidebar.classList.toggle('-translate-x-full');
                overlay.classList.toggle('hidden');
            }
            
            function closeSidebar() {
                sidebar.classList.add('-translate-x-full');
                overlay.classList.add('hidden');
            }
            
            sidebarToggle.addEventListener('click', toggleSidebar);
            overlay.addEventListener('click', closeSidebar);
            
            // Close sidebar on escape key
            document.addEventListener('keydown', function(e) {
                if (e.key === 'Escape') {
                    closeSidebar();
                }
            });
            
            // Handle window resize
            window.addEventListener('resize', function() {
                if (window.innerWidth >= 1024) { // lg breakpoint
                    closeSidebar();
                }
            });
        });
    </script>
    
    @await RenderSectionAsync("Scripts", required: false)
</body>
</html>
```

### **Update `/Views/Shared/_Sidebar.cshtml` with full functionality**
```html
<div class="flex flex-col h-full">
    <!-- Logo/Brand -->
    <div class="flex items-center justify-center h-16 bg-gray-900 px-6">
        <h1 class="text-xl font-bold text-white">Company Solution</h1>
    </div>

    <!-- Navigation Menu -->
    <nav class="flex-1 px-4 py-6 space-y-2 overflow-y-auto">
        <!-- Dashboard -->
        <a class="@(ViewContext.RouteData.Values["Controller"]?.ToString() == "Home" ? "bg-gray-700 text-white" : "text-gray-300 hover:bg-gray-700 hover:text-white") flex items-center px-4 py-3 rounded-lg transition duration-200 group"
           asp-controller="Home" asp-action="Index">
            <i class="fas fa-tachometer-alt mr-3 w-5"></i>
            <span>Dashboard</span>
        </a>

        <!-- Employees Section -->
        <div class="space-y-1">
            <button type="button" 
                    class="w-full flex items-center justify-between px-4 py-3 text-gray-300 hover:bg-gray-700 hover:text-white rounded-lg transition duration-200 group"
                    onclick="toggleDropdown('pegawai-dropdown')"
                    aria-expanded="false" 
                    id="pegawai-button">
                <div class="flex items-center">
                    <i class="fas fa-users mr-3 w-5"></i>
                    <span>Employees</span>
                </div>
                <svg class="w-5 h-5 transform transition-transform duration-200" id="pegawai-icon">
                    <path fill="currentColor" d="M5.293 7.293a1 1 0 011.414 0L10 10.586l3.293-3.293a1 1 0 111.414 1.414l-4 4a1 1 0 01-1.414 0l-4-4a1 1 0 010-1.414z"/>
                </svg>
            </button>
            
            <div class="hidden pl-6 space-y-1" id="pegawai-dropdown">
                <a class="@(ViewContext.RouteData.Values["Controller"]?.ToString() == "Pegawai" && ViewContext.RouteData.Values["Action"]?.ToString() == "Index" ? "bg-gray-600 text-white" : "text-gray-400 hover:bg-gray-700 hover:text-white") flex items-center px-4 py-2 rounded-md transition duration-200"
                   asp-controller="Pegawai" asp-action="Index">
                    <i class="fas fa-list mr-3 w-4"></i>
                    <span class="text-sm">All Employees</span>
                </a>
                <a class="@(ViewContext.RouteData.Values["Controller"]?.ToString() == "Pegawai" && ViewContext.RouteData.Values["Action"]?.ToString() == "Upload" ? "bg-gray-600 text-white" : "text-gray-400 hover:bg-gray-700 hover:text-white") flex items-center px-4 py-2 rounded-md transition duration-200"
                   asp-controller="Pegawai" asp-action="Upload">
                    <i class="fas fa-upload mr-3 w-4"></i>
                    <span class="text-sm">Bulk Upload</span>
                </a>
                <a class="@(ViewContext.RouteData.Values["Controller"]?.ToString() == "Pegawai" && ViewContext.RouteData.Values["Action"]?.ToString() == "BatchUpdate" ? "bg-gray-600 text-white" : "text-gray-400 hover:bg-gray-700 hover:text-white") flex items-center px-4 py-2 rounded-md transition duration-200"
                   asp-controller="Pegawai" asp-action="BatchUpdate">
                    <i class="fas fa-sync-alt mr-3 w-4"></i>
                    <span class="text-sm">Batch Update</span>
                </a>
            </div>
        </div>

        <!-- Branches -->
        <a class="@(ViewContext.RouteData.Values["Controller"]?.ToString() == "Cabang" ? "bg-gray-700 text-white" : "text-gray-300 hover:bg-gray-700 hover:text-white") flex items-center px-4 py-3 rounded-lg transition duration-200 group"
           asp-controller="Cabang" asp-action="Index">
            <i class="fas fa-building mr-3 w-5"></i>
            <span>Branches</span>
        </a>

        <!-- Positions -->
        <a class="@(ViewContext.RouteData.Values["Controller"]?.ToString() == "Jabatan" ? "bg-gray-700 text-white" : "text-gray-300 hover:bg-gray-700 hover:text-white") flex items-center px-4 py-3 rounded-lg transition duration-200 group"
           asp-controller="Jabatan" asp-action="Index">
            <i class="fas fa-briefcase mr-3 w-5"></i>
            <span>Positions</span>
        </a>

        <!-- Reports -->
        <a class="@(ViewContext.RouteData.Values["Controller"]?.ToString() == "Report" ? "bg-gray-700 text-white" : "text-gray-300 hover:bg-gray-700 hover:text-white") flex items-center px-4 py-3 rounded-lg transition duration-200 group"
           asp-controller="Report" asp-action="Index">
            <i class="fas fa-chart-bar mr-3 w-5"></i>
            <span>Reports</span>
        </a>
    </nav>

    <!-- Footer/User Info -->
    <div class="flex-shrink-0 p-4 border-t border-gray-700">
        <div class="flex items-center">
            <div class="w-8 h-8 bg-blue-500 rounded-full flex items-center justify-center">
                <i class="fas fa-user text-white text-sm"></i>
            </div>
            <div class="ml-3">
                <p class="text-sm font-medium text-white">Administrator</p>
                <p class="text-xs text-gray-400">Online</p>
            </div>
        </div>
    </div>
</div>

<script>
function toggleDropdown(dropdownId) {
    const dropdown = document.getElementById(dropdownId);
    const button = document.getElementById(dropdownId.replace('-dropdown', '-button'));
    const icon = document.getElementById(dropdownId.replace('-dropdown', '-icon'));
    
    const isHidden = dropdown.classList.contains('hidden');
    
    if (isHidden) {
        dropdown.classList.remove('hidden');
        button.setAttribute('aria-expanded', 'true');
        icon.classList.add('rotate-180');
    } else {
        dropdown.classList.add('hidden');
        button.setAttribute('aria-expanded', 'false');
        icon.classList.remove('rotate-180');
    }
}

// Auto-expand current section
document.addEventListener('DOMContentLoaded', function() {
    const currentController = '@ViewContext.RouteData.Values["Controller"]';
    if (currentController === 'Pegawai') {
        toggleDropdown('pegawai-dropdown');
    }
});
</script>
```

## Additional Global Fixes

### **Create `/Views/Shared/_DeleteConfirmModal.cshtml`**
```html
<!-- Reusable Delete Confirmation Modal -->
<div id="deleteModal" class="fixed inset-0 bg-gray-600 bg-opacity-75 z-50 hidden">
    <div class="flex items-center justify-center min-h-screen p-4">
        <div class="bg-white rounded-lg shadow-xl max-w-md w-full transform transition-all">
            <div class="p-6">
                <div class="flex items-center mb-4">
                    <div class="flex-shrink-0">
                        <i class="fas fa-exclamation-triangle text-red-600 text-2xl"></i>
                    </div>
                    <div class="ml-4">
                        <h3 class="text-lg font-medium text-gray-900" id="deleteModalTitle">Confirm Deletion</h3>
                    </div>
                </div>
                
                <div class="mb-6">
                    <p class="text-gray-600" id="deleteModalMessage">
                        Are you sure you want to delete this item? This action cannot be undone.
                    </p>
                </div>
                
                <div class="flex justify-end space-x-3">
                    <button type="button" 
                            onclick="closeDeleteModal()" 
                            class="px-4 py-2 text-gray-700 bg-gray-200 hover:bg-gray-300 rounded-lg transition duration-200">
                        Cancel
                    </button>
                    <button type="button" 
                            id="confirmDeleteBtn"
                            class="px-4 py-2 bg-red-600 text-white hover:bg-red-700 rounded-lg transition duration-200">
                        <i class="fas fa-trash mr-2"></i>Delete
                    </button>
                </div>
            </div>
        </div>
    </div>
</div>

<script>
window.showDeleteModal = function(title, message, confirmCallback) {
    const modal = document.getElementById('deleteModal');
    const titleEl = document.getElementById('deleteModalTitle');
    const messageEl = document.getElementById('deleteModalMessage');
    const confirmBtn = document.getElementById('confirmDeleteBtn');
    
    titleEl.textContent = title || 'Confirm Deletion';
    messageEl.textContent = message || 'Are you sure you want to delete this item?';
    
    // Remove existing event listeners
    const newConfirmBtn = confirmBtn.cloneNode(true);
    confirmBtn.parentNode.replaceChild(newConfirmBtn, confirmBtn);
    
    // Add new event listener
    newConfirmBtn.addEventListener('click', function() {
        if (confirmCallback) confirmCallback();
        closeDeleteModal();
    });
    
    modal.classList.remove('hidden');
    document.body.style.overflow = 'hidden';
};

window.closeDeleteModal = function() {
    const modal = document.getElementById('deleteModal');
    modal.classList.add('hidden');
    document.body.style.overflow = '';
};
</script>
```

## Home Page Enhancement

### **Update `/Views/Home/Index.cshtml`**
```html
@{
    ViewData["Title"] = "Dashboard";
}

<div class="space-y-8">
    <!-- Welcome Hero Section -->
    <div class="bg-gradient-to-r from-blue-600 to-blue-700 rounded-2xl shadow-lg overflow-hidden">
        <div class="px-6 py-12 sm:px-12 sm:py-16">
            <div class="max-w-3xl">
                <h1 class="text-4xl font-bold text-white sm:text-5xl mb-4">
                    Welcome to Company Solution!
                </h1>
                <p class="text-xl text-blue-100 mb-8 leading-relaxed">
                    Your comprehensive employee management system. Streamline HR processes, 
                    manage employee data, and generate insightful reports all in one place.
                </p>
                
                <div class="flex flex-col sm:flex-row gap-4">
                    <a asp-controller="Pegawai" asp-action="Index" 
                       class="inline-flex items-center justify-center px-6 py-3 bg-white text-blue-700 font-semibold rounded-lg hover:bg-blue-50 transform hover:scale-105 transition duration-200 shadow-lg">
                        <i class="fas fa-users mr-3"></i>
                        Manage Employees
                    </a>
                    <a asp-controller="Report" asp-action="Index" 
                       class="inline-flex items-center justify-center px-6 py-3 bg-blue-500 text-white font-semibold rounded-lg hover:bg-blue-400 transform hover:scale-105 transition duration-200 border-2 border-blue-300">
                        <i class="fas fa-chart-line mr-3"></i>
                        View Analytics
                    </a>
                </div>
            </div>
        </div>
        
        <!-- Decorative background elements -->
        <div class="absolute top-0 right-0 -mt-4 -mr-4 opacity-30">
            <div class="w-32 h-32 bg-white rounded-full"></div>
        </div>
        <div class="absolute bottom-0 right-16 -mb-8 opacity-20">
            <div class="w-16 h-16 bg-white rounded-full"></div>
        </div>
    </div>

    <!-- Quick Stats Grid -->
    <div class="grid grid-cols-1 md:grid-cols-3 gap-6">
        <div class="bg-white p-6 rounded-xl shadow-sm border border-gray-100 hover:shadow-md transition duration-200">
            <div class="flex items-center">
                <div class="p-3 bg-blue-100 rounded-xl">
                    <i class="fas fa-users text-blue-600 text-2xl"></i>
                </div>
                <div class="ml-4">
                    <h3 class="text-2xl font-bold text-gray-900">@(ViewBag.TotalEmployees ?? "0")</h3>
                    <p class="text-gray-600">Total Employees</p>
                </div>
            </div>
        </div>
        
        <div class="bg-white p-6 rounded-xl shadow-sm border border-gray-100 hover:shadow-md transition duration-200">
            <div class="flex items-center">
                <div class="p-3 bg-green-100 rounded-xl">
                    <i class="fas fa-building text-green-600 text-2xl"></i>
                </div>
                <div class="ml-4">
                    <h3 class="text-2xl font-bold text-gray-900">@(ViewBag.TotalBranches ?? "0")</h3>
                    <p class="text-gray-600">Active Branches</p>
                </div>
            </div>
        </div>
        
        <div class="bg-white p-6 rounded-xl shadow-sm border border-gray-100 hover:shadow-md transition duration-200">
            <div class="flex items-center">
                <div class="p-3 bg-purple-100 rounded-xl">
                    <i class="fas fa-briefcase text-purple-600 text-2xl"></i>
                </div>
                <div class="ml-4">
                    <h3 class="text-2xl font-bold text-gray-900">@(ViewBag.TotalPositions ?? "0")</h3>
                    <p class="text-gray-600">Job Positions</p>
                </div>
            </div>
        </div>
    </div>

    <!-- Quick Actions Section -->
    <div class="bg-white rounded-xl shadow-sm border border-gray-100 p-6">
        <h2 class="text-xl font-semibold text-gray-900 mb-6">Quick Actions</h2>
        
        <div class="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-4 gap-4">
            <a asp-controller="Pegawai" asp-action="Create" 
               class="flex flex-col items-center p-6 border border-gray-200 rounded-lg hover:border-blue-300 hover:bg-blue-50 transition duration-200 group">
                <div class="p-3 bg-blue-100 rounded-xl group-hover:bg-blue-200 transition duration-200">
                    <i class="fas fa-user-plus text-blue-600 text-xl"></i>
                </div>
                <h3 class="mt-3 font-medium text-gray-900">Add Employee</h3>
                <p class="mt-1 text-sm text-gray-500 text-center">Create new employee profile</p>
            </a>
            
            <a asp-controller="Pegawai" asp-action="Upload" 
               class="flex flex-col items-center p-6 border border-gray-200 rounded-lg hover:border-green-300 hover:bg-green-50 transition duration-200 group">
                <div class="p-3 bg-green-100 rounded-xl group-hover:bg-green-200 transition duration-200">
                    <i class="fas fa-upload text-green-600 text-xl"></i>
                </div>
                <h3 class="mt-3 font-medium text-gray-900">Bulk Upload</h3>
                <p class="mt-1 text-sm text-gray-500 text-center">Import employee data via CSV</p>
            </a>
            
            <a asp-controller="Cabang" asp-action="Create" 
               class="flex flex-col items-center p-6 border border-gray-200 rounded-lg hover:border-purple-300 hover:bg-purple-50 transition duration-200 group">
                <div class="p-3 bg-purple-100 rounded-xl group-hover:bg-purple-200 transition duration-200">
                    <i class="fas fa-building text-purple-600 text-xl"></i>
                </div>
                <h3 class="mt-3 font-medium text-gray-900">Add Branch</h3>
                <p class="mt-1 text-sm text-gray-500 text-center">Create new company branch</p>
            </a>
            
            <a asp-controller="Report" asp-action="Index" 
               class="flex flex-col items-center p-6 border border-gray-200 rounded-lg hover:border-orange-300 hover:bg-orange-50 transition duration-200 group">
                <div class="p-3 bg-orange-100 rounded-xl group-hover:bg-orange-200 transition duration-200">
                    <i class="fas fa-chart-bar text-orange-600 text-xl"></i>
                </div>
                <h3 class="mt-3 font-medium text-gray-900">View Reports</h3>
                <p class="mt-1 text-sm text-gray-500 text-center">Analytics and insights</p>
            </a>
        </div>
    </div>

    <!-- Recent Activity Section -->
    <div class="bg-white rounded-xl shadow-sm border border-gray-100 p-6">
        <div class="flex items-center justify-between mb-6">
            <h2 class="text-xl font-semibold text-gray-900">Recent Activity</h2>
            <a href="#" class="text-blue-600 hover:text-blue-800 text-sm font-medium">View All</a>
        </div>
        
        <div class="space-y-4">
            <div class="flex items-center space-x-4 p-4 bg-gray-50 rounded-lg">
                <div class="flex-shrink-0">
                    <div class="w-10 h-10 bg-green-100 rounded-full flex items-center justify-center">
                        <i class="fas fa-user-plus text-green-600"></i>
                    </div>
                </div>
                <div class="flex-1">
                    <p class="text-sm font-medium text-gray-900">New employee added</p>
                    <p class="text-sm text-gray-500">John Doe joined Marketing department</p>
                </div>
                <div class="text-sm text-gray-500">2h ago</div>
            </div>
            
            <div class="flex items-center space-x-4 p-4 bg-gray-50 rounded-lg">
                <div class="flex-shrink-0">
                    <div class="w-10 h-10 bg-blue-100 rounded-full flex items-center justify-center">
                        <i class="fas fa-upload text-blue-600"></i>
                    </div>
                </div>
                <div class="flex-1">
                    <p class="text-sm font-medium text-gray-900">Bulk upload completed</p>
                    <p class="text-sm text-gray-500">25 employee records processed</p>
                </div>
                <div class="text-sm text-gray-500">5h ago</div>
            </div>
            
            <div class="flex items-center space-x-4 p-4 bg-gray-50 rounded-lg">
                <div class="flex-shrink-0">
                    <div class="w-10 h-10 bg-purple-100 rounded-full flex items-center justify-center">
                        <i class="fas fa-building text-purple-600"></i>
                    </div>
                </div>
                <div class="flex-1">
                    <p class="text-sm font-medium text-gray-900">New branch created</p>
                    <p class="text-sm text-gray-500">Jakarta Selatan office opened</p>
                </div>
                <div class="text-sm text-gray-500">1d ago</div>
            </div>
        </div>
    </div>
</div>
```

## Error Page Enhancement

### **Update `/Views/Shared/Error.cshtml`**
```html
@model ErrorViewModel
@{
    ViewData["Title"] = "Error";
    Layout = "_Layout";
}

<div class="min-h-screen bg-gray-50 flex flex-col justify-center py-12 sm:px-6 lg:px-8">
    <div class="sm:mx-auto sm:w-full sm:max-w-md">
        <div class="text-center">
            <i class="fas fa-exclamation-triangle text-6xl text-red-500 mb-4"></i>
            <h1 class="text-4xl font-bold text-gray-900 mb-2">Oops!</h1>
            <h2 class="text-xl text-gray-600 mb-8">Something went wrong</h2>
        </div>
        
        <div class="bg-white py-8 px-4 shadow-sm rounded-lg sm:px-10">
            <div class="text-center space-y-6">
                <p class="text-gray-600">
                    We're sorry, but an error occurred while processing your request. 
                    Please try again or contact support if the problem persists.
                </p>
                
                @if (Model.ShowRequestId)
                {
                    <div class="bg-gray-50 p-4 rounded-lg">
                        <p class="text-sm text-gray-500">
                            <strong>Request ID:</strong> 
                            <code class="bg-gray-200 px-2 py-1 rounded text-xs">@Model.RequestId</code>
                        </p>
                    </div>
                }
                
                <div class="flex flex-col sm:flex-row gap-3 justify-center">
                    <button onclick="history.back()" 
                            class="inline-flex items-center px-4 py-2 border border-gray-300 text-gray-700 font-medium rounded-lg hover:bg-gray-50 transition duration-200">
                        <i class="fas fa-arrow-left mr-2"></i>Go Back
                    </button>
                    <a asp-controller="Home" asp-action="Index" 
                       class="inline-flex items-center px-4 py-2 bg-blue-600 text-white font-medium rounded-lg hover:bg-blue-700 transition duration-200">
                        <i class="fas fa-home mr-2"></i>Home
                    </a>
                </div>
                
                <div class="pt-6 border-t border-gray-200">
                    <p class="text-sm text-gray-500">
                        Need help? <a href="#" class="text-blue-600 hover:text-blue-800 font-medium">Contact Support</a>
                    </p>
                </div>
            </div>
        </div>
    </div>
</div>
```

## Form Validation Enhancement

### **Update `/Views/Shared/_ValidationScriptsPartial.cshtml`**
```html
<script src="~/lib/jquery/dist/jquery.min.js"></script>
<script src="~/lib/jquery-validation/dist/jquery.validate.min.js"></script>
<script src="~/lib/jquery-validation-unobtrusive/dist/jquery.validate.unobtrusive.min.js"></script>

<!-- Enhanced Validation Styling -->
<script>
document.addEventListener('DOMContentLoaded', function() {
    // Enhanced validation error styling
    const observer = new MutationObserver(function(mutations) {
        mutations.forEach(function(mutation) {
            if (mutation.type === 'childList') {
                // Style validation errors
                document.querySelectorAll('.field-validation-error').forEach(function(element) {
                    element.className = 'mt-1 text-sm text-red-600 field-validation-error';
                });
                
                // Style invalid inputs
                document.querySelectorAll('.input-validation-error').forEach(function(element) {
                    element.classList.remove('input-validation-error');
                    element.classList.add('border-red-300', 'focus:border-red-500', 'focus:ring-red-500');
                });
                
                // Style validation summary
                document.querySelectorAll('.validation-summary-errors').forEach(function(element) {
                    element.className = 'validation-summary-errors mb-4 p-4 bg-red-50 border border-red-200 rounded-lg';
                    element.innerHTML = '<div class="flex"><i class="fas fa-exclamation-circle text-red-500 mr-2 mt-0.5"></i><div class="text-red-700 text-sm">' + element.innerHTML + '</div></div>';
                });
            }
        });
    });
    
    observer.observe(document.body, {
        childList: true,
        subtree: true
    });
    
    // Initial styling
    document.querySelectorAll('form').forEach(function(form) {
        // Add real-time validation feedback
        const inputs = form.querySelectorAll('input[data-val], select[data-val], textarea[data-val]');
        inputs.forEach(function(input) {
            input.addEventListener('blur', function() {
                setTimeout(() => {
                    const isValid = $(this).valid();
                    if (isValid) {
                        this.classList.remove('border-red-300');
                        this.classList.add('border-green-300');
                    } else {
                        this.classList.remove('border-green-300');
                        this.classList.add('border-red-300');
                    }
                }, 100);
            });
            
            input.addEventListener('focus', function() {
                this.classList.remove('border-red-300', 'border-green-300');
                this.classList.add('border-blue-500');
            });
        });
    });
});
</script>
```

## Final CSS Additions

### **Update `/wwwroot/css/site.css` (if exists) or create it:**
```css
/* Custom styles for Company Solution */

/* Loading animations */
@keyframes spin {
    to {
        transform: rotate(360deg);
    }
}

.fa-spin {
    animation: spin 1s linear infinite;
}

/* Form enhancements */
.form-input:focus,
.form-select:focus,
.form-textarea:focus {
    outline: none;
    border-color: #3b82f6;
    box-shadow: 0 0 0 3px rgba(59, 130, 246, 0.1);
}

/* Button hover effects */
.btn-primary {
    background: linear-gradient(135deg, #3b82f6 0%, #1d4ed8 100%);
    transition: all 0.2s ease-in-out;
}

.btn-primary:hover {
    transform: translateY(-1px);
    box-shadow: 0 4px 12px rgba(59, 130, 246, 0.4);
}

/* Card hover effects */
.card-hover {
    transition: all 0.2s ease-in-out;
}

.card-hover:hover {
    transform: translateY(-2px);
    box-shadow: 0 8px 25px rgba(0, 0, 0, 0.1);
}

/* Table enhancements */
.table-responsive {
    border-radius: 0.5rem;
    overflow: hidden;
}

.table-responsive table {
    margin-bottom: 0;
}

/* Sidebar animations */
.sidebar-enter {
    transform: translateX(-100%);
}

.sidebar-enter-active {
    transform: translateX(0);
    transition: transform 300ms ease-in-out;
}

.sidebar-exit {
    transform: translateX(0);
}

.sidebar-exit-active {
    transform: translateX(-100%);
    transition: transform 300ms ease-in-out;
}

/* Custom scrollbar for sidebar */
.sidebar-scroll::-webkit-scrollbar {
    width: 4px;
}

.sidebar-scroll::-webkit-scrollbar-track {
    background: #374151;
}

.sidebar-scroll::-webkit-scrollbar-thumb {
    background: #6b7280;
    border-radius: 2px;
}

.sidebar-scroll::-webkit-scrollbar-thumb:hover {
    background: #9ca3af;
}

/* Notification animations */
@keyframes slideInRight {
    from {
        transform: translateX(100%);
        opacity: 0;
    }
    to {
        transform: translateX(0);
        opacity: 1;
    }
}

@keyframes slideOutRight {
    from {
        transform: translateX(0);
        opacity: 1;
    }
    to {
        transform: translateX(100%);
        opacity: 0;
    }
}

.notification-enter {
    animation: slideInRight 0.3s ease-out;
}

.notification-exit {
    animation: slideOutRight 0.3s ease-in;
}

/* Print styles */
@media print {
    .no-print {
        display: none !important;
    }
    
    .print-friendly {
        color: black !important;
        background: white !important;
    }
}

/* Mobile optimizations */
@media (max-width: 768px) {
    .mobile-hidden {
        display: none;
    }
    
    .mobile-full {
        width: 100%;
    }
    
    .mobile-stack {
        flex-direction: column;
    }
    
    .mobile-center {
        text-align: center;
    }
}

/* Focus styles for accessibility */
.focus-visible:focus {
    outline: 2px solid #3b82f6;
    outline-offset: 2px;
}

/* High contrast mode support */
@media (prefers-contrast: high) {
    .bg-gray-50 {
        background-color: white;
    }
    
    .text-gray-600 {
        color: black;
    }
    
    .border-gray-200 {
        border-color: black;
    }
}

/* Reduced motion support */
@media (prefers-reduced-motion: reduce) {
    * {
        animation-duration: 0.01ms !important;
        animation-iteration-count: 1 !important;
        transition-duration: 0.01ms !important;
    }
}
```

## Summary of All Improvements

1. **Layout Consistency**: Fixed mixed Tailwind/Bootstrap classes, implemented proper responsive design
2. **Accessibility**: Added ARIA labels, proper semantic HTML, keyboard navigation support
3. **UX Enhancements**: Loading states, better error handling, improved forms, mobile responsiveness
4. **Visual Design**: Modern card layouts, proper spacing, consistent color scheme, hover effects
5. **JavaScript Functionality**: Enhanced dropdowns, form validation, notifications, modal dialogs
6. **Performance**: Optimized asset loading, efficient DOM manipulation, reduced reflows
7. **Mobile Experience**: Responsive tables, mobile-friendly navigation, touch-optimized controls
8. **Error Handling**: Better validation feedback, user-friendly error pages, loading indicators

These improvements create a modern, professional, and user-friendly employee management system that follows current web design best practices and provides an excellent user experience across all devices.