const form = document.getElementById('form')
const subject = document.getElementById('subject')
const copie = document.getElementById('copie')
const body = document.getElementById('body')
const subjectError = document.getElementById('subjectError')
const bodyError = document.getElementById('bodyError')

form.addEventListener('submit', function submit(ev) {
    if (subject.value.length < 3) {
        ev.preventDefault()
        subjectError.innerText = 'Le sujet doit contenir trois caractères minimum'
    } else {
        subjectError.innerText = ''
    }

    if (body.value.length < 20) {
        ev.preventDefault()
        bodyError.innerText = 'Le corps du mail doit contenir vingt caractères minimum'
    } else {
        bodyError.innerText = ''
    }
})
form.addEventListener('reset', function reset() {
    subjectError.innerText = ''
    bodyError.innerText = ''
})
