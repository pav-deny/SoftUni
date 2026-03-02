function solve(input) {
    let num = input;
    let result = 0;

    while(num > 0) {
        result += num % 10;

        num = Math.trunc(num / 10);
    }

    console.log(result);
}

solve(245678);