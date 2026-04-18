function getFormattedGrade(grade) {
    let formattedGrade = "";
    
    if (grade >= 5.50) {
        formattedGrade = "Excellent";
    } else if (grade >= 4.50) {
        formattedGrade = "Very good";
    } else if (grade >= 3.50) {
        formattedGrade = "Good";
    }  else if (grade >= 3.00) {
        formattedGrade = "Poor";
    } else {
        console.log("Fail (2)");
        return;
    }
    
    console.log(`${formattedGrade} (${grade.toFixed(2)})`)
}

getFormattedGrade(3.33);
getFormattedGrade(4.50);
getFormattedGrade(2.99);