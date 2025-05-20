document.addEventListener('DOMContentLoaded', function() {
    const element = document.getElementById("cardNumber");
    if (element) {
        element.addEventListener('keydown', function(event) {
     BlockLetters(event);
});
}
});
window.BlockLetters = function (e) {
    // Lista de teclas permitidas: números y teclas de control
    var allowedKeys = [
        "0", "1", "2", "3", "4", "5", "6", "7", "8", "9",
        "Backspace", "Delete", "Tab", "ArrowLeft", "ArrowRight",
    ];
    if (!allowedKeys.includes(e.key)) {
        e.preventDefault();
    }
}
window.FormatCardNumber = function (input) {
    let value = input.value.replace(/\D/g, '').substring(0, 16); // só números, máximo 16 dígitos
    value = value.replace(/(.{4})/g, '$1 ').trim();// espaço a cada 4 dígitos
    input.value = value; // Atualiza o valor do input
}

  

