//  Driver
//
//  Lab6 FindLargerTree
//
//  Created by Jim Bailey on 4/25/20.
//  Licensed under a Creative Commons Attribution 4.0 International License.
//
//
//  Transpiled into C# by Katie Strauss 04/25/20
//  Updated 5/6/21
//  Updated again 10/30/21
//  Updated once more 5/4/22

using System;
using BinarySearchTreeClasses;

namespace FindLargerTreeDriver
{
    class Driver
    {
        static void Main(string[] args)
        {

            //InsertInorderTest();
            //FindTest();
            //RemoveTest();
            FindLargerTest();
            //RemoveLargerTest();

            Console.Write("\nAll done");
            Console.Write("\nPress Enter to exit console");
            Console.Read();
        }

        static void InsertInorderTest()
        {
            Tree fir = new Tree();
            int[] int_values = new int[] { 16, 8, 24, 4, 12, 20, 28, 2, 6, 10, 14, 18, 22, 26, 30, 0, -2 };
            const int NUM_EVENS = 17;

            Console.Write("\nTesting InsertValue and InOrder traversal\n");

            // build a nice noble fir that is balanced
            Console.Write(" Insert and display 15 even integers\n");
            for (int i = 0; i < NUM_EVENS; i++)
                fir.InsertValue(int_values[i]);

            // display the tree, should be even integers in order
            Console.Write(" InOrder expected: -2 0 2 4 6 8 10 12 14 16 18 20 22 24 26 28 30" + "\n");
            Console.Write(" InOrder actually: " + fir.InOrder() + "\n");
            Console.WriteLine();
            Console.Write(" PreOrder expected: 16 8 4 2 0 -2 6 12 10 14 24 20 18 22 28 26 30" + "\n");
            Console.Write(" PreOrder actually: " + fir.PreOrder() + "\n");
            Console.WriteLine();
            Console.Write(" PostOrder expected: -2 0 2 6 4 10 14 12 8 18 22 20 26 30 28 24 16" + "\n");
            Console.Write(" PostOrder actually: " + fir.PostOrder() + "\n");
            Console.WriteLine();

            Console.Write("\nEnd test insertValue and displayTree\n" + "\n");
        }

        static void FindTest()
        {
            Tree oak = new Tree();
            int[] primes = new int[] { 19, 11, 29, 5, 3, 7, 13, 17, 23, 31, 37 };
            const int NUM_PRIMES = 11;

            Console.Write("\nTesting FindValue\n");

            // build a nice prime oak
            Console.Write(" Insert and display 11 primes\n");
            for (int i = 0; i < NUM_PRIMES; i++)
                oak.InsertValue(primes[i]);

            Console.Write("  " + oak.InOrder() + "\n");

            // check find
            Console.Write("\n Should find 5 and 23, not find 21 or 2:\n");
            Console.Write("  Looking for 5 " + (oak.FindValue(5) ? "found" : "not found") + "\n");
            Console.Write("  Looking for 23 " + (oak.FindValue(23) ? "found" : "not found") + "\n");
            Console.Write("  Looking for 21 " + (oak.FindValue(21) ? "found" : "not found") + "\n");
            Console.Write("  Looking for 2 " + (oak.FindValue(2) ? "found" : "not found") + "\n");

            Console.Write("\nEnd of test FindValue\n" + "\n");
        }

        static void RemoveTest()
        {
            Tree plum = new Tree();
            int[] odds = new int[] { 15, 7, 23, 3, 11, 19, 27, 1, 5, 9, 13, 17, 21, 25, 29, -1 };
            const int NUM_ODDS = 16;

            Console.Write("\nTesting RemoveValue\n");

            // build a nice odd plum
            Console.Write(" Insert and display 15 odd integers plus -1\n");
            for (int i = 0; i < NUM_ODDS; i++)
                plum.InsertValue(odds[i]);

            Console.Write("  " + plum.InOrder() + "\n");

            // remove 9 && see if still there
            Console.Write("\n Now testing remove, 9 should be there and then gone\n");
            Console.Write("  Looking for 9 " + (plum.FindValue(9) ? "found" : "not found") + "\n");
            plum.RemoveValue(9);
            Console.Write("  Looking for 9 " + (plum.FindValue(9) ? "found" : "not found") + "\n");

            Console.Write(" Displaying tree after removing 9 \n");
            Console.Write("  InOrder expected -1 1 3 5 7 9D 11 13 15 17 19 21 23 25 27 29\n");
            Console.Write("  and actually is  " + plum.InOrder() + "\n");

            // check for burned branch
            Console.Write("\n Now checking if branch was burned on remove.  Should still find children of 9.\n");
            Console.Write("  Looking for 11 " + (plum.FindValue(11) ? "found" : "not found") + "\n");
            Console.Write("  Looking for 7 " + (plum.FindValue(7) ? "found" : "not found") + "\n");

            // Now add 9 back
            Console.Write("\n Now seeing if adding 9 back works" + "\n");
            plum.InsertValue(9);
            Console.Write("  Looking for 9 " + (plum.FindValue(9) ? "found" : "not found") + "\n");

            Console.Write(" Displaying tree after adding 9 back\n");
            Console.Write("  InOrder expected -1 1 3 5 7 9 11 13 15 17 19 21 23 25 27 29\n");
            Console.Write("  and actually is  " + plum.InOrder() + "\n");

            Console.Write("\nEnd of test RemoveValue \n" + "\n");

        }

        static void FindLargerTest()
        {
            Tree apple = new Tree();
            int[] nums = new int[] { 30, 15, 45, 7, 23, 3, 10, 18, 24, 36, 52, 33, 40, 48, 64 };
            const int NUM_NUMS = 15;

            Console.Write("\nTesting FindLarger\n");

            // build a nice random apple
            Console.Write(" Insert and display 15 integers\n");
            for (int i = 0; i < NUM_NUMS; i++)
                apple.InsertValue(nums[i]);

            Console.Write("  " + apple.InOrder() + "\n");

            Console.Write("\n Now testing FindLarger" + "\n");
            Console.Write("  1 should return 3 and returns " + apple.FindLarger(1) + "\n");
            Console.Write("  4 should return 7 and returns " + apple.FindLarger(4) + "\n");
            Console.Write("  9 should return 10 and returns " + apple.FindLarger(9) + "\n");
            Console.Write("  12 should return 15 and returns " + apple.FindLarger(12) + "\n");
            Console.Write("  16 should return 18 and returns " + apple.FindLarger(16) + "\n");
            Console.Write("  30 should return 30 and returns " + apple.FindLarger(30) + "\n");
            Console.Write("  34 should return 36 and returns " + apple.FindLarger(34) + "\n");
            Console.Write("  40 should return 40 and returns " + apple.FindLarger(40) + "\n");
            Console.Write("  43 should return 45 and returns " + apple.FindLarger(43) + "\n");
            Console.Write("  47 should return 48 and returns " + apple.FindLarger(47) + "\n");
            Console.Write("  62 should return 64 and returns " + apple.FindLarger(62) + "\n");
            Console.Write("  90 should return -1 and returns " + apple.FindLarger(90) + "\n");

            Console.Write("\nEnd of testing FindLarger\n" + "\n");

        }

        static void RemoveLargerTest()
        {
            Tree pear = new Tree();
            int[] vals = new int[] { 15, 8, 24, 4, 11, 19, 30, 2, 7, 10, 13, 16, 22, 28, 34 };
            const int NUM_VALS = 15;

            Console.Write("\nTesting RemoveLarger\n");

            // build a nice random apple
            Console.Write(" Insert and display 15 integers\n");
            for (int i = 0; i < NUM_VALS; i++)
                pear.InsertValue(vals[i]);

            Console.Write("\nStarting values for removeLarger\n");
            Console.Write("\n  " + pear.InOrder() + "\n");

            Console.Write(" Now testing RemoveLarger" + "\n");
            Console.Write("  5 should return 7 and returns " + pear.RemoveLarger(5) + "\n");
            Console.Write("   7 should be gone and is " + (pear.FindValue(7) ? "found" : "not found") + "\n\n");
            Console.Write("  19 should return 19 and returns " + pear.RemoveLarger(19) + "\n");
            Console.Write("   19 should be gone and is " + (pear.FindValue(19) ? "found" : "not found") + "\n");

            // verifying tree traversal after remove
            // potentially burning a branch
            Console.Write("  11 should return 11 and returns " + pear.RemoveLarger(11) + "\n");
            Console.Write("   11 should be gone and is " + (pear.FindValue(11) ? "found" : "not found") + "\n\n");
            // should return 10 if remove is correct, 15 if remove disrupts traversal
            Console.Write("  9 should return 10 and returns " + pear.RemoveLarger(9) + "\n");
            Console.Write("   15 should still be present and is " + (pear.FindValue(15) ? "found" : "not found") + "\n\n");

            Console.Write("\nEnd of testing RemoveLarger\n" + "\n");
        }
    }
}
