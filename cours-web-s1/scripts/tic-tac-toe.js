// On récupère les cases du jeu dans une collection
const cells = document.getElementsByClassName('game-cell')

function initialiserPartie() {
    let tour = 0

    // On parcours la collection, pour celà, on utilise la taille de cette dernière
    for (let i = 0; i < cells.length; i++) {
        const cell = cells[i] // On prend une case unitairement à chaque itération

        // On ajoute un événement au click sur la case
        cell.addEventListener('click', function click(ev) {
            /*
            if (tour % 2 === 0) {
                ev.target.player = 1
            } else {
                ev.target.player = 2
            }
            tour = tour + 1
            */
            // ev.target reférence l'élément HTML qui a reçu l'événement, ici, notre cellule
            // le dataset représente l'ensemble des attributs HTML d'un élément commençant par data-*
            // Ici, dataset.player est l'attribut data-player de la cellule
            ev.target.dataset.player = tour++ % 2 === 0 ? 1 : 2
            checkPartie(tour) // À chaque fin de tour, on regarder ou en est la partie
        }, { once: true }) // L'événement se déclenche une seule fois puis est retiré
    }
}

function checkPartie(tour) {
    // On vérifie chaque ligne et chaue colone
    for (let i = 0; i < 3; i++) {
        const col = document.querySelectorAll(`.game-cell[data-x="${i}"]`)
        getWinner(col[0], col[1], col[2])

        const row = document.querySelectorAll(`.game-cell[data-y="${i}"]`)
        getWinner(row[0], row[1], row[2])
    }

    getWinner(cells[0], cells[4], cells[8])
    getWinner(cells[2], cells[4], cells[6])

    if (tour === 9) {
        alert(`Egalité`)
        document.location.reload()
    }
}

function getWinner(cell1, cell2, cell3) {
    if (cell1.dataset.player === "none" || cell2.dataset.player === "none" || cell3.dataset.player === "none")
        return

    if (cell1.dataset.player === cell2.dataset.player && cell1.dataset.player === cell3.dataset.player) {
        alert(`Le joueur ${cell1.dataset.player} a gagné`)
        document.location.reload()
    }
}

initialiserPartie()
