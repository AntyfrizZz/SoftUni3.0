function biggerThanNeighbors(index, arr) {
    if (index >= arr.length || index < 0) {
        console.log("invalid index");
    } else if (index === 0 || index === arr.length - 1) {
        console.log("only one neighbour");
    } else if (arr[index] > arr[index - 1] && arr[index] > arr[index + 1]) {
        console.log("bigger");
    } else {
        console.log("not bigger");
    }
}

biggerThanNeighbors(2, [1, 2, 3, 3, 5 ]);
biggerThanNeighbors(2, [1, 2, 5, 3, 4 ]);
biggerThanNeighbors(5, [1, 2, 5, 3, 4 ]);
biggerThanNeighbors(0, [1, 2, 5, 3, 4 ]);