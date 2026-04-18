function solve(word = "", text = "") {
    const words = text.split(' ')

    if (words.some(w => w.toLowerCase() === word.toLowerCase())) {
        return console.log(word);
    }  

    console.log(`${word} not found!`);
}

solve('javascript', 'JavaScript is the best programming language');
solve('python','JavaScript is the best programming language');