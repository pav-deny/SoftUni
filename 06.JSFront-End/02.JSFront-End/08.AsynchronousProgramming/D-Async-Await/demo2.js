// fetch("https://jsonplaceholder.typicode.com/users")
//     .then(r => r.json())
//     .then(data => console.log(data))
//     .catch(err => console.log(err)); 
//Promise

async function getData() {
    try {
        let result = await fetch("https://jsonplaceholder.typicode.com/users");
        let data = await result.json();
        console.log(data);
    } catch (err) {
        console.log(err);
    }
} //Async and Await

getData();