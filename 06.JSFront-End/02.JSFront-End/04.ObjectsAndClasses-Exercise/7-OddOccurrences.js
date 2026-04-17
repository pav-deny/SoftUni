function solve(input = "") {
    input = input.toLowerCase();

    const inputArr = input.split(" ");

    let occurances = {};

    for (let word of inputArr) {
        if (occurances[word] == undefined) {
            occurances[word] = 0;
        }

        occurances[word]++;
    }

    let result = Object.entries(occurances)
        .filter(wordEntry => wordEntry[1] % 2 !== 0)
        .sort((a, b) => b[1] - a[1])
        .map(wordEntry => wordEntry[0])
        .join(' ');

    console.log(result);
}

solve('Java C# Php PHP Java PhP 3 C# 3 1 5 C#');
solve('Cake IS SWEET is Soft CAKE sweet Food');