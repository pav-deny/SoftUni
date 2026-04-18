function solve(count, inputArr = []) {
    let result = [];

    for (let i = 0; i < count; i++) {
        result[i] = inputArr[i];
    }

    result = result.reverse();

    console.log(result.join(" "));
}

solve(3, [10, 20, 30, 40, 50]);
solve(4, [-1, 20, 99, 5]);
solve(2, [66, 43, 75, 89, 47]);