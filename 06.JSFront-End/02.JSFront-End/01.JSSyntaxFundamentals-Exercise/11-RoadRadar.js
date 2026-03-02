function solve(speed, roadType) {
    let speedLimit = getLImit(roadType);


    if (speed > speedLimit) {
        let difference = speed - speedLimit;
        let status = getSeverityStatus(difference);
        
        console.log(`The speed is ${difference} km/h faster than the allowed speed of ${speedLimit} - ${status}`)
        return;
    }

    console.log( `Driving ${speed} km/h in a ${speedLimit} zone`)
    
    
    function getLImit(roadType) {
        switch(roadType)
        {
            case "residential":
                return 20;

            case "city":
                return 50;

            case "interstate":
                return 90;

            case "motorway":
                return 130;
        }
    }

    function getSeverityStatus(difference) {
        
        if (difference <= 20) {
            return "speeding";
        } else if (difference <= 40) {
            return "excessive speeding";
        } 

        return "reckless driving";
    }
}

solve(40, 'city');
solve(21, 'residential');
solve(120, 'interstate');
solve(200, 'motorway');