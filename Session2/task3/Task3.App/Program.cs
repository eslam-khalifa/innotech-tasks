// Libraries used
using System.Diagnostics;
using System.Text;

// Asking user for the input
Console.Write("Hello, Please enter the maximum number you need to write: ");

// Taking the input from the user
string? maximumNumberFromUser;
maximumNumberFromUser = Console.ReadLine();

// Converting the string input to an integer one
int maximumNumber;
while (string.IsNullOrWhiteSpace(maximumNumberFromUser) || !int.TryParse(maximumNumberFromUser, out maximumNumber) || maximumNumber <= 0)
{
    Console.WriteLine("Invalid input. Please enter a positive integer: ");
    maximumNumberFromUser = Console.ReadLine();
}

string numbers;
numbers = string.Empty;

// String Approach and measuring the time it takes
Stopwatch stopwatch = new Stopwatch();
stopwatch.Start();

// Time Complexity: n^2 because in each iteration Roslyn will copy the content of the string to create a new string
//                  1 + 2 + 3 + ..... + n = n (n + 1) / 2 = n^2
for (int i = 1; i <= maximumNumber; i++)
    numbers = $"{numbers}{i}{(i != maximumNumber ? "," : "")}";

stopwatch.Stop();
var StringApproachTime = stopwatch.Elapsed.TotalMilliseconds;

// StringBuilder Approach and measuring the time it takes
// StringBuilder is faster because it is built on linked list which is reference type but String is built on char array which is value type
stopwatch.Reset();
stopwatch.Start();
StringBuilder numbersNewApproach = new();

for (int i = 1; i <= maximumNumber; i++)
    numbersNewApproach.Append($"{i}{(i != maximumNumber? "," : "")}");

stopwatch.Stop();
var StringBuilderApproachTime = stopwatch.Elapsed.TotalMilliseconds;

// Printing the results
Console.WriteLine(numbers);
Console.WriteLine($"Using String class, Elapsed Time = {StringApproachTime}");
Console.WriteLine(numbersNewApproach);
Console.WriteLine($"Using StringBuilder class, Elapsed Time = {StringBuilderApproachTime}");