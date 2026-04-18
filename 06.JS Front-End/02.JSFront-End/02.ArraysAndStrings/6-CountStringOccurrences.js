function solve(string = "", word) {
    let occurrences = 0; 
    let stringArr = string.split(" ");

    for (let i =0; i < stringArr.length; i++) {
        if (stringArr[i] === word) {
            occurrences++;
        }
    }

    console.log(occurrences);
}

solve('This is a word and it also is a sentence','is');
solve('softuni is great place for learning new programming languages','softuni');