function solve(string = "", word) {
   let result = string.replaceAll(word , "*".repeat(word.length));
   console.log(result);
}

solve('A small sentence with some words', 'small');
solve('Find the hidden word', 'hidden');