function countSubstringOccur(inputArray) {
    var keyword = inputArray[0].toLowerCase(),
        text = inputArray[1].toLowerCase();
    
    var parts = text.split(keyword);
    
    return parts.length - 1;
}

console.log(countSubstringOccur(['in', "We are living in a yellow submarine. We don't have anything else. Inside " +
    "the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days."]));
console.log(countSubstringOccur(['your', 'No one heard a single word you said. They should have seen it in your eyes. What was going around your head.']));
console.log(countSubstringOccur(['but', "But you were living in another world tryin' to get your message through."]));