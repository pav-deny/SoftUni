function solve(num) {
    const numAsString = num.toString();

    const firstChar = numAsString[0];
    let areSameNumber = true;
    let sum = 0;

    for (let i = 0; i < numAsString.length; i++) {
        if (numAsString[i] != firstChar) {
            areSameNumber = false;
        }

        sum += Number(numAsString[i]);
        // sum += parseInt(numAsString[i]);
        // sum += +numAsString[i];
    }

    console.log(areSameNumber);
    console.log(sum);
}

solve(2222222);
solve(1234);