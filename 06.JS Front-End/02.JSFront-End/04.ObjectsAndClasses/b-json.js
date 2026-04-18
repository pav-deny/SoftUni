let personObj = {
    firstName: "Pencho",
    lastName: "Minchov",
    age: 25,
    hasGraduated: true
};

let personJson = JSON.stringify(personObj);
console.log(personJson);

let personFinalObj = JSON.parse(personJson);
console.log(personFinalObj);