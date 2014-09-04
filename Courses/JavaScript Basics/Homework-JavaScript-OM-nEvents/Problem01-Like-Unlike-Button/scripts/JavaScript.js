function likeUnlikeButton() {
    var button = document.getElementById("button");

    if (button.innerText == "Like") {
        button.innerText = "Unlike";
    } else {
        button.innerText = "Like";
    }
}