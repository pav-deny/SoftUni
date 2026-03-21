function solve(num) {
    const digits = getDigits(num);

    const [evenDigits, oddDigits] = filterDigits(digits);

    const evenSum = getSum(evenDigits);
    const oddSum = getSum(oddDigits);

    printResult(oddSum, evenSum);
    

    function getDigits(num) {
        let digits = [];

        while (num != 0) {
            digits.push(num % 10);
            num = Math.floor(num / 10);
        }

        return digits;
    }

    function filterDigits(digits) {
        let evenDigits = [];
        let oddDigits = [];
        
        for (let i = 0; i < digits.length; i++) {
            if (digits[i] % 2 == 0) {
                evenDigits.push(digits[i])
            } else {
                oddDigits.push(digits[i]);
            }
        }

        return [evenDigits, oddDigits];
    }

    function getSum(digits) {
        let sum = 0;

        for (let i = 0; i < digits.length; i++) {
            sum += digits[i];
        }

        return sum;
    }

    function printResult(oddSum, evenSum) {
        console.log(`Odd sum = ${oddSum}, Even sum = ${evenSum}`);
    }
}

solve(1000435);
solve(3495892137259234);