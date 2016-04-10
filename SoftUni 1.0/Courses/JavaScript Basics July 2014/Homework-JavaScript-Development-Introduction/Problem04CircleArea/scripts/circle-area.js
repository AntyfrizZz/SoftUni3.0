function calcCircleArea(r) {
    return Math.PI * (r * r);
}

document.getElementById("area").innerHTML = calcCircleArea(7);
document.getElementById("secondArea").innerHTML = calcCircleArea(1.5);
document.getElementById("thirdArea").innerHTML = calcCircleArea(20);