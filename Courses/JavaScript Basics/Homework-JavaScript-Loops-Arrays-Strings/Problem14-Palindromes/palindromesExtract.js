function findPalindromes(inputString) {
    
    var words = inputString.toLowerCase().split(/[\W]+/),
        palindromes = [];
    
    if (words[words.length - 1] === '') {
        words.pop();
    }
    
    var i;
    
    for (i in words) {
        if (words[i].split('').reverse().join('') === words[i]) {
            palindromes.push(words[i]);
        }
    }
    return palindromes.join(', ');
}

console.log(findPalindromes('There is a man, his name was Bob.'));