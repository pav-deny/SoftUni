function solve(age) {
    let personType;

    if (age >= 66) {
        personType = "elder";
    } else if (age >= 20) {
        personType = "adult";
    }   else if (age >= 14) {
        personType = "teenager";
    }   else if (age >= 3) {
        personType = "child";
    }   else if (age >= 0) {
        personType = "baby";
    }   else {
        personType = "out of bounds";
    }

    console.log(personType);
}