function attachGradientEvents() {
    const gradiantDivElemnet = document.getElementById("gradient");
    const resultElement = document.getElementById("result");

    gradiantDivElemnet.addEventListener("mousemove", handleMouseMovement);

    function handleMouseMovement(e) {
        // rounded -> (cursorDistanceFromLeft / elementWidth) * 100

        const cursorDistanceFromLeft = e.offsetX;
        const elementWidth = e.target.clientWidth;

        const percent = Math.floor((cursorDistanceFromLeft / elementWidth) * 100);
        
        resultElement.textContent = percent + "%"
    }
}
