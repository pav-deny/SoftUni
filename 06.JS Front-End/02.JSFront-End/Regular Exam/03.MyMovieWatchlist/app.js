const loadMoviesBtnEl = document.getElementById("load-movies");
const moviesDivEl = document.getElementById("movie-list");

const editMoviesBtn = document.getElementById("edit-movie");
const addMovieBtn = document.getElementById("add-movie");

const titleInputEl = document.getElementById("title");
const directorInputEl = document.getElementById("director");
const yearInputEl = document.getElementById("year");

let editId = 0;

loadMoviesBtnEl.addEventListener("click", loadMovies);
addMovieBtn.addEventListener("click", addMovie);
editMoviesBtn.addEventListener("click", confirmEdit);


async function loadMovies() {
    moviesDivEl.innerHTML = "";

    const res = await fetch("http://localhost:3030/jsonstore/movies/");
    const data = await res.json();

    const dataArr = Object.values(data);

    for (let movie of dataArr) {
        let titleEl = document.createElement("p");
        titleEl.textContent = movie.title;

        let directorEl = document.createElement("p");
        directorEl.textContent = movie.director;

        let yearEl = document.createElement("p");
        yearEl.textContent = movie.year;

        let currentMovieDiv = document.createElement("div");
        currentMovieDiv.className = "content";
        currentMovieDiv.appendChild(titleEl);
        currentMovieDiv.appendChild(directorEl);
        currentMovieDiv.appendChild(yearEl);

        let movieDivEl = document.createElement("div");
        movieDivEl.className = "movie";
        movieDivEl.appendChild(currentMovieDiv);

        let editBtnEL = document.createElement("button");
        editBtnEL.textContent = "Change";
        editBtnEL.className = "change-btn";
        editBtnEL.addEventListener("click", editMovie);

        let removeBtnEl = document.createElement("button");
        removeBtnEl.textContent = "Delete";
        removeBtnEl.className = "delete-btn";
        removeBtnEl.addEventListener("click", deleteMovie);

        let btnsContainerEl = document.createElement("div")
        btnsContainerEl.className = "buttons-container";

        btnsContainerEl.appendChild(editBtnEL);
        btnsContainerEl.appendChild(removeBtnEl);

        movieDivEl.appendChild(btnsContainerEl);

        moviesDivEl.appendChild(movieDivEl);
        editMoviesBtn.disabled = true;
        movieDivEl.dataset.id = movie._id;
    }
}

async function addMovie() {
    let title = titleInputEl.value;
    let director = directorInputEl.value;
    let year = yearInputEl.value;

    await fetch("http://localhost:3030/jsonstore/movies/", {
        method: "POST",
        headers: {
            "Content-Type": "appliction/json"
        },
        body: JSON.stringify({
            title,
            director,
            year
        })
    });

    titleInputEl.value = "";
    directorInputEl.value = "";
    yearInputEl.value = "";

    loadMovies();
}

async function editMovie(e) {
    const currentMovieEl = e.target.parentElement.parentElement;

    editId = currentMovieEl.dataset.id;

    const [title, director, year] = currentMovieEl.querySelectorAll(".content p");

    titleInputEl.value = title.textContent;
    directorInputEl.value = director.textContent;
    yearInputEl.value = year.textContent;

    addMovieBtn.disabled = true;
    editMoviesBtn.disabled = false;

    currentMovieEl.remove();
}

async function confirmEdit(e) {
    await fetch (`http://localhost:3030/jsonstore/movies/${editId}`, {
        method: "PUT",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            title: titleInputEl.value,
            director: directorInputEl.value,
            year: yearInputEl.value
        })
    });

    titleInputEl.value = "";
    directorInputEl.value = "";
    yearInputEl.value = "";

    addMovieBtn.disabled = false;
    editMoviesBtn.disabled = true;

    loadMovies();
}

async function deleteMovie(e) {
    const movieEl = e.target.parentElement.parentElement;
    const id = movieEl.dataset.id;

    await fetch(`http://localhost:3030/jsonstore/movies/${id}`, {
        method: "DELETE"
    });

    loadMovies();
}