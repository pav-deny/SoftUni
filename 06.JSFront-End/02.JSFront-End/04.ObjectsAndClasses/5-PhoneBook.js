function solve(input = []) {
    let phoneBook = {}
    
    for (entry of input) {
        let entryArr = entry.split(" ");
        phoneBook[entryArr[0]] = entryArr[1];
    }

    let entries = Object.entries(phoneBook);

    for ([contactName, number] of entries) {
        console.log(`${contactName} -> ${number}`);
    }
}

solve(['Tim 0834212554',
 'Peter 0877547887',
 'Bill 0896543112',
 'Tim 0876566344']
);