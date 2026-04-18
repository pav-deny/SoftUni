function solve(input) {
    let wordsArr = input[0].split(" ");
    input.shift();

    let wordsToFind = {};

    for (let word of wordsArr) {
        wordsToFind[word] = 0;
    }

    for (let word of input) {
        if (wordsToFind[word] != undefined) {
            wordsToFind[word] += 1;
        }
    }


    let entries = Object.entries(wordsToFind).sort((a, b) => (a[1] - b[1]) * -1);

    for ([word, occurances] of entries) {
        console.log(`${word} - ${occurances}`);
    }

}

solve([
'this sentence', 
'In', 'this', 'sentence', 'you', 'have', 'to', 'count', 'the', 'occurrences', 'of', 'the', 'words', 'this', 'and', 'sentence', 'because', 'this', 'is', 'your', 'task'
]);

solve([
'is the', 
'first', 'sentence', 'Here', 'is', 'another', 'the', 'And', 'finally', 'the', 'the', 'sentence']
)