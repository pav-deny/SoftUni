async function loadRepos() {
	const usernameInputEl = document.getElementById("username");
	const ulElement = document.getElementById("repos");
	
	const username = usernameInputEl.value.trim();
	const result = await fetch(`https://api.github.com/users/${username}/repos`);
	const data = await result.json();

	ulElement.innerHTML = "";
	
	for (let repoObj of data) {
		const liElement = document.createElement("li");
		const aElement = document.createElement("a");

		aElement.textContent = repoObj.full_name;
		aElement.href = repoObj.html_url;

		liElement.appendChild(aElement);
		ulElement.appendChild(liElement);
	}
}