/** 
*   @param {number[]} nums - an array of numbers to be rotated
*   @param {number} rotations - number of rotations
*/ //JSDoc - helps document stuff

function solve(nums, rotations) {
    for (let i = 0; i < rotations; i++) {
        let firstElement = nums.shift();
        nums.push(firstElement);
    }

    console.log(nums.join(" "));
}

solve([51, 47, 32, 61, 21], 2);
solve([32, 21, 61, 1], 4);
solve([2, 4, 15, 31], 5);