function calculate(num1, num2, action) {
    const funcNames = ["add", "subtract", "multiply", "divide"];
    const funcs = [add, subtract, multiply, divide];

    const index = funcNames.indexOf(action);
    console.log(funcs[index](num1, num2));
    
    function multiply(num1, num2) {
        return(num1 * num2);
    }
    
    function add(num1, num2) {
        return(num1 + num2);
    }
    
    function subtract(num1, num2) {
        return(num1 - num2);
    }
    
    function divide(num1, num2) {
        return(num1 / num2);
    }
}


calculate(5, 5, 'multiply');
calculate(40, 8, 'divide');
calculate(12, 19, "add");
calculate(50, 13, "subtract");