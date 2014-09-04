function sortArray(arr) {
    
    function min(startIndex) {
        
        var minValue = this[startIndex],
            indexMinValue = startIndex,
            len = this.length,
            i;
        
        for (i = startIndex; i < len; i++) {
            if (minValue > this[i]) {
                minValue = this[i];
                indexMinValue = i;
            }
        }
        
        return indexMinValue;
    }
    
    function swap(firstIndex, secondIndex) {
        var temp = this[firstIndex];
        this[firstIndex] = this[secondIndex];
        this[secondIndex] = temp;
    }
    
    Array.prototype.min = min;
    Array.prototype.swap = swap;
    
    var len = arr.length,
        currentIndex,
        minValueIndex;
    
    for (currentIndex = 0; currentIndex < len; currentIndex++) {
        minValueIndex = arr.min(currentIndex);
        if (currentIndex !== minValueIndex) {
            arr.swap(currentIndex, minValueIndex)
        }
    }
    
    return arr;
}

console.log(sortArray([5, 4, 3, 2, 1]).join(', '));
console.log(sortArray([12, 12, 50, 2, 6, 22, 51, 712, 6, 3, 3]).join(', '));