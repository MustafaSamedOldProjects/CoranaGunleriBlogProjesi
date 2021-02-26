var selectElem = document.getElementById('selectlist-kategori');

// When a new <option> is selected
selectElem.addEventListener('change', function () {
    var index = selectElem.selectedIndex +1;
    // Add that data to the <p>
    for (var i = 0; i < index; i++) {
        selectElem.children[i].setAttribute("selected",true);
    }
})

var a = document.getElementById('selectlist-tag');

// When a new <option> is selected
a.addEventListener('change', function () {
    var b = a.selectedIndex +1 ;
    // Add that data to the <p>
    for (var i = 0; i < b; i++) {
        a.children[i].setAttribute("selected", true);
    }
})