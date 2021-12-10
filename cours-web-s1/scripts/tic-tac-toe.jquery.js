let tour = 0;
$('.game-cell').one('click', function click() { //
    $(this).attr('data-player', tour++ % 2 === 0 ? 1 : 2) //
    checkPartie(tour)
})

function checkPartie(tour) {
    // On vérifie chaque ligne et chaue colone
    for (let i = 0; i < 3; i++) {
        getWinner($(`.game-cell[data-x="${i}"]`))
        getWinner($(`.game-cell[data-y="${i}"]`))
    }

    getWinner($(`.game-cell[data-diag1]`))
    getWinner($(`.game-cell[data-diag2]`))

    if (tour === 9) {
        alert(`Egalité`)
        document.location.reload()
    }
}

function getWinner($items) {
    const players = []
    $items.each(function each() {
        // On ajoute le player au tableau
        players.push($(this).attr('data-player')) //
    })

    if (players.some(function some(p) { return p === "none" }))
        return

    if (players.every((p) => p === players[0])) {
        alert(`Le joueur ${players[0]} a gagné`)
        document.location.reload()
    }
}