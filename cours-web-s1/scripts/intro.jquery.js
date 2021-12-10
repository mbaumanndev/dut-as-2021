let count = 0
$('div').on('click', function click() {
    if (count % 2 === 0) {
        $(this).css({
            width: '200px',
            height: '200px',
            backgroundColor: 'blue'
        })
    } else {
        $(this).css({
            width: '100px',
            height: '100px',
            backgroundColor: 'red'
        })
    }
    count++
})

//let show = true
$('.toggleText').on('click', function click() {
    /*
    if (show) {
        $('.text').hide()
    } else {
        $('.text').show()
    }
    show = !show
    */
   $('.text').toggle()
})












