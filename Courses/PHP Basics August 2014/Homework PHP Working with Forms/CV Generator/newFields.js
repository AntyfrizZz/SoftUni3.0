function addFieldProgrammingLang(ev) {
    var button = ev.target;
    var div = document.createElement('div');
    div.innerHTML = '<input type="text" name="Computer Skills[Programming Languages][Language][]" pattern="[A-Za-zА-яа-я]{2,20}">' +
        '<select name="Computer Skills[Programming Languages][Skill Level][]">' +
        '<option value="beginner">Beginner</option>' +
        '<option value="average">Average</option>' +
        '<option value="advanced">Advanced</option>' +
        '<option value="excellent">Excellent</option>' +
        '</select>' +
        '<input type="button" name="remove" value="Remove">';

    var programmingLang = document.getElementById('programmingLang');
    programmingLang.appendChild(div);
}

var button1 = document.getElementById('AddProgramLang');
button1.addEventListener('click', addFieldProgrammingLang);


function addFieldLang(ev) {
    var button = ev.target;
    var div = document.createElement('div');
    div.innerHTML = '<input type="text" name="Other Skills[Languages][Language][]" pattern="[A-Za-zА-яа-я]{2,20}">' +
        '<select name="Other Skills[Languages][Comprehension][]">' +
        '<option value="comprehension" selected disabled>-Comprehension-</option>' +
        '<option value="beginner">Beginner</option>' +
        '<option value="average">Average</option>' +
        '<option value="excellent">Excellent</option>' +
        '</select>' +
        '<select name="Other Skills[Languages][Reading][]">' +
        '<option value="reading" selected disabled>-Reading-</option>' +
        '<option value="beginner">Beginner</option>' +
        '<option value="average">Average</option>' +
        '<option value="excellent">Excellent</option>' +
        '</select>' +
        '<select name="Other Skills[Languages][Writing][]">' +
        '<option value="writing" selected disabled>-Writing-</option>' +
        '<option value="beginner">Beginner</option>' +
        '<option value="average">Average</option>' +
        '<option value="excellent">Excellent</option>' +
        '</select>' +
        '<input type="button" name="remove" value="Remove">';

    var programmingLang = document.getElementById('Lang');
    programmingLang.appendChild(div);
}

var button2 = document.getElementById('AddLang');
button2.addEventListener('click', addFieldLang);


function removeField(ev){
    var button = ev.target;
    if(button.name == 'remove') {
        var parent = button.parentNode;
        var wrapper = parent.parentNode;
        wrapper.removeChild(parent);
    }
}

document.addEventListener('click', removeField);