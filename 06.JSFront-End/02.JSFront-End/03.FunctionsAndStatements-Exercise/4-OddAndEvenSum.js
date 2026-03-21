function solve(num) {
    let [oddSum, evenSum] = getSums(num);
    console.log(`Odd sum = ${oddSum}, Even sum = ${evenSum}`);

    function getSums(num) {
        let oddSum = 0;
        let evenSum = 0;

        while (num != 0) {
            let currentNum = num % 10;

            if (currentNum % 2 == 0) {
                evenSum += currentNum;
            } else {
                oddSum += currentNum;
            }

            num = Math.floor(num / 10);
        }

        return [oddSum, evenSum];
    }
}

solve(1000435);
solve(3495892137259234);