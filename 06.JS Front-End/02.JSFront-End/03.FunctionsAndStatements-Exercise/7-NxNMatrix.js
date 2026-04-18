function solve(num) {
    printMatrix(num);

    function printMatrix(num) {
        for (let i = 0; i < num; i++) {
            printRow(num);
        }
    }

    function printRow(num) {
        let output = "";
        for (let i = 0; i < num; i++) {
            output += num + " ";
        }

        console.log(output.trimEnd(" "));
    }
}

solve(3);
solve(7);
solve(2);