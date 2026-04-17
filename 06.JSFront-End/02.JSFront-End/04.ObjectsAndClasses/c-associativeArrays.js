let contactNumbers = {
    pencho: "08767696789",
    mincho: "088-maikatanaRosen",
    ginka: "089KOSEM-KOMAR"
};

function printPhoneNumber(name) {
    console.log(contactNumbers[name]);
}

printPhoneNumber('pencho');
printPhoneNumber('mincho');
printPhoneNumber('ginka');

console.log("===============");

for (let name in contactNumbers) {
    console.log(`${name} => ${contactNumbers[name]}`);
}

console.log("===============");

let entries = Object.entries(contactNumbers);
console.log(entries);

console.log("===============");

for (let [name, phoneNumber] of entries) {
    console.log(`${name} (${phoneNumber})`);
}

console.log("===============");

for (let entry of entries) {
    console.log(entry);
}

console.log("===============");

let entries2 = Object.entries(contactNumbers).sort((a, b) => a[0].localeCompare(b[0]));

for (let entry of entries2) {
    console.log(entry);
}