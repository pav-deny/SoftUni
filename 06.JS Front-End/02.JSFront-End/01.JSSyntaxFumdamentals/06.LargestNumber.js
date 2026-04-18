function solve(a, b, c) {
    let largestNum;

    if (a > b && a > c) {
        largestNum = a;
    } else if (b > a && b > c) {
        largestNum = b;
    } else {
        largestNum = c;
    }

    console.log(`The largest number is ${largestNum}.`)
}