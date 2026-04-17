const stopIdInputEl = document.getElementById("stopId");
const stopNameDivEl = document.getElementById("stopName");
const bussesUlEl = document.getElementById("buses");

async function getInfo() {
    const stopId = stopIdInputEl.value.trim();

    try {
        const result = await fetch(`http://localhost:3030/jsonstore/bus/businfo/${stopId}`);
        const data = await result.json();

        stopNameDivEl.textContent = data.name;
        const busEntries = Object.entries(data.buses);

        for (const [busNo, time] of busEntries) {
            const liEl = document.createElement('li');
            liEl.textContent = `Bus ${busNo} arrives in ${time} minutes`;
            bussesUlEl.appendChild(liEl);
        }
    }   catch (err) {
        stopNameDivEl.textContent = "Error";
    }
}