function solve(num1, num2, num3) {
    let sumResult = sum(num1, num2);
    let subtractResult = subtract(sumResult, num3);
    console.log(subtractResult);

    function sum(a, b) {
        return a + b;
    }

    function subtract(a, b) {
        return a - b;
    }
}

solve(23, 6, 10);
solve(1, 17, 30);
solve(42, 58, 100);