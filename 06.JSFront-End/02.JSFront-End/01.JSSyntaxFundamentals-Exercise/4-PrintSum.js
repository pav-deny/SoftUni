function solve(start, end) {
    let sum = 0;
    let allNumbersInRange = "";

    for (let i = start; i <= end; i++) {
        allNumbersInRange += i + " ";
        sum += i;
    }

    console.log(allNumbersInRange.trimEnd());
    console.log("Sum: " + sum);
}

solve(5, 10);