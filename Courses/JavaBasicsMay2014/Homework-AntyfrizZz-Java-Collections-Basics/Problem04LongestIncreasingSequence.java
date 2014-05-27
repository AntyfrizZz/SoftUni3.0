/*
 * Write a program to find all increasing sequences inside an array of integers. 
 * The integers are given in a single line, separated by a space. Print the sequences in the 
 * order of their appearance in the input array, each at a single line. Separate the sequence 
 * elements by a space. Find also the longest increasing sequence and print it at the last line. 
 * If several sequences have the same longest length, print the leftmost of them.
 *
 * https://softuni.bg/downloads/svn/java-basics/May-2014/4.%20Java-Collections-Basics-Homework.docx
 */

import java.util.Scanner;

public class Problem04LongestIncreasingSequence {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);

		/*
		 * While loop for faster checking. Don't forget to terminate the program
		 * after you finish with it)
		 */
		while (true) {
			String inputStrings = in.nextLine();
			String[] stringArray = inputStrings.split(" ");

			int counter = 1;
			int position = 0;
			int maxCount = 1;

			System.out.print(stringArray[0]);

			for (int i = 1; i < stringArray.length; i++) {
				int currnetInt = Integer.parseInt(stringArray[i]);
				int previousInt = Integer.parseInt(stringArray[i - 1]);

				if (currnetInt > previousInt) {
					counter++;
				} else {
					counter = 1;
				}

				if (maxCount < counter) {
					maxCount = counter;
					position = i;
				}

				if (currnetInt > previousInt) {
					System.out.print(" " + stringArray[i]);
				} else {
					System.out.println();
					System.out.print(stringArray[i]);
				}
			}

			System.out.println();
			System.out.print("Longest: ");

			for (int j = maxCount - 1; j >= 0; j--) {
				if (j != 0) {
					System.out.print(stringArray[position - j] + " ");
				} else {
					System.out.print(stringArray[position - j]);
				}
			}

			System.out.println();
		}
	}
}