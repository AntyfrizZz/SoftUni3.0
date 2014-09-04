var hideButton = document.getElementById('btnHideOddRows');

hideButton.onclick = function hideOddRows() {

    var rows = document.getElementsByTagName('tr');
    for (var i = 0; i < rows.length; i++) {
        rows[i].parentNode.removeChild(rows[i]);
    }
}