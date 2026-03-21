function flipArray(arr = []) {
    console.log(arr);
    let result = [];

    for (let i = 0; i < arr.length / 2; i++) {
        result = swapTwoElements(arr, i, arr.length - 1 - i);
    }
    
    console.log(result);
    
    function swapTwoElements(arr = [], index1, index2) {
        let temp = arr[index1];
    
        arr[index1] = arr[index2];
        arr[index2] = temp;
    
        return arr;
    }
}


flipArray([1, 2, 3, 4, 5, 6, 7, 8, 9, 10]);
console.log("------------------------------")
flipArray([1, 3, 5, 7, 9]);
console.log("------------------------------")
flipArray([2, 4, 6, 8, 10]);
console.log("------------------------------")
