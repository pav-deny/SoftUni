function addItem() {
    const UlElement = document.getElementById("items");
    
    const listItemElement = document.createElement("li");
    const inputElement = document.getElementById("newItemText");
    listItemElement.textContent = inputElement.value;
    
    const aElement = document.createElement("a");
    aElement.href = "#";
    aElement.textContent = "[Delete]";
    aElement.addEventListener("click", deleteItem);

    listItemElement.appendChild(aElement);
    UlElement.appendChild(listItemElement);

    inputElement.value = "";
}

function deleteItem(e) {
    e.currentTarget.parentElement.remove();
}
