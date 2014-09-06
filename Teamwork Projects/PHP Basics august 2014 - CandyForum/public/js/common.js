function addPost(){
    location.href = '/posts/create';
}
function addAnswer(){
    /*
    var answer_form = $('#answer-form');
    answer_form.show();
    */
    document.getElementById('answer-form').style.display = 'block';
    $('.answerBox').append(answer_form);
    $('#answer-button').hide();
}