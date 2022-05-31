// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$('#my-todo-list').TodoList({
    onCheck: function (checkbox) {
        // Do something when the checkbox is checked
    },
    onUnCheck: function (checkbox) {
        // Do something after the checkbox has been unchecked
    }
})