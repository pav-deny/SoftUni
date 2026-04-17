fetch("https://jsonplaceholder.typicode.com/users")
    .then(r => r.json())
    .then(data => console.log(data))
    .catch(err => console.log(err)); //GET

fetch("https://jsonplaceholder.typicode.com/posts", {
    method: "POST",
    headers: {
        "Content-Type": "application/json"
    },
    body: JSON.stringify({ firstName: "Ivan", age: 20 })
}).then(r => r.json())
    .then(data => console.log(data))
    .catch(err => console.log(err)); //POST