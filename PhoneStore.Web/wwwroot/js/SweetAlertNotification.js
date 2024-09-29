
function notification(title, text, icon) {
    Swal.fire({
        title: title,
        text: text,
        icon: icon,
        timer:1000,
        showConfirmButton: true
    });
}
