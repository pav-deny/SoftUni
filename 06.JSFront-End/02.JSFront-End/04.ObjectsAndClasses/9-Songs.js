function solve(input) {
    class Song {
        constructor(playlist, name, length) {
            this.playlist = playlist;
            this.name = name;
            this.legth = length;
        }
    }
    
    let n = Number(input[0]);
    let songs = [];
    
    for (let i = 1; i <= n; i++) {
        let [playlist, name, legth] = input[i].split("_");

        let song = new Song(playlist, name, legth);
        songs.push(song);
    }

    let playlistToPrint = input[n + 1];

    if (playlistToPrint === "all") {
        for (song of songs) {
            console.log(song.name);
        }
    }  else {
        let songsInPlaylist = songs.filter(a => a.playlist === playlistToPrint);

        for (song of songsInPlaylist) {
            console.log(song.name);
        }
    }
}

solve([3,
'favourite_DownTown_3:14',
'favourite_Kiss_4:16',
'favourite_Smooth Criminal_4:01',
'favourite']);

console.log("==========================");

solve([4,
'favourite_DownTown_3:14',
'listenLater_Andalouse_3:24',
'favourite_In To The Night_3:58',
'favourite_Live It Up_3:48',
'listenLater']);

console.log("==========================");

solve([2,
'like_Replay_3:15',
'ban_Photoshop_3:48',
'all']
);