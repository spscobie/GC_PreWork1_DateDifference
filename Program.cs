using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GC_Deliverable1_PreWorkDateDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime date1 = DateTime.MinValue, date2 = DateTime.MinValue;

            Console.WriteLine("Welcome! You will be asked to enter two dates.");
            Console.WriteLine("Program will tell you the amount of time that has elapsed between the two in days, hours, and minutes\r\n");

            ReadDates(ref date1, ref date2);                                                                                           //ReadInts() will read in user input, check it's integrity, and perform the digit summation test.

            Console.WriteLine("Press any key to contune...");
            Console.ReadKey();
        }

        private static void ReadDates(ref DateTime d1, ref DateTime d2)
        {
            Console.WriteLine("Enter the first date (example formats: 2017-10-07, 10-7-2017):");
            d1 = CheckDateFormat(Console.ReadLine());

            if (d1 != DateTime.MinValue)
            {
                Console.WriteLine("Enter the second date (example formats: 2017-10-07, 10-7-2017):");
                d2 = CheckDateFormat(Console.ReadLine());

                if (d2 == DateTime.MinValue)
                {
                    Console.WriteLine("The program finished with errors.");
                    return;
                }
            }
            else
            {
                Console.WriteLine("The program finished with errors.");
                return;
            }

            TimeSpan diff1 = d1.Subtract(d2).Duration();
            Console.WriteLine("The difference between those two dates:");
            Console.WriteLine("    in days is    {0}", diff1.TotalDays);
            Console.WriteLine("    in hours is   {0}", diff1.TotalHours);
            Console.WriteLine("    in minutes is {0}", diff1.TotalMinutes);
        }

        private static DateTime CheckDateFormat(string str1)
        {
            DateTime dateUser = DateTime.MinValue;

            try
            {
                dateUser = Convert.ToDateTime(str1);
            }
            catch (FormatException e)
            {

                Console.WriteLine("Oops! Looks like you didn't enter a valid date value. | ERROR: {0}", e.Message);
                return DateTime.MinValue;
            }

            return dateUser;
        }
    }
}
