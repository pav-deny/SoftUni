function deleteByEmail() {
    let emailsElements = document.querySelectorAll("#customers tbody td:nth-child(2)");
    let deleteEmailElement = document.querySelector("input"); 
    let outputElement = document.querySelector("#result")

    for (let emailElement of emailsElements) {
        if(emailElement.textContent === deleteEmailElement.value) {
            outputElement.textContent = "Deleted.";
            emailElement.parentElement.remove();
            return;
        }
    }

    outputElement.textContent = "Not found.";
}
