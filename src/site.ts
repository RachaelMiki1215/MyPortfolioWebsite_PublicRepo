// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Add collapsible section functionality
export function collapseSection() {
    $('.collapse-head').on('click', function () {
        if (this.classList.contains('collapsed')) {
            this.classList.remove('collapsed');
            this.nextElementSibling.classList.remove('collapse');
        }
        else {
            this.classList.toggle('collapsed');
            this.nextElementSibling.classList.toggle('collapse');
        }
    });
}