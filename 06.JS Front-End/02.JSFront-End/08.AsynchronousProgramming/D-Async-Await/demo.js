function resolveAfter2Seconds() {
    return new Promise((resolve, reject) => {
        setTimeout(() => {
            resolve("resolved :)")
            reject("rejected :(");
        }, 2000);
    });
}

function rejectAfter2Seconds() {
    return new Promise((resolve, reject) => {
        setTimeout(() => {
            reject("rejected :(");
        }, 2000);
    });
}

async function asyncCall() {
    console.log("calling...");
    
    let result = await resolveAfter2Seconds();
    console.log(result);

    try {
        result = await rejectAfter2Seconds();
    }   catch (err) {
        console.log(err);
    }
}

asyncCall();
console.log("This should be after \"calling...\"");