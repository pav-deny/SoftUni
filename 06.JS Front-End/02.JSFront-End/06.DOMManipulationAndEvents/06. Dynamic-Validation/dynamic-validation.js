document.addEventListener('DOMContentLoaded', solve);

function solve() {
    const emailElement = document.getElementById("email");

    emailElement.addEventListener("change", handleEmailChange);

    function handleEmailChange(e) {
        const email = emailElement.value.trim();
        const pattern = /[a-z]+@[a-z]+\.[a-z]+/g;

        if (!pattern.test(email)) {
            emailElement.classList.add("error");
        } else {
            emailElement.classList.remove("error");
        }
    }
}
