function calculate(firstNum, secondNum) {
    let sum = firstNum + secondNum;

    // console.log("The result is:", result);
    // console.log("The result is: " + result) //Concatenation
    // console.log("The result of " + firstNum + " and " + secondNum + " is equal to " + sum)
    console.log(`The result of ${firstNum} and ${secondNum} is equal to ${sum.toFixed(2)}`); //String interpolation {Template string}
}

calculate(4, 8);
calculate(3, 12);
calculate(5, 5);
calculate(10, 10);
calculate(2.7, 3.14);
calculate(3.14, 12,3);

//String literals
'Pesho'; //V
"Pesho"; //V
`Pesho`; //V; Template literal (can do 'hi hi hi ${var}'); is multi-line