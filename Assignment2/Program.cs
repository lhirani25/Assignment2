using System;
using System.Collections.Generic;


namespace Assignment2
{
    class Program
    {
        static void Main(string[] args)
        {
            // left rotation
            Console.WriteLine("Left Rotation");
            int d = 4;
            int[] a = { 1, 2, 3, 4, 5 };
            int[] r = rotLeft(a, d);
            displayArray(r);

            // Maximum toys
            Console.WriteLine("\n\nMaximum toys");
            int k = 50;
            int[] prices = { 1, 12, 5, 111, 200, 1000, 10 };
            Console.WriteLine(maximumToys(prices, k));

            // Balanced sums
            Console.WriteLine("\n\nBalanced sums");
            List<int> arr = new List<int> { -1, 0, -1 };
            Console.WriteLine(balancedSums(arr));

            // Missing numbers
            Console.WriteLine("\n\nMissing numbers");
            int[] arr1 = { 203, 204, 205, 206, 207, 208, 203, 204, 205, 206 };
            int[] brr = { 203, 204, 204, 205, 206, 207, 205, 208, 203, 206, 205, 206, 204 };
            int[] r2 = missingNumbers(arr1, brr);
            displayArray(r2);

            // grading students
            Console.WriteLine("\n\nGrading students");
            int[] grades = { 73, 67, 38, 33 };
            int[] r3 = gradingStudents(grades);
            displayArray(r3);

            // find the median
            Console.WriteLine("\n\nFind the median");
            int[] arr2 = { 0, 1, 2, 4, 6, 5, 3 };
            Console.WriteLine(findMedian(arr2));

            // closest numbers
            Console.WriteLine("\n\nClosest numbers");
            int[] arr3 = { 5, 4, 3, 2 };
            int[] r4 = closestNumbers(arr3);
            displayArray(r4);

            // Day of programmer
            Console.WriteLine("\n\nDay of Programmer");
            int year = 2017;
            Console.WriteLine(dayOfProgrammer(year));

            Console.ReadKey();
        }

        static void displayArray(int[] arr)
        {
            Console.WriteLine();
            foreach (int n in arr)
            {
                Console.Write(n + " ");
            }
        }

        // Function to rotate the elements to the left by specified number of rotation
        static int[] rotLeft(int[] a, int d)
        {
            try
            {
                int arrSize = a.Length;
                //handling boundary cases
                if (arrSize < 2 || d == 0)
                {
                    //Array of len 0 & 1 or the number of rotations is 0 : return the original array
                    return a;
                }
                if (d >= arrSize)
                {
                    //Case1: if array len = 2, rotate by 2 results in the same array
                    //Case2: if array len = 2, rotate by 3 results in 3-2 = 1 rotation : ex:
                    // {1,2} => 1: {2,1} => 2: {1,2} =>3:  {2,1}
                    d -= arrSize;
                }
                reverseArray(a, 0, d - 1);
                reverseArray(a, d, arrSize - 1);
                reverseArray(a, 0, arrSize - 1);
            }
            catch
            {
                Console.WriteLine("Error in array rotation!");
            }
            return a;
        }

        //Function to reverses the elements of the array within the specified boundary only
        private static void reverseArray(int[] arr, int iStart, int iEnd)
        {
            try
            {
                //Boundary checks :
                int arrSize = arr.Length;
                if (arrSize < 2 || iStart > iEnd)
                {
                    //Nothing to do , not a valid scenario
                    return;
                }
                //temporary place holder to swap the array
                int tmp = 0;
                //Loop until the start index is less than the end index
                //keep on swapping the elements one by one until the end of array
                while (iStart < iEnd)
                {
                    tmp = arr[iStart];
                    arr[iStart] = arr[iEnd];
                    arr[iEnd] = tmp;
                    iStart++;
                    iEnd--;
                }
            }
            catch
            {
                Console.WriteLine("Error in reversing the array!");
            }
        }

        static void Selection_Sort(int[] ss_arr)
        {
            // min_position is used to keep track of the element position with the current lowest value
            int min_position;
            // temp is used to conduct the swap during during the Selection Sort Algorithm
            int temp;
            int[] ret = new int[ss_arr.Length];

            for (int i = 0; i < ss_arr.Length; i++)
            {
                min_position = i;
                // From the min_position, check to see if the next element is smaller
                for (int x = i + 1; x < ss_arr.Length; x++)
                {
                    // If the next element from the current min_position is smaller, then make that the new min_position
                    if (ss_arr[x] < ss_arr[min_position])
                    {
                        //min_position will keep track of the index that min is in, this is needed when a swap happens
                        min_position = x;
                    }
                } // End of inner for loop

                // If the min_position does not equal the current element being evaluated in the loop
                // Then execute the swap. by switching the postion of the lowest with the current element
                if (min_position != i)
                {
                    temp = ss_arr[i];
                    ss_arr[i] = ss_arr[min_position];
                    ss_arr[min_position] = temp;
                }
            } // End of outer for loop
        } // End of Selection_Sort

        // Function to calculate the maximum number of toys that can be bought from a given amount
        static int maximumToys(int[] prices, int k)
        {
            int res = 0;
            try
            {
                //verify boundaries
                if (prices.Length == 0 || k <= 0)
                {
                    Console.WriteLine("Please specify valid inputs: k > 0, prices should not be empty!");
                    return 0;
                }
                //sort the array 
                Selection_Sort(prices);

                //place holder for calculting the max number of toys
                int temp = 0;
                int i = 0;
                int pricesLen = prices.Length;
                //Loop until the sum is less than k and we donot exceed the array boundary
                while (i < pricesLen)
                {
                    //donot consider negative array values or 0 values: cannot buy any toys with 0$ 
                    if (prices[i] > 0)
                    {
                        temp += prices[i];
                        if (temp <= k)
                        {
                            //increment the result counter for each valid price update
                            res += 1;
                        }
                        else
                        {
                            //the sum is greater than the amount given, break out of the loop!
                            break;
                        }
                        i++;
                    }
                }
            }
            catch
            {
                Console.WriteLine("Error in calculating MaximumToys!");
            }
            return res;
        }

        // Complete the balancedSums function below.
        static string balancedSums(List<int> arr)
        {
            //Initialize the result
            string result = "NO";

            try
            {
                //lsum : will be used for the summation of elements from the left end of array
                //hsum: initially consists of the entire sum of the elements
                int lsum = 0, hsum = 0;
                foreach (int n in arr)
                {
                    hsum += n;
                }

                //Begin the loop until the end of array , break if the balanced sum exist
                for (int i = 0; i < arr.Count; ++i)
                {
                    hsum -= arr[i];
                    //Test Condition : if we have found the balanced sum
                    if (lsum == hsum)
                    {
                        result = "YES";
                        break;
                    }
                    lsum += arr[i];
                }
            }//End of try
            catch
            {
                Console.WriteLine("Error in calculating balanced sum!");
            }//End of Catch

            return result;
        }

        // Complete the missingNumbers function below.
        static int[] missingNumbers(int[] arr, int[] brr)
        {
            int alen = arr.Length;
            int blen = brr.Length;
            int[] store = new int[1000];
            int[] check = new int[1000];
            int i;
            for (i = 0; i < alen; i++)
            {
                check[arr[i]]++;
            }
            for (i = 0; i <blen; i++)
            {
                check[brr[i]]--;
            }
            int j=0;
            int count = 0;
            for (i = 0; i < check.Length; i++)
            {
                if (check[i] != 0)
                {
                    count++;
                    store[j++] = i;
                }
            }
            int[] key = new int[count];

            for(i=0;i<count;i++)
            {
                if (store[i] >0)
                    key[i] = store[i];
            }
            return key;
        
        }


        // Complete the gradingStudents function below.
        static int[] gradingStudents(int[] grades)
        {
            int n = grades.Length;
            int[] result = new int[n];
            for (int i = 0; i < n; i++)
            {
                if (grades[i] >= 38)
                {
                    if (grades[i] % 5 == 0)
                        result[i] = grades[i];
                    else if (grades[i] % 5 == 4)
                        result[i] = grades[i] + 1;
                    else if (grades[i] % 5 == 3)
                        result[i] = grades[i] + 2;
                    else
                        result[i] = grades[i];
                }
                else
                {
                    result[i] = grades[i];
                }
            }

            return result;
        }

        // Complete the findMedian function below.
        static int findMedian(int[] arr)
        {
            return 0;
        }

        // Complete the closestNumbers function below.
        static int[] closestNumbers(int[] arr)
        {
            return new int[] { };
        }

        // Complete the dayOfProgrammer function below.
        static string dayOfProgrammer(int year)
        {
            return "";
        }
    }
}
