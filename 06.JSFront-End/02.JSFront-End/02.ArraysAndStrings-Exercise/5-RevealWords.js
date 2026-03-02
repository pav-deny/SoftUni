function solve(wordInput = " ", text = " ") {
    const words = wordInput.split(', ').sort((a, b) => b.length - a.length);

    for (const word of words) {
        const searchedWord = '*'.repeat(word.length);
        text = text.replaceAll(searchedWord, word);
    }

    console.log(text);
}

solve('great','softuni is ***** place for learning new programming languages');
solve('great, learning','softuni is ***** place for ******** new programming languages');
solve('great, learning','softuni is ***** place for ******** new  ***** programming languages');