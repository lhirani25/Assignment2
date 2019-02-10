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

            int alen = arr.Length;//store length of arr

            int blen = brr.Length;//store length of brr

            int[] store = new int[1000];//declare new array named store

            int[] check = new int[1000];//declare new array named check
            //null checks
            if (alen < 0 && blen != 0)
                
                return brr;
            
            else if (alen != 0 && blen < 0)
                
                return arr;

            int i;

            for (i = 0; i < alen; i++)

            {

                check[arr[i]]++; 

            }

            for (i = 0; i < blen; i++)

            {

                check[brr[i]]--;

            }

            int j = 0;

            int count = 0;

            for (i = 0; i < check.Length; i++)

            {

                if (check[i] != 0)

                {

                    count++; //keeps a count on the number of elements

                    store[j++] = i; //value of i stored in store array

                }

            }

            int[] key = new int[count];//initialises key array to size of count

 

            for (i = 0; i < count; i++)

            {

                if (store[i] > 0)
                {

                    key[i] = store[i];//values in key array are update to missing values
                    
                }
                
            }

            return key; //return final array

 
        }


        // Complete the gradingStudents function below.

        static int[] gradingStudents(int[] grades)

        {

            int n = grades.Length; //storing the length of array in n

            int[] result = new int[n]; //declaring a new array named result

            for (int i = 0; i < n; i++)

             {

                if (grades[i] >= 38) //if grades are greater than or equal to 38 then there will be rounding

                {

                    if (grades[i] % 5 == 0)//if grades are a multiple of 5, then there will be no rounding

                        result[i] = grades[i];

                    else if (grades[i] % 5 == 4)//if there is a difference of 1 in nearest multiple of 5 and grade, then add 1

                        result[i] = grades[i] + 1;

                    else if (grades[i] % 5 == 3)//if there is a difference of 2 in nearest multiple of 5 and grade, then add 2

                        result[i] = grades[i] + 2;

                    else

                        result[i] = grades[i];//no change

                }//end of if

                else

                {

                    result[i] = grades[i];//if grade is less than 38, no change will be reflected

                }//end of else

            }//end of for

 

            return result;

        }//end of function

 

        // Complete the findMedian function below.

        static int findMedian(int[] arr)

        {

 

            int median;                                                         //Variable to store median

            int med_position;                                                   //Variable to store median index position

            int length = arr.Length;

            try

            {

                sort(arr);                                                          //Sort the array

                med_position = (length / 2);                                        //Find the median position of array and find the meduian using that index      

                median = arr[med_position];

 

                return median;

            } //End of try

            catch

            {

                Console.WriteLine("Exception caught");

                return 0;

            } //End of catch

 

 

        }

 

        public static void sort(int[] arr)

        {

            int n = arr.Length;                                                 //Length of array

            int t;                                                              //Temporary variable

                                                                                // Refered https://www.geeksforgeeks.org/heap-sort/ for heap sort

            try

            {

                for (int i = n / 2 - 1; i >= 0; i--)                                //Build the intial heap binary tree with all data

                    heap_tree(arr, n, i);

 

 

                for (int i = n - 1; i >= 0; i--)                                    //Swap the root(largest) element with the last element

                {

 

                    t = arr[0];

                    arr[0] = arr[i];

                    arr[i] = t;

 

 

                    heap_tree(arr, i, 0);                                           //Exclude the last root variable and build the heap binary tree again

                }

            } //End of try

            catch

            {

                Console.WriteLine("Exception caught");

 

            } //End of catch

        }

 

 

        public static void heap_tree(int[] arr, int n, int i)                   //Method to build heap binary tree

        {

            int biggest_node = i;

            int l = 2 * i + 1;                                                  // left node = 2*i + 1

            int r = 2 * i + 2;                                                  // right node = 2*i + 2

            try

            {

                // If left node is larger than root then large is left

                if (l < n && arr[l] > arr[biggest_node])

                    biggest_node = l;

 

                // If right child is larger than root then large is right

                if (r < n && arr[r] > arr[biggest_node])

                    biggest_node = r;

 

                // If largest is not root node, then swap to make it root node

                if (biggest_node != i)

                {

                    int t = arr[i];

                    arr[i] = arr[biggest_node];

                    arr[biggest_node] = t;


                    heap_tree(arr, n, biggest_node);                                     //Repeat till a heap binary tree is obtained

                }

            }  //End of try

            catch

            {

                Console.WriteLine("Exception caught");

 

            }  //End of catch

        }

 

        // Complete the closestNumbers function below.

        static int[] closestNumbers(int[] arr)

        {

            return new int[] { };

        }

 

        // Complete the dayOfProgrammer function below.

        static string dayOfProgrammer(int year)

        {

 

            try

            {

                string date;

                if (year >= 1700 && year <= 1917)               //To check if the range of the years, it falls in and return the 256th date for the same

                {

                    if (year % 4 == 0)                          //To check if this is a leap year

                    {

                        date = "12.09." + year;

                        return date;

                    }

                    else

                    {

                        date = "13.09." + year;

                        return date;

                    }

                }

                else if (year == 1918)                          //To check if this is the year the transfer took place in

                {

                    date = "26.09.1918";

                    return date;

                }

                else if (year > 1918 && year <= 2700)

                {

                    if ((year % 4 == 0) && (year % 100 != 0) || (year % 400 == 0))      //To check if this is a leap year

                    {

 

                        date = "12.09." + year;

                        return date;

                    }

                    else

                    {

                        date = "13.09." + year;

                        return date;

                    }

                }

                return "Please enter year in the correct year range";

            } //End of try

            catch

            {

                Console.WriteLine("Exception caught");

                return "";

            } //End of catch

 

        }

    }

}
