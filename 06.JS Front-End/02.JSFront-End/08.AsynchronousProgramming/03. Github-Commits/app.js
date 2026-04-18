async function loadCommits() {
    const usernameInputEl = document.getElementById("username");
    const repoInputEl = document.getElementById("repo");
    const comitsUlEl = document.getElementById("commits");

    const username = usernameInputEl.value.trim();
    const repo = repoInputEl.value.trim();

    const response = await fetch(`https://api.github.com/repos/${username}/${repo}/commits`);

    if (!response.ok) {
        const liElement = document.createElement("li");
        liElement.textContent = `Error: ${response.status} (Not Found)`;
        comitsUlEl.appendChild(liElement);
        return;
    }

    const data = await response.json();

    for (const commitObj of data) {
        const liElement = document.createElement("li");
        liElement.textContent = `${commitObj.commit.author.name} : ${commitObj.commit.message}`;
        comitsUlEl.appendChild(liElement);
    }
}