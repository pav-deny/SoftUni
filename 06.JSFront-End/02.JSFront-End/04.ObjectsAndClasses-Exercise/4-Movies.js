function solve(input = []) {
    let movies = [];

    input.forEach(row => {
        let command = getCommand(row);

        switch (command) {
            case "addMovie":
                addMovie(row);
                break;

            case "onDate":
                addDate(row);
                break;

            case "directedBy":
                addDirector(row);
                break;
        }
    })

    printMovies(movies);

    function getCommand(input) {
        const commands = ["addMovie", "directedBy", "onDate"];

        let result = commands.find(c => input.includes(c));
        return result;
    }

    function addMovie(input = "") {
        let movieName = input.substring(9);

        let movie = {
            name: movieName
        };

        movies.push(movie);
    }

    function addDirector(input = "") {
        let [movieName, directorName] = input.split(" directedBy ");

        let movie = movies.find(movie => movie.name === movieName);

        if (!movie) {
            return;
        }

        movie.director = directorName;
    }

    function addDate(input = "") {
        let [movieName, date] = input.split(" onDate ");

        let movie = movies.find(movie => movie.name === movieName);

        if (!movie) {
            return;
        }

        movie.date = date;
    }

    function printMovies(movies) {
        for (movie of movies) {
            if (movie.director && movie.date) {
                console.log(JSON.stringify(movie));
            }
        }
    }
}

solve([
    'addMovie Fast and Furious',
    'addMovie Godfather',
    'Inception directedBy Christopher Nolan',
    'Godfather directedBy Francis Ford Coppola',
    'Godfather onDate 29.07.2018',
    'Fast and Furious onDate 30.07.2018',
    'Batman onDate 01.08.2018',
    'Fast and Furious directedBy Rob Cohen'
]);

solve([
    'addMovie The Avengers',
    'addMovie Superman',
    'The Avengers directedBy Anthony Russo',
    'The Avengers onDate 30.07.2010',
    'Captain America onDate 30.07.2010',
    'Captain America directedBy Joe Russo'
]);