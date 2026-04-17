function solve(currentStockInput = [], ordered = []) {

    let store = getItems(currentStockInput);
    store = restock(store, ordered);
    printItems(store);

    function getItems(input) {
        let result = {};

        for (let i = 0; i < input.length; i += 2) {
            result[input[i]] = Number(input[i + 1]);
        }

        return result;
    }

    function restock(store, ordered) {
        for (let i = 0; i < ordered.length; i += 2) {
            let product = ordered[i];
            let quantity = Number(ordered[i + 1]);

            if (store[product] != undefined) {
                store[product] += quantity;
            }  else {
                store[product] = quantity;
            }
        }

        return store;
    }

    function printItems(store) {
        let entries = Object.entries(store);

        for ([product, quantity] of entries) {
            console.log(`${product} -> ${quantity}`);
        }
    }
}

solve ([
'Chips', '5', 'CocaCola', '9', 'Bananas', '14', 'Pasta', '4', 'Beer', '2'
],
[
'Flour', '44', 'Oil', '12', 'Pasta', '7', 'Tomatoes', '70', 'Bananas', '30'
])