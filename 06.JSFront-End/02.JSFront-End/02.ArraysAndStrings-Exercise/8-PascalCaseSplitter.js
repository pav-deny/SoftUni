function solve(text = "") {
    const pattern = /[A-Z][a-z]*/g;
    let result = text.match(pattern);
    console.log(result.join(", "));
}

solve('SplitMeIfYouCanHaHaYouCantOrYouCan');
solve('HoldTheDoor');
solve('ThisIsSoAnnoyingToDo');