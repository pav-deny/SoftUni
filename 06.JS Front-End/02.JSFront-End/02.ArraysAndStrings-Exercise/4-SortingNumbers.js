/***
*  @param {number[]} nums 
*/

function solve(nums) {
    let result = nums
    .sort((a, b) => a - b)
    .reduce((acc, num, index) => {
        acc.push(num);
        
        if (index !== nums.length - 1) {
            acc.push(nums.pop());
        }

        return acc;
    }, []);

    return result;   
}

console.log(solve([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]));