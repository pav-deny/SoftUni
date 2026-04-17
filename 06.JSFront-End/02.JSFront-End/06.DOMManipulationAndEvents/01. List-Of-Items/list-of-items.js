function addItem() {
    const UlElement = document.getElementById("items");
    
    const listItemElement = document.createElement("li");
    const inputElement = document.getElementById("newItemText");
    listItemElement.textContent = inputElement.value;
    UlElement.appendChild(listItemElement);

    inputElement.value = ""; //Added later; not used for Judge
}
 