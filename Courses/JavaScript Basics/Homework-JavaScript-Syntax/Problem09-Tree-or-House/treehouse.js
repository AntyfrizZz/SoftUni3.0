function treeHouseCompare() {
    var a = arguments[0];
    var b = arguments[1];

    var houseArea = (a * a) + ((a * (a * 2 / 3)) / 2);
    var treeArea = b * (b / 3) + Math.PI * (b * 2 / 3) * (b * 2 / 3);

    if (houseArea > treeArea) {
        return "house/" + houseArea.toFixed(2);
    } else {
        return "tree/" + treeArea.toFixed(2);
    }
}

console.log(treeHouseCompare(3, 2));
console.log(treeHouseCompare(3, 3));
console.log(treeHouseCompare(4, 5));