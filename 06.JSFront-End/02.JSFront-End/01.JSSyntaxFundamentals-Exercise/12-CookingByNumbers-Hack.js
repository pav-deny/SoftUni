function solve(numAsString, operation1, operation2, operation3, operation4, operation5) {
    let currentNum = Number(numAsString);

    const operations = operation1[0] + operation2[0] + operation3[0] + operation4[0] + operation5[0];

    for (let i = 0; i < operations.length; i++) {
        currentNum = executeOperation(currentNum, operations[i]);
        console.log(currentNum);
    }

    function executeOperation(num, operation) {
        switch (operation) {
            case "c":
                return num / 2;

            case "d":
                return Math.sqrt(num);

            case "s":
                return num + 1;

            case "b":
                return num * 3;

            case "f":
                return num - (num * 0.20);
        }
    }
}

solve('32', 'chop', 'chop', 'chop', 'chop', 'chop');
console.log("-------")
solve('9', 'dice', 'spice', 'chop', 'bake', 'fillet');