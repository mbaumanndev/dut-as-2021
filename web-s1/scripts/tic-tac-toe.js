const cells = document.getElementsByClassName('game-cell')

function initialiserPartie() {
    let tour = 0

    for (let i = 0; i < cells.length; i++) {
        const cell = cells[i]
    
        cell.addEventListener('click', function click(ev) {
            /*
            if (tour % 2 === 0) {
                ev.target.player = 1
            } else {
                ev.target.player = 2
            }
            tour = tour + 1
            */
            ev.target.dataset.player = tour++ % 2 === 0 ? 1 : 2
            checkPartie()
        }, { once: true })
    }
}

function checkPartie() {
    for (let i = 0; i < 3; i++) {
        const col = document.querySelectorAll(`.game-cell[data-x=${i}]`)
    }
}

initialiserPartie()
