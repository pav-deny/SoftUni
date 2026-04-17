function solve(firstName, lastName, hairColour) {
    let obj = {
        name: firstName,
        lastName: lastName,
        hairColor: hairColour
    };

    let json = JSON.stringify(obj);
    console.log(json);
}

solve('George', 'Jones', 'Brown');
solve('Peter', 'Smith', 'Blond');