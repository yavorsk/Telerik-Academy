// int res(int x, int y)
// {
// 	int a[2][2] = {{2, 1}, {3,0}};

// 	return a[(y >> 31) + 1][(x >> 31) + 1];
// }

// function c(a) {
// 	var b = [
// 		[3, 2],
// 		[0, 1]
// 	]
// 	return b[(a[1] >> 31) + 1][(a[0] >> 31) + 1];
// }

test0 = [-1, 1];
test1 = [1, 1];
test2 = [1, -1];
test3 = [-1, -1];

// console.log(c(test0));
// console.log(c(test1));
// console.log(c(test2));
// console.log(c(test3));

//var str = 'function c(e){var t=[[3,2],[0,1]];return t[(e[1]>>31)+1][(e[0]>>31)+1]}';
//console.log(str.length);

// void f(int * d) {
// 	printf( * d * d[1] > 0 ? * d > 0 ? "1" : "3" : * d < 0 ? "2" : "4");
// }

// function d(c) {
// 	return c[0] * c[1] > 0 ? c[0] > 0 ? 1 : 3 : c[0] < 0 ? 0 : 2
// }

function (c){return c[0]*c[1]>0?c[0]>0?1:2:c[0]<0?0:3} // moe
function d(e){x=e[0];y=e[1];return x>0?y>0?1:3:y<0?2:0} // ot foruma

function e(c){return c[0]*c[1]>0?c[0]>0?1:3:2}


console.log(b(test0));
console.log(b(test1));
console.log(b(test2));
console.log(b(test3));


