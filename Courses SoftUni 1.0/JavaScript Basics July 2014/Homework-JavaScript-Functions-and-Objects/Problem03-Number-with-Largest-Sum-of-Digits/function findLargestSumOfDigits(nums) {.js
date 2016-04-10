function findLargestSumOfDigits(nums) {
    if (arguments.length < 1) {
        return undefined;
    }

    var maxSum = 0;

    for (var i = 0; i < nums.length; i++) {
        if (parseInt(nums[i]) !== nums[i]) {
            return undefined;
        }

        var currentNum = Math.abs(nums[i]).toString();
        var currentSum = 0;

        for (var j = 0; j < currentNum.length; j++) {
            currentSum += Number(currentNum[j]);
        }

        if (currentSum >= maxSum) {
            var result = nums[i];
            maxSum = currentSum;
        }
    }

    return result;
}

console.log(findLargestSumOfDigits([5, 10, 15, 111]));
console.log(findLargestSumOfDigits([33, 44, -99, 0, 20]));
console.log(findLargestSumOfDigits(['hello']));
console.log(findLargestSumOfDigits([5, 3.3]));
console.log(findLargestSumOfDigits());