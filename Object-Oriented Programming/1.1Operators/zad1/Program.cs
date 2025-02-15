var plus = 1 + 2;
var minus = 3 - 4;
var multiply = 4 * 5;
var divide = 5 / 6;
var modulo = 6 % 7;

uint a = 0b_1100_0000_1111_0000_1111;
uint bitwiseComplement = ~a;
uint bitShiftLeft = 0b_1100_1001_0000_0000_0000_0100_0001_0001 << 4;

uint bitShiftRight = 0b_1100_0000_1111_1111_0000_1111 >> 4;

var and = 0b_1111_1000 & 0b_1001_1101;
var or = 0b_1111_1000 | 0b_1001_1101;
var xor = 0b_1111_1000 ^ 0b_1001_1101;

var equal = 5 == 3;
var notEqual = 5 != 1;
var smaller = 5 < 2;
var greater = 5 > 3;
var smallerOrEqual = 5 <= 2;
var greaterOrEqual = 5 >= 2;

var b = 3;
var c = 5;

b += c;
b %= c;
b >>= c;
b /= c;
b *= c;
b -= c;
b &= c;
b ^= c;
b |= c;
b = c;

var list = new int[] { 1, 2, 3 ,4};
var newList = list.Select(x => x + 1);