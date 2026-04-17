let orangeDivElement = document.getElementById("orange");
let greenDivElement = document.getElementById("green");
let yellowDivElement = document.getElementById("yellow");

orangeDivElement.addEventListener("click", handleDivClick);
greenDivElement.addEventListener("click", handleDivClick);
yellowDivElement.addEventListener("click", handleDivClick);

function handleDivClick(e) {    
    e.stopPropagation();
    console.log(e.currentTarget);
}