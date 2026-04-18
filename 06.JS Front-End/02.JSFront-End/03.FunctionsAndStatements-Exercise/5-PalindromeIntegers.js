function solve(nums) {
    let output = getResults(nums);
    printResult(output);

    function getResults(nums) {
        let output = [];
        for (num of nums) {
            let result = checkIfPalindrome(num);
            output.push(result);
        }

        return output;
    }

    function checkIfPalindrome(num) {
        let numAsStr = num.toString();
        let reversed = numAsStr.split("").reverse().join("");
        
        if(numAsStr == reversed) {
            return true;
        }

        return false;
    }

    function printResult(output) {
        for (isPalindrome of output) {
            console.log(isPalindrome);
        }
    }
}

solve([123, 323, 421, 121]);
solve([32, 2, 2332, 1010]);