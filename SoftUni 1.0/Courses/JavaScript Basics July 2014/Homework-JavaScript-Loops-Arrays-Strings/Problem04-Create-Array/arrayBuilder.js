function createArray() {
    var arr = [],
        i = 1;
    
    for (i = 0; i < 20; i += 1) {
        arr[i] = i * 5;
    }
    
    return arr;
}

console.log(createArray());