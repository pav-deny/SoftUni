function solve(char1, char2) {
    const [lowerChar, higherChar] = getBoundary(char1, char2)
    let output = getCharsBetween(lowerChar, higherChar);
    console.log(output.trimEnd(" "));

    function getBoundary(char1, char2) {
        return char1 < char2 
            ? [char1, char2]
            : [char2, char1]
    }

    function getCharsBetween(start, end) {
        let result = "";

        for(let i = start.charCodeAt(0) + 1; i < end.charCodeAt(0); i++) {
            result += String.fromCharCode(i) + " ";
        }

        return result;
    }
}

solve('a', 'd');
solve('#', ':');
solve('C', '#');
solve('@', '[');
solve('`', '{');