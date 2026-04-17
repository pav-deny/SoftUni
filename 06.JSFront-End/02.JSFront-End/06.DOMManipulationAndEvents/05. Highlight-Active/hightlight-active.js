document.addEventListener('DOMContentLoaded', focused);

function focused() {
    const panelsElements = document.querySelectorAll("input[type='text']");

    for (let panelElement of panelsElements) {
        panelElement.addEventListener("focus", addFocus);
        panelElement.addEventListener("blur", removeFocus);

    }

    function addFocus(e) {
        e.target.parentElement.classList.add("focused");
    }

    function removeFocus(e) {
        e.target.parentElement.classList.remove("focused");
    }
}
