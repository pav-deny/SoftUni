function colorize() {
    let evenTableRows = document.querySelectorAll("tbody tr:nth-child(even)");
    
    for (let tr of evenTableRows) {
        tr.style.backgroundColor = "teal";
        tr.style.color = "white"; //Added later will cause error in Judge
    }
}