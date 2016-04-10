function findMaxSequence(sequence) {
    var subSequences = [],
        start = 0,
        end = 0,
        len = sequence.length,
        i;    
    
    for (i = 0; i < len - 1; i += 1) {
        start = i;
        end = start;
        
        while (sequence[end] < sequence[end + 1]) {
            end++;
        }
        
        if (start < end) {
            subSequences.push({ start: start, end: end + 1 });
        }
    }
    
    var maxSequence,
        result;
    
    if (subSequences.length > 0) {
        
        subSequences.sort(function () {
            return (arguments[0].end - arguments[0].start) - (arguments[1].end - arguments[1].start);
        });
        
        maxSequence = subSequences.pop();
        
        result = sequence.slice(maxSequence.start, maxSequence.end);
    } else {
        result = 'no';
    }
    
    return result;
}

console.log(findMaxSequence([3, 2, 3, 4, 2, 2, 4]));
console.log(findMaxSequence([3, 5, 4, 6, 1, 2, 3, 6, 11, 102]));
console.log(findMaxSequence([3, 2, 1]));