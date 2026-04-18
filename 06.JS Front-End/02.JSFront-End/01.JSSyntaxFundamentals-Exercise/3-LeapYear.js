function solve(year) {
    const isDivisibleBy4 = year % 4 == 0;

    const isDivisibleBy100 = year % 100 == 0;
    const isDivisibleBy400 = year % 400 == 0;

    const isLeapYear = isDivisibleBy4 && (!isDivisibleBy100 || isDivisibleBy400);

    if (isLeapYear) {
        console.log("yes");
    } else {
        console.log("no");
    }
}

solve(1984);
solve(2003);
solve(4);
solve(200);
solve(400);
solve(100);
solve(800);