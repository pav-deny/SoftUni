async function loadRepos() {
   const outputDivEl = document.getElementById("res");
   const result = await fetch("https://api.github.com/users/testnakov/repos");
   const resultTxt = await result.text();

   outputDivEl.textContent = resultTxt;
}