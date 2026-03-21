function getSign(...nums) {
    let negativesCount = 0;

    for (num of nums) {
        if (checkIfNegative(num)) {
            negativesCount++;
        }
    }

    if (negativesCount % 2 == 0) {
        console.log("Positive");
    }  else {
        console.log("Negative");
    }

    function checkIfNegative(x) {
        return x < 0;
    }
}

getSign(5, 12, -15);
getSign(-6, -12, 14);
getSign(-1, -2, -3);
getSign(-5, 1, 1);