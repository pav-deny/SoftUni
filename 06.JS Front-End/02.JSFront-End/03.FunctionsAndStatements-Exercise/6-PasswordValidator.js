function solve(password = "") {
    let isValid = true;

    if (!checkLength(password)) {
        isValid = false;
    }

    if (!checkElements(password)) {
        isValid = false;
    }

    if (!checkDigitsCount(password)) {
        isValid = false;
    }

    if (isValid) {
        console.log("Password is valid");
    }

    function checkLength(password) {
        if (password.length >= 6 && password.length <= 10) {
            return true;
        }  

        console.log("Password must be between 6 and 10 characters");
        return false;
    }

    function checkElements(password = "") {
        let pattern = /^[A-Za-z0-9]+$/;

        let isValid = pattern.test(password);

        if (!isValid) {
            console.log("Password must consist only of letters and digits");
            return false;
        }

        return true;
    }

    function checkDigitsCount(password = "") {
        let isValid = true;

        let digits = password.split("").filter(a => Number(a) >= 0);

        if (digits.length < 2) {
            isValid = false;
            console.log("Password must have at least 2 digits");
        } 

        return isValid;
    }
}

solve('logIn');
solve('MyPass123');
solve('Pa$s$s');