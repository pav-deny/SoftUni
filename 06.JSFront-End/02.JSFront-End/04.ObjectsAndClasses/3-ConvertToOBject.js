function solve(json) {
    let obj = JSON.parse(json);

    let entries = Object.entries(obj);

    for ([key, value] of entries) {
        console.log(`${key}: ${value}`);
    }
}

solve('{"name": "George", "age": 40, "town": "Sofia"}');
solve('{"name": "Peter", "age": 35, "town": "Plovdiv"}');