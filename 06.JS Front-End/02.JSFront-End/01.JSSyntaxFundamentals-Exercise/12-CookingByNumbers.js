function solve(numAsString, operation1, operation2, operation3, operation4, operation5) {
    let currentNum = Number(numAsString);

    currentNum = executeOperation(currentNum, operation1);
    currentNum = executeOperation(currentNum, operation2);
    currentNum = executeOperation(currentNum, operation3);
    currentNum = executeOperation(currentNum, operation4);
    currentNum = executeOperation(currentNum, operation5);


    function executeOperation(num, operation) {
        switch (operation) {
            case "chop":
                num /= 2;
                break;

            case "dice":
                num = Math.sqrt(num);
                break;

            case "spice":
                num += 1;
                break;

            case "bake":
                num *= 3;
                break;

            case "fillet":
                num -= (num * 0.20);
                break;
        }

        console.log(num);
        return num;
    }
}

solve('32', 'chop', 'chop', 'chop', 'chop', 'chop');
console.log("-------")
solve('9', 'dice', 'spice', 'chop', 'bake', 'fillet');