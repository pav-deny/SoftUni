function solve(numAsString, ...operations) {
    let currentNum = Number(numAsString);

    for (let i = 0; i < operations.length; i++) {
        currentNum = executeOperation(currentNum, operations[i]);
        console.log(currentNum);
    }

    function executeOperation(num, operation) {
        switch (operation) {
            case "chop":
                return num / 2;

            case "dice":
                return Math.sqrt(num);

            case "spice":
                return num + 1;

            case "bake":
                return num * 3;

            case "fillet":
                return num - (num * 0.20);
        }
    }
}

solve('32', 'chop', 'chop', 'chop', 'chop', 'chop');
console.log("-------")
solve('9', 'dice', 'spice', 'chop', 'bake', 'fillet');