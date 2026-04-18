function solve(string, start, count) {
    let end = start + count;
    let result = string.substring(start, end)
    console.log(result);
}

solve('ASentence', 1, 8);
solve('SkipWord', 4, 7);