// string[] fraudulentOrderIDs = new string[3];

// fraudulentOrderIDs[0] = "A123";
// fraudulentOrderIDs[1] = "B456";
// fraudulentOrderIDs[2] = "C789";
// fraudulentOrderIDs[3] = "D000";

using System.Diagnostics.CodeAnalysis;

string[] fraudulentOrderIDs = { "A123", "B456", "C789" };

// for (int i = 0; i < fraudulentOrderIDs.Length; ++i)
//     Console.WriteLine(fraudulentOrderIDs[i]);

foreach (string i in fraudulentOrderIDs)
    Console.WriteLine(i);

// summer
int[] arrayOfInts = {200, 300, 400, 500};
var total = 0;
foreach (int i in arrayOfInts)
    total += i;
Console.WriteLine($"\nSum of integers in the array is: {total}\n");

// challenge
string[] orderID = {
    "B123",
    "C234",
    "A345",
    "C15",
    "B177",
    "G3003",
    "C235",
    "B179"
};

foreach (string order in orderID) {
    if (order.StartsWith('B'))
        Console.WriteLine(order);
}