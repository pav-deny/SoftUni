function solve(typeOfDay, age) {
    let price = 0;
    
    if (age > 64 && age <= 122) {
        switch (typeOfDay) {
            case "Weekday":
                price = 12;
            break;
        
         case "Weekend":
                price = 15;
            break;

        case "Holiday":
                price = 10;
            break;
        }
    } else if (age > 18 && age <= 64) {
        switch (typeOfDay) {
            case "Weekday":
                price = 18;
            break;
        
         case "Weekend":
                price = 20;
            break;

        case "Holiday":
                price = 12;
            break;
        }
    } else if (age >= 0 && age <= 18) {
        switch (typeOfDay) {
            case "Weekday":
                price = 12;
            break;
        
         case "Weekend":
                price = 15;
            break;

        case "Holiday":
                price = 5;
            break;
        }
    }  else {
        console.log("Error!");
        return;
    }

    console.log(`${price}$`)
}

solve('Weekday', 42);
solve('Holiday', -12);
solve('Holiday', 15);