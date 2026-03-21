function getTotalPrice(item, count) {
    let price = 0;

    switch (item) {
        case "coffee":
            price = 1.50;
            break;
        
        case "water":
            price = 1.00;
            break;

        case "coke":
            price = 1.40;
            break;

        case "snacks":
            price = 2.00;
            break;
    }
    let totalPrice = price * count;
    console.log(`${totalPrice.toFixed(2)}`);
}

getTotalPrice("water", 5);
getTotalPrice("coffee", 2);