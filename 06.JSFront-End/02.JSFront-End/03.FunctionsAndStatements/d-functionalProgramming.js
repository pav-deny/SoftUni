function transformToUpperCase(text = "") {
    return text.toUpperCase();
}

function transformToLowerCase(text = "") {
    return text.toLowerCase();
}

function printFormatedText(text, transformFunction) {
    console.log(transformFunction(text));
}

printFormatedText("HELLO THERE", transformToLowerCase);
printFormatedText("general kenobi", transformToUpperCase);