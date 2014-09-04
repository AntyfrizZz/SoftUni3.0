function reverseString(inputString) {
    
    var stringAsArray = inputString.split('');
    
    stringAsArray.reverse();
    
    return stringAsArray.join('');
}

console.log(reverseString('sample'));
console.log(reverseString('softUni'));
console.log(reverseString('java script'));