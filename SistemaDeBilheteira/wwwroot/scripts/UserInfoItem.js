
document.addEventListener('DOMContentLoaded', function() {
    const element = document.getElementById("cardNumber");
    if (element) {
        element.addEventListener('keydown', function(event) {
     BlockLetters(event);
});
}
});
window.BlockLetters = function (e) {
    var allowedKeys = [
        "0", "1", "2", "3", "4", "5", "6", "7", "8", "9",
        "Backspace", "Delete", "Tab", "ArrowLeft", "ArrowRight",
    ];
    if (!allowedKeys.includes(e.key)) {
        e.preventDefault();
    }
}
window.FormatCardNumber = function (input) {
    let value = input.value.replace(/\D/g, '').substring(0, 16); // Max of 16 numbers
    value = value.replace(/(.{4})/g, '$1 ').trim();// space betwen every 4 digits
    input.value = value; 
}


window.FormatCVVNumber = function (input) {
    let value = input.value.replace(/\D/g, '').substring(0, 3); // max of 3 numbers
    input.value = value; 
}

window.togglePassword = function(inputId, iconElement) {
    const input = document.getElementById(inputId);
    if (!input) return;

    if (input.type === "password") {
        input.type = "text";
        iconElement.src = "images/icons/eye-closed.svg";
    } else {
        input.type = "password";
        iconElement.src = "images/icons/eye-icon.svg"; 
    }
}
  

