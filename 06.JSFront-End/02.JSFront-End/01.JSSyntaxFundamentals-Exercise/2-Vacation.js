function solve(groupSize, groupType, day) {
    let singlePrice = 0;

    //Find single ticket price

    singlePrice = getSinglePrice(groupType, day);

    //Find total price

    let totalPrice = groupSize * singlePrice;

    //Apply discount

    if (groupType === "Students" && groupSize>= 30) {
        totalPrice -= totalPrice * 0.15;
    }   
    
    if (groupType === "Business" && groupSize >= 100) {
        totalPrice -= singlePrice * 10;
    }   
    
    if (groupType === "Regular" && (groupSize >= 10 && groupSize <= 20)) {
        totalPrice -= totalPrice * 0.05;
    }

    //Print result
    console.log(`Total price: ${totalPrice.toFixed(2)}`);
    

    //Get Single Price Functions

    function getSinglePrice(groupType, day) {
        switch (groupType) {
        case "Students":
            return getStudentSinglePrice(day);
            break;  

        case "Business":
            return getBusinessSinglePrice(day);
            break;

        case "Regular":
            return getRegularSinglePrice(day);
            break;
    }
    }

    function getStudentSinglePrice(day) {
        if (day === "Friday") {
                return 8.45;
            } else if (day === "Saturday") {
                return 9.80;
            }   else if (day === "Sunday") {
                return 10.46
            }
    }

    function getBusinessSinglePrice(day) {
         if (day === "Friday") {
                return 10.90;
            } else if (day === "Saturday") {
                return 15.60;
            }   else if (day === "Sunday") {
                return 16.00;
            }
    }

    function getRegularSinglePrice(day) {
        if (day === "Friday") {
                return 15.00;
            } else if (day === "Saturday") {
                return 20.00;
            }   else if (day === "Sunday") {
                return 22.50;
            }
    }
}

solve(30,"Students","Sunday");
console.log("-------------------")
solve(40,"Regular","Saturday");