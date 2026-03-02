function solve(text = "") {
    const result = text.split(/(?=[A-Z])/g);

    console.log(result.join(", "));
}

solve('SplitMeIfYouCanHaHaYouCantOrYouCan');
solve('HoldTheDoor');
solve('ThisIsSoAnnoyingToDo');