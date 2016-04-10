function findMaxSequence(sequence) {
    var subSequences = [],
        start = 0,
        end = start + 1,
        i;
    
    do {
        while (sequence[start] === sequence[end]) {
            end++;
        }
        
        subSequences.push({ start: start, end: end });
        start = end;
        end++;
    } while (end < sequence.length);
    
    subSequences.sort(function () {
        return (arguments[0].end - arguments[0].start) - (arguments[1].end - arguments[1].start);
    });
    
    var maxSequence = subSequences.pop();
    
    return sequence.slice(maxSequence.start, maxSequence.end);
}

console.log(findMaxSequence([2, 1, 1, 2, 3, 3, 2, 2, 2]));
console.log(findMaxSequence(['happy']));
console.log(findMaxSequence([2, 'qwe', 'qwe', 3, 3, '3']));