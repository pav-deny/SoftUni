function extractText() {
    let listItems = document.querySelectorAll("#items li");
    let textArea = document.querySelector("#result");

    for (let li of listItems) {
        let text = li.textContent;
        textArea.textContent += text + "\n";
    }
}