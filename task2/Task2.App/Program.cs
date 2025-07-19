// Libraries used
using System;
using System.Diagnostics;

// Asking for the number
Console.Write("Please enter the maximum number you want to sum up to: ");
string? input;
input = Console.ReadLine();

long maxNumber;

// Validating the input
while (!long.TryParse(input, out maxNumber) || maxNumber <= 0)
{
    Console.Write("Invalid input. Please enter a positive number: ");
    input = Console.ReadLine();
}

// Confirmation check and its validation
while (true)
{
    Console.Write($"Are you sure you want to calculate the sum up to {maxNumber}? (Y/N) ");
    string? confirm;
    confirm = Console.ReadLine();

    if (!string.IsNullOrWhiteSpace(confirm))
    {
        confirm = confirm.Trim().ToUpper();

        if (confirm == "Y")
            break;

        if (confirm == "N")
        {
            Console.Write("Enter the maximum number again: ");
            input = Console.ReadLine();

            while (!long.TryParse(input, out maxNumber) || maxNumber <= 0)
            {
                Console.Write("Invalid input. Please enter a positive number: ");
                input = Console.ReadLine();
            }
        }
    }
}

// Stopwatch for loop sum
Stopwatch sw;
sw = new Stopwatch();
sw.Start();

long loopSum = 0;
for (long i = 1; i <= maxNumber; i++)
    loopSum += i;

sw.Stop();
double loopTime = sw.Elapsed.TotalMilliseconds;

// Stopwatch for formula sum
sw.Reset();
sw.Start();

long formulaSum = maxNumber * (maxNumber + 1) / 2;

sw.Stop();
double formulaTime = sw.Elapsed.TotalMilliseconds;

// Output
int maxNumberLength = maxNumber.ToString().Length;
int maxSumLength = Math.Max(loopSum.ToString().Length, formulaSum.ToString().Length);
int maxTimeLength = Math.Max(loopTime.ToString().Length, formulaTime.ToString().Length);

Console.WriteLine($"[{"Loop",-7}] | Sum from 1 to {maxNumber.ToString().PadLeft(maxNumberLength)} = {loopSum.ToString().PadRight(maxSumLength)} | Took {loopTime.ToString().PadLeft(maxTimeLength)} ms");
Console.WriteLine($"[{"Formula",-7}] | Sum from 1 to {maxNumber.ToString().PadLeft(maxNumberLength)} = {formulaSum.ToString().PadRight(maxSumLength)} | Took {formulaTime.ToString().PadLeft(maxTimeLength)} ms");