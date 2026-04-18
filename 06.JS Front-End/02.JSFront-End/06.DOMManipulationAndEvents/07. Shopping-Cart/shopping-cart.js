document.addEventListener('DOMContentLoaded', solve);

function solve() {
   let products = new Set();
   let totalPrice = 0.00;

   const allAddBtnsElements = document.querySelectorAll(".add-product");
   const textAreaElement = document.querySelector("textarea");
   const checkoutBtnElement = document.querySelector(".checkout");

   for (const addBtnElement of allAddBtnsElements) {
      addBtnElement.addEventListener("click", handleProductAddition);
   }

   checkoutBtnElement.addEventListener("click", handleCheckout);

   function handleProductAddition(e) {
      const productDivElement = e.target.parentElement.parentElement;

      const productTitleElement = productDivElement.querySelector(".product-title");
      const productTitle = productTitleElement.textContent;
      products.add(productTitleElement.textContent);

      const productPriceElement = productDivElement.querySelector(".product-line-price");
      const productPrice = Number(productPriceElement.textContent);
      totalPrice += productPrice;

      textAreaElement.value += `Added ${productTitle} for ${productPrice.toFixed(2)} to the cart.\n`
   }

   function handleCheckout(e) {
      const productsArr = Array.from(products);
      textAreaElement.value += `You bought ${productsArr.join(", ")} for ${totalPrice.toFixed(2)}.`;

      checkoutBtnElement.disabled = true;
      
      for (const btnElement of allAddBtnsElements) {
         btnElement.disabled = true;
      }
   }
}
