function solve(input = []) {
    let meetings = {};

    for (entry of input) {
        let [day, person] = entry.split(" ");

        if (day in meetings) {
            console.log(`Conflict on ${day}!`);
        } else {
            console.log(`Scheduled for ${day}`);
            meetings[day] = person;
        }
    }

    let entries = Object.entries(meetings);

    for ([day, person] of entries) {
        console.log(`${day} -> ${person}`);
    }
}

solve(['Monday Peter',
 'Wednesday Bill',
 'Monday Tim',
 'Friday Tim']
);