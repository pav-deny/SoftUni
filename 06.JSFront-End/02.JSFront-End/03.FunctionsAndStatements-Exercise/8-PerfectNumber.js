function solve(num) {
    const divisors = getDivisors(num);
    const divisorsSum = sumDivisors(divisors);

    const isPerfect = checkIfPerfect(num, divisorsSum);

    if (isPerfect) {
        console.log("We have a perfect number!");
    } else {
        console.log("It's not so perfect.")
    }

    function getDivisors(num) {
        let divisors = [];

        for (let i = 1; i < num; i++) {
            if (num % i === 0) {
                divisors.push(i);
            }
        }

        return divisors;
    }

    function sumDivisors(nums) {
        let sum = nums.reduce((acc, num) => acc + num, 0);
        return sum;
    }

    function checkIfPerfect(num, divisorSum) {
        return num === divisorSum;
    }
}

solve(6);
solve(5);
solve(28);