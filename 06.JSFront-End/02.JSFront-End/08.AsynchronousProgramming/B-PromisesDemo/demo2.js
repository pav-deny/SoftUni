let promise1 = Promise.resolve("test 1");
let promise2 = Promise.resolve("test 2");
let promise3 = Promise.resolve("test 3");

Promise.all([promise1,promise2,promise3]).then(r => console.log(r)).catch(err => console.log(err));

promise2 = Promise.reject("test 2");
Promise.all([promise1,promise2,promise3]).then(r => console.log(r)).catch(err => console.log(err));

promise2 = Promise.reject("test 2");
promise3 = Promise.reject("test 3");
Promise.all([promise1,promise2,promise3]).then(r => console.log(r)).catch(err => console.log(err));
