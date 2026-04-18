window.addEventListener("load", solve);

function solve() {
    let nameInputEl = document.getElementById("name");
    let locationSelectorEl = document.getElementById("location");
    let genderInputEl = document.getElementById("gender");

    const createBtnEl = document.getElementById("create-btn");

    const preparingListEl = document.getElementById("preparing-list");
    const characterListEl = document.getElementById("character-list");

    createBtnEl.addEventListener("click", createCharacter);

   function createCharacter(e) {

    if (inputFieldsAreEmpty()) {
        return;
    }

    let liEl = document.createElement("li");
    liEl.className = "creating";

    let nameEl = document.createElement("h4");
    let locationEl = document.createElement("p");
    let genderEl = document.createElement("p");

    nameEl.textContent = nameInputEl.value;
    locationEl.textContent = locationSelectorEl.value;
    genderEl.textContent = genderInputEl.value;

    let editBtnEl = document.createElement("button");
    let doneBtnEl = document.createElement("button");

    editBtnEl.textContent = "Edit";
    doneBtnEl.textContent = "Done";

    editBtnEl.className = "action-btn edit";
    doneBtnEl.className = "action-btn done";

    editBtnEl.addEventListener("click", editCharacter);
    doneBtnEl.addEventListener("click", applyForEvents);

    liEl.appendChild(nameEl);
    liEl.appendChild(locationEl);
    liEl.appendChild(genderEl);
    liEl.appendChild(editBtnEl);
    liEl.appendChild(doneBtnEl);

    preparingListEl.appendChild(liEl);

    clearInputFields(); // 👈 MOVE THIS UP

    createBtnEl.disabled = true;
}

function editCharacter(e) {
    const liEl = e.target.parentElement;

    const fields = liEl.querySelectorAll("h4, p");

    nameInputEl.value = fields[0].textContent;
    locationSelectorEl.value = fields[1].textContent;
    genderInputEl.value = fields[2].textContent;

    liEl.remove();

    createBtnEl.disabled = false;
}

function applyForEvents(e) {
    const liEl = e.target.parentElement;

    liEl.querySelectorAll("button").forEach(b => b.remove());

    characterListEl.appendChild(liEl);

    createBtnEl.disabled = false;
}

function inputFieldsAreEmpty() {
    return (
        nameInputEl.value.trim() === "" ||
        locationSelectorEl.value === "" ||
        locationSelectorEl.value === "Choose location:" ||
        genderInputEl.value.trim() === ""
    );
}

function clearInputFields() {
    nameInputEl.value = "";
    locationSelectorEl.value = "";
    genderInputEl.value = "";
}
}
