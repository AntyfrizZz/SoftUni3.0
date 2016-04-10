function calcCylinderVol() {
    return Math.PI * arguments[0] * arguments[0] * arguments[1];
}

console.log(calcCylinderVol(2, 4).toFixed(3));
console.log(calcCylinderVol(5, 8).toFixed(3));
console.log(calcCylinderVol(12, 3).toFixed(3));