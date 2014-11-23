var arr = [];
// arr.push(1);
// arr.push(2);
// arr.push(3);

// arr.push(1, 2, 3);
// console.dir(arr);

var itemsToAdd = [1,2,3];

Array.prototype.push.apply(arr, itemsToAdd);

console.dir(arr);
