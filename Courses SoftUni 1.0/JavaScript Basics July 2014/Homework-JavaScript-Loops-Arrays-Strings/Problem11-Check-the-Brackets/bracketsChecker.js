function checkBrackets(expression) {
    var bracketsCount = 0,
        i;
    
    for (i = 0; i < expression.length; i += 1) {
        if (expression[i] == '(') {
            bracketsCount++;
        } else if (expression[i] == ')') {
            bracketsCount--;
        }
        
        if (bracketsCount < 0) {
            return 'incorrect';
        }
    }
    
    if (bracketsCount > 0) {
        return 'incorrect';
    } else {
        return 'correct'
    }
}

console.log(checkBrackets('( ( a + b ) / 5 – d )'));
console.log(checkBrackets(') ( a + b ) )'));
console.log(checkBrackets('( b * ( c + d *2 / ( 2 + ( 12 – c / ( a + 3 ) ) ) )'));