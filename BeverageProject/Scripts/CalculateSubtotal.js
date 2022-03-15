let subtotal = document.getElementById("subtotal");
let price = parseFloat(document.getElementById("price").innerText);
let quantity = document.getElementById("quantity");
subtotal.innerText = price + "€";

quantity.addEventListener("input", updateValue);

function updateValue(e) {
    
    subtotal.innerText += parseFloat(e.data) * price.toFixed(2) + "€";
}