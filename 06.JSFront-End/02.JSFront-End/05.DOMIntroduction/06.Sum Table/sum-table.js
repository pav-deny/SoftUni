function sumTable() {
    let costElements = document.querySelectorAll("tr:not(:last-child) td:nth-child(2)");
    let total = 0;

    for (let td of costElements) {
        total += Number(td.textContent);
    }

    let outputElement = document.querySelector("#sum");
    outputElement.textContent = total;
}