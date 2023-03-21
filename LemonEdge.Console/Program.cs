using System;

namespace LemonEdge.Console
{
    class Program
    {
        static List<string> phoneNumbers = new List<string>();
        static int[,] keypad = new int[4, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { -1, 0, -2 } };

        static void Main(string[] args)
        {
            int startDigit = 3; // for example, starting from the "3" key
            int count = CountPhoneNumbersFrom(startDigit, 7, "");
            System.Console.WriteLine($"Total number of valid 7-digit phone numbers starting from digit {startDigit}: {count}");
            System.Console.WriteLine("Phone numbers:");
            foreach (string phoneNumber in phoneNumbers)
            {
                System.Console.WriteLine(phoneNumber);
            }
        }

        static int CountPhoneNumbersFrom(int startDigit, int digitsLeft, string currentNumber)
        {
            if (digitsLeft == 0)
            {
                phoneNumbers.Add(currentNumber);
                return 1;
            }
            int count = 0;
            int row = startDigit / 3;
            int col = startDigit % 3;
            // check all possible moves horizontally and vertically
            for (int dr = -3; dr <= 3; dr++)
            {
                for (int dc = -3; dc <= 3; dc++)
                {
                    if (dr != 0 && dc != 0)
                    {
                        continue; // only allow horizontal or vertical moves
                    }
                    if (dr == 0 && dc == 0)
                    {
                        continue; // don't allow a move of 0 spaces
                    }
                    int nextRow = row + dr;
                    int nextCol = col + dc;
                    if (nextRow >= 0 && nextRow < 4 && nextCol >= 0 && nextCol < 3)
                    {
                        int nextDigit = keypad[nextRow, nextCol];
                        if (nextDigit >= 0) // only consider regular digits
                        {
                            count += CountPhoneNumbersFrom(nextDigit, digitsLeft - 1, currentNumber + nextDigit);
                        }
                    }
                }
            }
            return count;
        }
    }
}