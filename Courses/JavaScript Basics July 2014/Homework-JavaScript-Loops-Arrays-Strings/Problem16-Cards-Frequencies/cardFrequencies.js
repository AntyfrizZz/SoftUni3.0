function findCardFrequency(inputString) {
    
    function getUniqueElements(arr) {
        
        var newArr = [],
            i;
        
        for (i in arr) {
            if (newArr.indexOf(arr[i]) === -1) {
                newArr.push(arr[i]);
            }
        }
        
        return newArr;
    }
    
    var cards = inputString.split(/[♣♦♥♠ ]+/),
        frequencies = [],
        i;
    
    cards.pop();
    
    
    for (i in cards) {
        if (cards[i] in frequencies) {
            frequencies[cards[i]]++;
        } else {
            frequencies[cards[i]] = 1;
        }
    }
    
    var cardsNumber = cards.length,
        outputString = '';
    
    cards = getUniqueElements(cards);
    
    for (i in cards) {
        var percent = (frequencies[cards[i]] / cardsNumber * 100).toFixed(2);
        outputString += cards[i] + ' -> ' + percent + '%\n';
    }
    
    return outputString;
}

console.log(findCardFrequency('8♥ 2♣ 4♦ 10♦ J♥ A♠ K♦ 10♥ K♠ K♦'));
console.log(findCardFrequency('J♥ 2♣ 2♦ 2♥ 2♦ 2♠ 2♦ J♥ 2♠'));
console.log(findCardFrequency('10♣ 10♥'));