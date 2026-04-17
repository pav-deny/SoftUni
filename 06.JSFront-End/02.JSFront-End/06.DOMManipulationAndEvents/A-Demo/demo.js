const contentDivElement = document.getElementById("main-content");
const namePElement = document.getElementById("person-name");

const agePElement = document.createElement("p");
agePElement.textContent = 20;

contentDivElement.appendChild(agePElement);
agePElement.textContent = 24;

agePElement.remove();

const namesUlElement = document.getElementById("names-list");

namesUlElement.addEventListener("click", handleUlClick);
namePElement.addEventListener("mouseover", handleMouseOverP);
namePElement.addEventListener("mouseout", handleStopHoverP);
namePElement.addEventListener("click", handleMouseClickP);

function handleUlClick(e) {
    console.log(e.target);
    console.log(e.currentTarget);
}

function handleMouseOverP(e) {
    namePElement.style.color = "red";
}

function handleStopHoverP(e) {
    namePElement.style.color = "black";
}

function handleMouseClickP(e) {
    namePElement.style.color = "blue";
}