let promise = new Promise(function(resolve, reject){
    setTimeout(() => resolve("all is good :)"), 5000)
});

promise.then(value => console.log(value)).finally(() => console.log("all done :)"));

let failedPromise = new Promise(function(resolve, reject){
    setTimeout(() => reject("ruh oh :("), 5000)
});

failedPromise.catch(err => console.log("Error:", err)).finally(() => console.log("all NOT done :("));

let shortPromise = Promise.resolve("END");