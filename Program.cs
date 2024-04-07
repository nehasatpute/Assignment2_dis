/* 

YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINIDTION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK


*/

using System.Collections.Generic;
using System.Linq;
using System;
using System.Text;
using static System.Formats.Asn1.AsnWriter;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ISM6225_Spring_2024_Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            int numberOfUniqueNumbers = RemoveDuplicates(nums1);
            Console.WriteLine(numberOfUniqueNumbers);

            //Question 2:
            Console.WriteLine("Question 2:");
            int[] nums2 = { 0, 1, 0, 3, 12 };
            IList<int> resultAfterMovingZero = MoveZeroes(nums2);
            string combinationsString = ConvertIListToArray(resultAfterMovingZero);
            Console.WriteLine(combinationsString);

            //Question 3:
            Console.WriteLine("Question 3:");
            int[] nums3 = { -1, 0, 1, 2, -1, -4 };
            IList<IList<int>> triplets = ThreeSum(nums3);
            string tripletResult = ConvertIListToNestedList(triplets);
            Console.WriteLine(tripletResult);

            //Question 4:
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 1, 0, 1, 1, 1 };
            int maxOnes = FindMaxConsecutiveOnes(nums4);
            Console.WriteLine(maxOnes);

            //Question 5:
            Console.WriteLine("Question 5:");
            int binaryInput = 101010;
            int decimalResult = BinaryToDecimal(binaryInput);
            Console.WriteLine(decimalResult);

            //Question 6:
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 6, 9, 1 };
            int maxGap = MaximumGap(nums5);
            Console.WriteLine(maxGap);

            //Question 7:
            Console.WriteLine("Question 7:");
            int[] nums6 = { 2, 1, 2 };
            int largestPerimeterResult = LargestPerimeter(nums6);
            Console.WriteLine(largestPerimeterResult);

            //Question 8:
            Console.WriteLine("Question 8:");
            string result = RemoveOccurrences("daabcbaabcbc", "abc");
            Console.WriteLine(result);
        }

        /*
        
        Question 1:
        Given an integer array nums sorted in non-decreasing order, remove the duplicates in-place such that each unique element appears only once. The relative order of the elements should be kept the same. Then return the number of unique elements in nums.

        Consider the number of unique elements of nums to be k, to get accepted, you need to do the following things:

        Change the array nums such that the first k elements of nums contain the unique elements in the order they were present in nums initially. The remaining elements of nums are not important as well as the size of nums.
        Return k.

        Example 1:

        Input: nums = [1,1,2]
        Output: 2, nums = [1,2,_]
        Explanation: Your function should return k = 2, with the first two elements of nums being 1 and 2 respectively.
        It does not matter what you leave beyond the returned k (hence they are underscores).
        Example 2:

        Input: nums = [0,0,1,1,1,2,2,3,3,4]
        Output: 5, nums = [0,1,2,3,4,_,_,_,_,_]
        Explanation: Your function should return k = 5, with the first five elements of nums being 0, 1, 2, 3, and 4 respectively.
        It does not matter what you leave beyond the returned k (hence they are underscores).
 

        Constraints:

        1 <= nums.length <= 3 * 104
        -100 <= nums[i] <= 100
        nums is sorted in non-decreasing order.
        */

        public static int RemoveDuplicates(int[] nums)
        {
            try
            {
                // Check if the input array is empty. If so, return 0 as there are no elements.
                if (nums.Length == 0)
                    return 0;

                // Initialize k as 1 since the first element is always considered unique.
                int k = 1;
                // Start from the second element and compare it with the previous one.
                for (int i = 1; i < nums.Length; i++)
                {
                    // If the current element is not equal to the previous (a unique element found),
                    // place it at the k-th position and increment k.
                    if (nums[i] != nums[i - 1])
                    {
                        nums[k] = nums[i];
                        k++;
                    }
                }

                // Return the number of unique elements found in the array.
                return k;
            }
            catch (Exception)
            {
                // In case of any exception, propagate it further.
                throw;
            }
        }

        /*
         This code acts like someone tidying up a collection of items, ensuring each one is unique.
        It starts with the premise that the first item is always unique, setting `k` as a marker
        for placing the next unique item. As it moves through the collection, whenever it finds an
        item different from the last, it places this new unique item in the next spot designated by `k`.
        This process not only weeds out duplicates but also keeps the original sequence of unique items intact.
        By the end, `k` represents the total number of unique items found, much like counting different kinds
        of fruits in a mixed 
        basket and reorganizing them so each type appears just once, in the order they were first found.
        */

        /*
        Question 2:
        Given an integer array nums, move all 0's to the end of it while maintaining the relative order of the non-zero elements.

        Note that you must do this in-place without making a copy of the array.

        Example 1:

        Input: nums = [0,1,0,3,12]
        Output: [1,3,12,0,0]
        Example 2:

        Input: nums = [0]
        Output: [0]
 
        Constraints:

        1 <= nums.length <= 104
        -231 <= nums[i] <= 231 - 1
        */

        public static IList<int> MoveZeroes(int[] nums)
        {
            try
            {
                // Check if the input array is null or empty. If so, return an empty list.
                if (nums == null || nums.Length == 0)
                    return new List<int>();

                int nonZeroPointer = 0; // Initialize a pointer to track the position for the next non-zero element.

                // Loop through each element in the array.
                for (int i = 0; i < nums.Length; i++)
                {
                    // If the current element is not zero, place it at the position indicated by nonZeroPointer.
                    // This effectively moves all non-zero elements to the front of the array in their original order.
                    if (nums[i] != 0)
                    {
                        nums[nonZeroPointer] = nums[i];
                        nonZeroPointer++; // Move the nonZeroPointer forward.
                    }
                }

                // After all non-zero elements have been moved to the front,
                // fill the rest of the array with zeros.
                while (nonZeroPointer < nums.Length)
                {
                    nums[nonZeroPointer] = 0;
                    nonZeroPointer++; // Increment pointer as we insert zeros.
                }

                // Convert the modified array into a list and return it.
                return nums.ToList();
            }
            catch (Exception)
            {
                // In case of an exception, rethrow it to be handled by the caller.
                throw;
            }
        }



        /*
        This code is like sorting a row of potted plants, where the plants represent non-zero elements
        and empty pots represent zeros. It ensures all the plants are grouped at the start of the row 
        for easy watering, while the empty pots are moved to the end. 
        It methodically moves each plant forward to the next available spot, keeping their original order.
        After relocating all the plants, it then fills the space at the end of the row with empty pots. 
        This way, the arrangement becomes both practical and tidy,
        with every plant easily accessible for care and the empty pots conveniently out of the way.
        */

        /*

        Question 3:
        Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.

        Notice that the solution set must not contain duplicate triplets.

 

        Example 1:

        Input: nums = [-1,0,1,2,-1,-4]
        Output: [[-1,-1,2],[-1,0,1]]
        Explanation: 
        nums[0] + nums[1] + nums[2] = (-1) + 0 + 1 = 0.
        nums[1] + nums[2] + nums[4] = 0 + 1 + (-1) = 0.
        nums[0] + nums[3] + nums[4] = (-1) + 2 + (-1) = 0.
        The distinct triplets are [-1,0,1] and [-1,-1,2].
        Notice that the order of the output and the order of the triplets does not matter.
        Example 2:

        Input: nums = [0,1,1]
        Output: []
        Explanation: The only possible triplet does not sum up to 0.
        Example 3:

        Input: nums = [0,0,0]
        Output: [[0,0,0]]
        Explanation: The only possible triplet sums up to 0.
 

        Constraints:

        3 <= nums.length <= 3000
        -105 <= nums[i] <= 105

        */

        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            try
            {
                // Initialize the result list to hold all unique triplets.
                List<IList<int>> result = new List<IList<int>>();
                // Sort the array to simplify finding triplets that sum up to zero.
                Array.Sort(nums);

                // Iterate through the array, considering each element as a potential first element of a triplet.
                for (int i = 0; i < nums.Length - 2; i++)
                {
                    // Avoid duplicate triplets by skipping over duplicates of the current element.
                    if (i == 0 || (i > 0 && nums[i] != nums[i - 1]))
                    {
                        // Initialize two pointers for the second and third elements of the triplet.
                        int low = i + 1, high = nums.Length - 1, sum = 0 - nums[i];

                        // Use two pointers to find complementing elements that together with nums[i] sum up to zero.
                        while (low < high)
                        {
                            if (nums[low] + nums[high] == sum)
                            {
                                // When a triplet is found, add it to the result list.
                                result.Add(new List<int> { nums[i], nums[low], nums[high] });
                                // Skip duplicates for the second element of the triplet.
                                while (low < high && nums[low] == nums[low + 1]) low++;
                                // Skip duplicates for the third element of the triplet.
                                while (low < high && nums[high] == nums[high - 1]) high--;
                                // Move pointers to the next unique elements.
                                low++;
                                high--;
                            }
                            else if (nums[low] + nums[high] < sum) // If the sum is too small, move the low pointer up.
                                low++;
                            else // If the sum is too big, move the high pointer down.
                                high--;
                        }
                    }
                }
                // Return the list of all found triplets.
                return result;
            }
            catch (Exception)
            {
                // In case of any exception, rethrow it.
                throw;
            }
        }

        /*
        This code is like assembling teams for a relay race where the total time of each team 
        must be exactly zero. It sorts the runners by speed, picks a runner, and then looks for two others whose 
        
      speeds balance the first's to hit that zero-time target. It's careful not to pick the same
        runner twice for different teams, ensuring each team's lineup is unique. The result is a list of
        all possible teams that, 
        together, strike a perfect balance, showcasing a mix of strategy and precision in team selection.

        /*

        Question 4:
        Given a binary array nums, return the maximum number of consecutive 1's in the array.

        Example 1:

        Input: nums = [1,1,0,1,1,1]
        Output: 3
        Explanation: The first two digits or the last three digits are consecutive 1s. The maximum number of consecutive 1s is 3.
        Example 2:

        Input: nums = [1,0,1,1,0,1]
        Output: 2
 
        Constraints:

        1 <= nums.length <= 105
        nums[i] is either 0 or 1.

        */

        public static int FindMaxConsecutiveOnes(int[] nums)
        {
            try
            {
                // Initialize maxCount to track the maximum number of consecutive 1s found.
                int maxCount = 0;
                // Initialize count to track the current number of consecutive 1s.
                int count = 0;

                // Loop through each number in the array.
                foreach (int num in nums)
                {
                    if (num == 1)
                    {
                        // If the current number is 1, increment the current count of consecutive 1s.
                        count++;
                        // Update maxCount if the current count exceeds the previous maximum.
                        maxCount = Math.Max(maxCount, count);
                    }
                    else
                    {
                        // If the current number is not 1, reset the current count of consecutive 1s.
                        count = 0;
                    }
                }
                // Return the maximum count of consecutive 1s found in the array.
                return maxCount;
            }
            catch (Exception)
            {
                // In case of an exception, rethrow it.
                throw;
            }
        }

        /*
         This code is like counting the longest run of sunny days in a year. 
        Each "1" represents a sunny day, and the goal is to find the longest stretch
        of sunshine without rain ("0" days). As you tally up consecutive sunny days,
        you keep track of your highest count. If a rainy day interrupts, 
        you start the sunny count over, always remembering the longest stretch of good weather you had. 
        It's a way of pinpointing the best, unbroken period of sunny days,
        much like finding the maximum sequence of "1s" in an array.
         */
        /*

        Question 5:
        You are tasked with writing a program that converts a binary number to its equivalent decimal representation without using bitwise operators or the `Math.Pow` function. You will implement a function called `BinaryToDecimal` which takes an integer representing a binary number as input and returns its decimal equivalent. 

        Requirements:
        1. Your program should prompt the user to input a binary number as an integer. 
        2. Implement the `BinaryToDecimal` function, which takes the binary number as input and returns its decimal equivalent. 
        3. Avoid using bitwise operators (`<<`, `>>`, `&`, `|`, `^`) and the `Math.Pow` function for any calculations. 
        4. Use only basic arithmetic operations such as addition, subtraction, multiplication, and division. 
        5. Ensure the program displays the input binary number and its corresponding decimal value.

        Example 1:
        Input: num = 101010
        Output: 42


        Constraints:

        1 <= num <= 10^9

        */

        public static int BinaryToDecimal(int binary)
        {
            try
            {
                // Initialize decimalNumber to store the resulting decimal value.
                int decimalNumber = 0;
                // Initialize baseValue to represent the current base value (1, 2, 4, 8, ...) in the binary system.
                int baseValue = 1;

                // Loop until all digits of the binary number have been processed.
                while (binary > 0)
                {
                    // Extract the last digit (0 or 1) of the binary number.
                    int lastDigit = binary % 10;
                    // Reduce binary number by removing the last digit.
                    binary = binary / 10;
                    // Calculate the decimal value of the current digit and add it to the total decimalNumber.
                    decimalNumber += lastDigit * baseValue;
                    // Update the base value for the next digit, moving left in the binary number.
                    baseValue *= 2;
                }
                // Return the computed decimal value.
                return decimalNumber;
            }
            catch (Exception)
            {
                // In case of an exception, propagate it.
                throw;
            }
        }


        /*
         This code is like translating a secret Morse code message where each dot and dash has a specific meaning.
        In the case of binary, dots and dashes are replaced with 0s and 1s. Starting from the end of the message, 
        it decodes each symbol, converting the binary sequence into a language we understand—decimal numbers.
        It's as if you're walking backward through a path of dots and dashes, using a flashlight that doubles
        its brightness with each step,
        illuminating the value of each symbol until the entire message is clear and understandable.

        /*

        Question:6
        Given an integer array nums, return the maximum difference between two successive elements in its sorted form. If the array contains less than two elements, return 0.
        You must write an algorithm that runs in linear time and uses linear extra space.

        Example 1:

        Input: nums = [3,6,9,1]
        Output: 3
        Explanation: The sorted form of the array is [1,3,6,9], either (3,6) or (6,9) has the maximum difference 3.
        Example 2:

        Input: nums = [10]
        Output: 0
        Explanation: The array contains less than 2 elements, therefore return 0.


        Constraints:

        1 <= nums.length <= 105
        0 <= nums[i] <= 109

        */

        public static int MaximumGap(int[] nums)
        {
            try
            {
                // Check if the array has less than two elements. If so, return 0 since no gap can exist.
                if (nums.Length < 2) return 0;

                // Sort the array to make it easier to find the maximum gap between consecutive elements.
                Array.Sort(nums);

                // Initialize maxGap to track the largest difference between consecutive elements.
                int maxGap = 0;

                // Iterate through the array, starting from the second element.
                for (int i = 1; i < nums.Length; i++)
                {
                    // Update maxGap if the difference between the current element and its predecessor is larger than the current maxGap.
                    maxGap = Math.Max(maxGap, nums[i] - nums[i - 1]);
                }

                // Return the largest gap found among consecutive elements in the sorted array.
                return maxGap;
            }
            catch (Exception)
            {
                // In case of an exception, propagate it to allow for external handling.
                throw;
            }
        }


        /*

         
        This code is like organizing a race where runners finish at different times and you want to find
        out the biggest time gap between any two consecutive finishers. First, 
        you line up all the runners according to their finish times. Then, you measure the time
        difference between each runner and the one who finished just before them, keeping an eye out for
        the largest gap. It's akin to looking for the longest wait time between buses in a schedule,
        
        ensuring you've found the biggest stretch of time when nothing arrives.
        /*

        Question:7
        Given an integer array nums, return the largest perimeter of a triangle with a non-zero area, formed from three of these lengths. If it is impossible to form any triangle of a non-zero area, return 0.

        Example 1:

        Input: nums = [2,1,2]
        Output: 5
        Explanation: You can form a triangle with three side lengths: 1, 2, and 2.
        Example 2:

        Input: nums = [1,2,1,10]
        Output: 0
        Explanation: 
        You cannot use the side lengths 1, 1, and 2 to form a triangle.
        You cannot use the side lengths 1, 1, and 10 to form a triangle.
        You cannot use the side lengths 1, 2, and 10 to form a triangle.
        As we cannot use any three side lengths to form a triangle of non-zero area, we return 0.

        Constraints:

        3 <= nums.length <= 104
        1 <= nums[i] <= 106

        */

        public static int LargestPerimeter(int[] nums)
        {
            try
            {
                // Sort the array to arrange the elements in increasing order.
                Array.Sort(nums);

                // Start from the largest element and look backwards to find a valid triangle.
                for (int i = nums.Length - 1; i >= 2; i--)
                {
                    // Check if the three elements can form a triangle.
                    // A triangle is valid if the sum of the two smaller sides is greater than the largest side.
                    if (nums[i] < nums[i - 1] + nums[i - 2])
                        // If they can form a triangle, return the perimeter of the triangle.
                        return nums[i] + nums[i - 1] + nums[i - 2];
                }
                // If no valid triangle can be formed, return 0.
                return 0;
            }
            catch (Exception)
            {
                // In case of any exception, rethrow it to be handled externally.
                throw;
            }
        }

        /*
         This code is like a tailor trying to create the largest triangular piece of fabric from ribbons of
        different lengths. The tailor sorts all the ribbons from shortest to longest and starts looking from the
        longest pieces to find three that can be stitched together into a triangle. The main rule for making
        a good triangle is that the combined length of the two shorter ribbons must be greater than the length 
        of the longest ribbon. This ensures the triangle can be formed with a nice, wide base. If the tailor
        finds such a combination, they sum up the lengths to get the maximum perimeter of the triangle they 
        can make.
        If not, it's like saying no suitable combination of ribbons was found to make a triangle large enough.
         */

        /*

        Question:8

        Given two strings s and part, perform the following operation on s until all occurrences of the substring part are removed:

        Find the leftmost occurrence of the substring part and remove it from s.
        Return s after removing all occurrences of part.

        A substring is a contiguous sequence of characters in a string.



        Example 1:

        Input: s = "daabcbaabcbc", part = "abc"
        Output: "dab"
        Explanation: The following operations are done:
        - s = "daabcbaabcbc", remove "abc" starting at index 2, so s = "dabaabcbc".
        - s = "dabaabcbc", remove "abc" starting at index 4, so s = "dababc".
        - s = "dababc", remove "abc" starting at index 3, so s = "dab".
        Now s has no occurrences of "abc".
        Example 2:

        Input: s = "axxxxyyyyb", part = "xy"
        Output: "ab"
        Explanation: The following operations are done:
        - s = "axxxxyyyyb", remove "xy" starting at index 4 so s = "axxxyyyb".
        - s = "axxxyyyb", remove "xy" starting at index 3 so s = "axxyyb".
        - s = "axxyyb", remove "xy" starting at index 2 so s = "axyb".
        - s = "axyb", remove "xy" starting at index 1 so s = "ab".
        Now s has no occurrences of "xy".

        Constraints:

        1 <= s.length <= 1000
        1 <= part.length <= 1000
        s​​​​​​ and part consists of lowercase English letters.

        */


        public static string RemoveOccurrences(string s, string part)
        {
            try
            {
                // Initialize an integer to store the position of the 'part' substring within 's'.
                int index;
                // Continue looking for 'part' in 's' as long as it is found.
                while ((index = s.IndexOf(part)) != -1)
                {
                    // When 'part' is found, remove it from 's' starting from its first occurrence.
                    // 'index' is the starting position, and 'part.Length' is the number of characters to remove.
                    s = s.Remove(index, part.Length);
                }
                // Return the modified string after removing all occurrences of 'part'.
                return s;
            }
            catch (Exception)
            {
                // In case of any exception, rethrow it to be handled externally.
                throw;
            }
        }





        /* Inbuilt Functions - Don't Change the below functions */
        static string ConvertIListToNestedList(IList<IList<int>> input)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("["); // Add the opening square bracket for the outer list

            for (int i = 0; i < input.Count; i++)
            {
                IList<int> innerList = input[i];
                sb.Append("[" + string.Join(",", innerList) + "]");

                // Add a comma unless it's the last inner list
                if (i < input.Count - 1)
                {
                    sb.Append(",");
                }
            }

            sb.Append("]"); // Add the closing square bracket for the outer list

            return sb.ToString();
        }


        static string ConvertIListToArray(IList<int> input)
        {
            // Create an array to hold the strings in input
            string[] strArray = new string[input.Count];

            for (int i = 0; i < input.Count; i++)
            {
                strArray[i] = "" + input[i] + ""; // Enclose each string in double quotes
            }

            // Join the strings in strArray with commas and enclose them in square brackets
            string result = "[" + string.Join(",", strArray) + "]";

            return result;
        }
    }
}


/* This code works like meticulously editing a manuscript, searching for a specific word or phrase ("part")
 * that the editor wants to remove completely. Each time the phrase is found, it's carefully cut out, 
 * and the process continues until the manuscript is free of that particular phrase.
 * It's akin to going through a garden and removing every instance of a weed, ensuring that the landscape 
 * is left only with the plants you want to keep. The result is a cleaner,
 * more polished manuscript (or garden) without any traces of the unwanted element.
 */
