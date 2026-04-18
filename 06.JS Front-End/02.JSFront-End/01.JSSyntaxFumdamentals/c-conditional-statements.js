//Comparison Operators
//--------------------

console.log(5 == 5); //Equality Operator; True
console.log(5 == "5"); //Equalit Operator allows coertion; True
//Coertion - either 5 turns into "5" or "5" turns into 5 and it checks if 5 = 5/ "5" = "5"

console.log(5 === "5"); //Strict Equality Operator / Identity Operator; Doesn't allow coertion; False 

console.log(5 != "5"); //Inequality Operator (allows coertion)
console.log(5 !== "5"); //Strict Inequality Operator (doesn't allow coertion)

//5 and "5" are equal but not the same identity/не са идентични

console.log("Liar \\/");
console.log((5 < 7) ? "def not" : "def yes");

let x = 5;
let y = 10;

x += y; //x = 15

//Conditional Statements
//----------------------

let age = 17;

if (age >= 18) {
    console.log("Authorise Payment!");
    console.log("Continue...")
} else if (age === 17) {
    console.log("Try again next year bud!")
} else {
    console.log("Try again later!");
    console.log("...when you turn 18");
}

//Switch Statement

let product = "food";

switch (product) {
    case "water":
        console.log("Drink water");
        break;
    
    case "food":
        console.log("Eat food");
        break;

    default:
        console.log("Unknown product type");
        break;
}

//Logical Operators
//-----------------

console.log("-----------");

console.log(!true);
console.log(!false);
console.log(true && false);
console.log(true || false);

console.log("-----------");

console.log(3 > 0 && -2 > 0); //false

console.log("----------------------");

console.log(typeof 9);
console.log(typeof "Pesho");
console.log(typeof NaN);
console.log(typeof true);
console.log(typeof 1248947394793793273974n);
console.log(typeof Symbol('aaaa'));
console.log(typeof undefined);
console.log(typeof null);

console.log("------------------------");
console.log("----------------------");

//Truthy and Falsy values
//-----------------------

let value = "Pesho";

if (value) {
    console.log("This value is truthy!"); //Truthy - Everything else than \/, including [] anf {}
} else {
    console.log("This value is falsy!") //Falsy: "", false, null, undifined, NaN, 0
}

//Expression vs Statement
//-----------------------

function calculate(a, b){
    return a +b;
}

//Expression -> returns value

let result = 5 + 5;

let sum = calculate(3, 8);

// return "Pesho";

//Statement -> runs code/ does action

let number = 5; //Expression

//Statement
if (number < 10) {
    console.log("success!");
}   else {
    console.lof("fail!");
} 

console.log(number < 10 ? "success!" : "fail!"); //Expression
