document.addEventListener('DOMContentLoaded', function () {
    // Sidebar Toggle
    const sidebarToggle = document.getElementById('sidebarToggle');
    const sidebar = document.querySelector('.flex.flex-col.w-64'); // The sidebar element
    const mainContentWrapper = document.querySelector('.flex-1.flex.flex-col.overflow-hidden'); // The main content wrapper

    if (sidebarToggle && sidebar && mainContentWrapper) {
        // Initial state: sidebar is visible, content is pushed
        // For mobile, sidebar should be hidden by default
        const isMobile = window.innerWidth < 768; // Tailwind's md breakpoint

        if (isMobile) {
            sidebar.classList.add('-translate-x-full'); // Hide sidebar on mobile
        } else {
            mainContentWrapper.classList.add('ml-64'); // Push content on desktop
        }

        sidebarToggle.addEventListener('click', function () {
            sidebar.classList.toggle('-translate-x-full'); // Toggle sidebar visibility
            mainContentWrapper.classList.toggle('ml-64'); // Toggle content margin
        });
    }
});