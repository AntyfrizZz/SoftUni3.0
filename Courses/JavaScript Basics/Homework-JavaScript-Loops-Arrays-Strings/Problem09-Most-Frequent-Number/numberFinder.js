function findMostFreqNum(inputValue) {
    
    var results = [],
        i;
    
    for (i in inputValue) {
        if (inputValue[i] in results) {
            results[inputValue[i]]++;
        } else {
            results[inputValue[i]] = 1;
        }
    }
    
    var maxCountTimes = 0,
        value;
    
    for (i = 0; i < results.length; i += 1) {
        if (maxCountTimes < results[i]) {
            maxCountTimes = results[i];
            value = i;
        }
    }
    
    return value + ' (' + maxCountTimes + ' times)';
}

console.log(findMostFreqNum([4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3]));
console.log(findMostFreqNum([2, 1, 1, 5, 7, 1, 2, 5, 7, 3, 87, 2, 12, 634, 123, 51, 1]));
console.log(findMostFreqNum([1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13]));