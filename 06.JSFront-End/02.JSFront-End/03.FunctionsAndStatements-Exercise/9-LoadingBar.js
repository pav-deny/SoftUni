function solve(percent) {
    let progressBar = getProgressBar(percent);
    
    if (percent === 100) {
        renderCompletedProgressBar(progressBar)
    } else {
        renderLoadingProgressBar(progressBar, percent);
    }

    function getProgressBar(percent) {
        let steps = Math.floor(percent / 10);

        let completedSteps = "%".repeat(steps);
        let stepsLeft = ".".repeat(10 -steps)

        let progressBar = "[" + completedSteps + stepsLeft + "]";

        return progressBar;
    }

    function renderLoadingProgressBar(progressBar, percent) {
        console.log(`${percent}% ${progressBar}`);
        console.log("Still loading...");
    }

    function renderCompletedProgressBar(progressBar) {
        console.log("100% Complete!");
        console.log(progressBar);
    }
}

solve(30);
solve(50);
solve(100);