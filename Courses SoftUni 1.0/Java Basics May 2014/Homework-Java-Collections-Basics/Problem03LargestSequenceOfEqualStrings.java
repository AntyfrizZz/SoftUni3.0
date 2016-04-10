/*
 * Write a program that enters an array of strings and finds in it the largest sequence of equal elements. 
 * If several sequences have the same longest length, print the leftmost of them. 
 * The input strings are given as a single line, separated by a space.
 *
 * https://softuni.bg/downloads/svn/java-basics/May-2014/4.%20Java-Collections-Basics-Homework.docx
 */

import java.util.Scanner;

public class Problem03LargestSequenceOfEqualStrings {

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

			for (int i = 1; i < stringArray.length; i++) {
				if (stringArray[i].equals(stringArray[i - 1])) {
					counter++;
				} else {
					counter = 1;
				}

				if (maxCount < counter) {
					maxCount = counter;
					position = i;
				}
			}

			for (int j = 0; j < maxCount; j++) {
				if (j != maxCount - 1) {
					System.out.print(stringArray[position - j] + " ");
				} else {
					System.out.println(stringArray[position - j]);
				}
			}
		}
	}
}