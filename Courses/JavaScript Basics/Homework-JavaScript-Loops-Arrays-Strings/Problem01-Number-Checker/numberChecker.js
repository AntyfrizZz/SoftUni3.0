function printNumbers(n) {
    var resultNumbers = [], 
        i;
    
    for (i = 1; i <= n; i++) {
        if (i % 4 !== 0 && i % 5 !== 0) {
            resultNumbers.push(i);
        }
    }
    
    if (n <= 0) {
        resultNumbers.push('no');
    }
    
    console.log(resultNumbers.join(', '));
}

printNumbers(20);
printNumbers(-5);
printNumbers(13);