(function () {
    var time = process.hrtime();
    //console.log(solve(287, 0, false));
    console.log(solve(287));
    var diff = process.hrtime(time);
    console.log(diff);
})();

// function* solve (n, t, found) {
//     if (found) return t;

//     var next = getTriangular(n);
//     var isWinner = isPentagonal(next);
//     yield solve(n + 2, next, isWinner);
// }

function solve (n) {
    var found = false;
    var candidate = 0;

    while (!found) {
        candidate = getTriangular(n);
        found = isPentagonal(candidate);
        n = n + 2;
    }

    return candidate;
}

function getTriangular (n) {
    return n * (n+1)/2;
}

function isPentagonal (n) {
    var num = Math.sqrt(1 + 24 * n) + 1;
    return num % 6 == 0;
}
