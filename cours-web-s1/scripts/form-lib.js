const forms = document.querySelectorAll('form[data-validate-form]')

// On parcours les formulaires
for (let i = 0; i < forms.length; i++) {
    const form = forms[i]
    // On récupère les champs et les pousse dans un tableau
    const temp = form.querySelectorAll('input[data-validate], select[data-validate], textarea[data-validate]')
    const inputList = []

    for (let j = 0; j < temp.length; j++)
        inputList.push(temp[j])

    // On ajoute les écouteurs d'event au formulaire courant
    form.addEventListener('submit', function submit(ev) {
        // Pour chacun des champs, pn effectue les vérifications
        inputList.forEach(function cb(input) {
            // On récupère le span associé à l'input
            const errorSpan = form.querySelector(`span[data-error=${input.name}]`)
            // On définit une liste d'erreurs
            const errorList = []

            // Si la propriété min-length est définie, on vérifie
            if (input.dataset.minLength !== undefined) {
                if (input.value.length < parseInt(input.dataset.minLength)) {
                    ev.preventDefault()
                    errorList.push(input.dataset.minLengthError)
                }
            }
            // Si la propriété max-length est définie, on vérifie
            if (input.dataset.maxLength !== undefined) {
                if (input.value.length > parseInt(input.dataset.maxLength)) {
                    ev.preventDefault()
                    errorList.push(input.dataset.maxLengthError)
                }
            }

            // On joint les erreurs, si la liste est vide, on vide le span
            errorSpan.innerText = errorList.join(', ')
        })
    })

    form.addEventListener('reset', function reset() {

    })
}