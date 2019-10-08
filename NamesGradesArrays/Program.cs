using System;

namespace NamesGradesArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = new string[50]; // Declare an array of type string and length/size 50
            double[] grades = new double[50]; // Declare an array of type double and length/size 50
            int count = 0; // initialize count with a value of 0 (this will help with keeping track of how many values have been read in to names and grades array)

            string myName = GetName();

            while (myName.ToLower() != "stop")
            {
                names[count] = myName;
                grades[count] = GetGrade(names[count]);
                count++;
                myName = GetName();
            }

            PrintNamesAndGrades(names, grades, count);

            double average = CalculateAverage(grades, count);
            Console.WriteLine("\n\nThe average of the grades is " + average);

            Console.ReadKey();

        }


        static string GetName()
        {
            Console.Write("\nPlease enter a name (stop to exit): ");
            string name = Console.ReadLine();
            return name;
        }


        static double GetGrade(string myName)
        {
            double grade;
            bool notValidInput = true;

            Console.Write("Please enter a grade for " + myName + ": ");
            string userInput = Console.ReadLine();

            // Error handling using TryParse method
            // double.TryParse(userInput, out grade) returns true 
            // if userInput can be successfully parsed/converted to a double value
            // For example, if userInput is "90.5" double.TryParse(userInput, out grade) returns true
            // but if userInput is "9lks" double.TryParse(userInput, out grade) returns false
            // If double.TryParse(userInput, out grade) returns true 
            // then the string value in userInput will be converted to a double value and assigned to the variable grade 
            if (double.TryParse(userInput, out grade)) 
            {
                if (grade >= 0 && grade <= 100)
                {
                    notValidInput = false;
                }
            }

            while (notValidInput)
            {
                Console.Write("Please enter a valid input: ");
                userInput = Console.ReadLine();

                if (double.TryParse(userInput, out grade))
                {
                    if (grade >= 0 && grade <= 100)
                    {
                        notValidInput = false;
                    }
                }
            }

            return grade;
        }


        static void PrintNamesAndGrades(string[] myNames, double[] myGrades, int count)
        {
            Console.WriteLine("\n\nHere are the names and their grades: ");

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(myNames[i] + " " + myGrades[i]);
            }
        }


        static double CalculateAverage(double[] grades, int count)
        {
            double total = 0;

            for (int i = 0; i < count; i++)
            {
                total += grades[i];
            }

            double average = total / count;
            return average;
        }
    }
}
