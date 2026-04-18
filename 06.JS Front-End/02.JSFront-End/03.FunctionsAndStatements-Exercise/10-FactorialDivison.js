function solve(num1, num2) {
    let num1Factorial = getFactorial(num1);
    let num2Factorial = getFactorial(num2);

    let result = divideFactorials(num1Factorial, num2Factorial);
    console.log(result.toFixed(2));

    //Non-recursion aproach
    function getFactorial(num) {
        let result = 1;
        for (let i = num; i > 1; i--) {
            result *= i
        } 

        return result;
    }

    // //Recursion aproach

    // function getFactorial(num) {
    //     return multiplyWithSmaller(num);
    // }

    // function multiplyWithSmaller(num) {
    //     let result = num * (num - 1);
    //     if (num - 2 > 1) {
    //         result *= multiplyWithSmaller(num - 2);
    //     }

    //     return result;
    // }

    function divideFactorials(factorial1, factorial2) {
        return factorial1 / factorial2;
    }
}

solve(5, 2); //60.00
solve(6, 2) //360.00