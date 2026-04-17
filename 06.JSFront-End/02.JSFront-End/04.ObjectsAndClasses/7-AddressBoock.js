function solve(input = []) {
    let addressBook = {};

    for (entry of input) {
        let [person, address] = entry.split(':');

        addressBook[person] = address;
    } 

    let entries = Object.entries(addressBook).sort((a, b) => a[0].localeCompare(b[0]));

    for ([person, address] of entries) {
        console.log(`${person} -> ${address}`);
    }
}

solve(['Tim:Doe Crossing',
 'Bill:Nelson Place',
 'Peter:Carlyle Ave',
 'Bill:Ornery Rd']
);