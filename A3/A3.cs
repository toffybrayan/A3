using System;
using System.Collections.Generic;

namespace COMP10066_Lab3
{
    /**
     * Library of statistical functions using Generics for different statistical
     * calculations.
     * 
     * see http://www.calculator.net/standard-deviation-calculator.html
     * for sample standard deviation calculations
     *
     * @author Joey Programmer
     */

    public class A3
    {
        /// <summary>
        /// use PascalCasing for class names and method names
        /// this method is to calculate the avrage list of x
        /// </summary>
        /// <param name="x">is a list of doubles</param>
        /// <param name="incneg">is a boolean</param>
       
        public static double Avg(List<double> x, bool incneg)
        {
            double s = Sum(x, incneg);// seting the s as a double  
            int c = 0; // setting the c as a null integer value
            //to loop through the list of arrays
            for (int i = 0; i < x.Count; i++)
            {
                //if the  list is equal or bigger than zero add the values
                if (incneg || x[i] >= 0)
                {
                    c++;
                }
            }
            // if the c is zerro throw an exception
            if (c == 0)
            {
                throw new ArgumentException("no values are > 0");
            }
            return s / c;
            /// <returns>the average value</returns>
        }
        /// <summary>
        /// use PascalCasing for class names and method names
        /// this method is to calculate the sum of list x
        /// </summary>
        /// <param name="x">is a list of doubles</param>
        /// <param name="incneg">is a boolean</param>
       
        public static double Sum(List<double> x, bool incneg)
        {
            //if x is less than zero throw an exception message
            if (x.Count < 0)
            {
                throw new ArgumentException("x cannot be empty");
            }
            double sum = 0.0;// crearing a variable doble for sum\
            // for each values in x
            foreach (double val in x)
            {
                //if true and val is greater than or equal two
                if (incneg || val >= 0)
                {
                    sum += val;
                }
            }
            return sum;
            /// <returns>the sum of all value</returns>
        }
        /// <summary>
        /// use PascalCasing for class names and method names
        /// this methods is to calculate the median value 
        /// </summary>
        /// <param name="data">list of data types in double</param>
        
        public static double Median(List<double> data)
        {
            //if ddta lenght is equal to zero throw an exception message
            if (data.Count == 0)
            {
                throw new ArgumentException("Size of array must be greater than 0");
            }
            // to sort the data 
            data.Sort();

            double median = data[data.Count / 2];//making a double median 
            if (data.Count % 2 == 0)
                median = (data[data.Count / 2] + data[data.Count / 2 - 1]) / 2;

            return median;
            /// <returns>the medain value</returns>
        }
        /// <summary>
        /// use PascalCasing for class names and method names
        /// this method calculates the standard deviation  
        /// </summary>
        /// <param name="data">list of data types in double</param>
        
        public static double SD(List<double> data)
        {
            //if the data is <=1 throw an exception message
            if (data.Count <= 1)
            {
                throw new ArgumentException("Size of array must be greater than 1");
            }

            int n = data.Count;//n to int list arrays
            double s = 0;// s to double set as zero/null
            double a = Avg(data, true);
            // for data less than the length of the array to insert items in the data aray
            for (int i = 0; i < n; i++)
            {
                double v = data[i];
                s += Math.Pow(v - a, 2);
            }
            double stdev = Math.Sqrt(s / (n - 1));// stdev to double calculate standard deviation 
            return stdev;
            /// <returns>standard deviation</returns>
        }

        // Simple set of tests that confirm that functions operate correctly
        static void Main(string[] args)
        {
            //list the array of type doubles
            List<Double> testDataD = new List<Double> { 2.2, 3.3, 66.2, 17.5, 30.2, 31.1 };

            Console.WriteLine("The sum of the array = {0}", Sum(testDataD, true));

            Console.WriteLine("The average of the array = {0}", Avg(testDataD, true));

            Console.WriteLine("The median value of the Double data set = {0}", Median(testDataD));

            Console.WriteLine("The sample standard deviation of the Double test set = {0}\n", SD(testDataD));
        }
    }
}
