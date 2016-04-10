/*
 * Write a program that enters an array of strings and finds in it all sequences of equal 
 * elements. The input strings are given as a single line, separated by a space.
 *
 * https://softuni.bg/downloads/svn/java-basics/May-2014/4.%20Java-Collections-Basics-Homework.docx
 */

import java.util.Scanner;

public class Problem02SequencesOfEqualStrings {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);

		/*
		 * While loop for faster checking. Don't forget to terminate the program
		 * after you finish with it)
		 */
		while (true) {
			String inputStrings = in.nextLine();
			String[] stringArray = inputStrings.split(" ");

			System.out.print(stringArray[0]);

			for (int i = 1; i < stringArray.length; i++) {
				if (stringArray[i].equals(stringArray[i - 1])) {
					System.out.print(" " + stringArray[i]);
				} else {
					System.out.println();
					System.out.print(stringArray[i]);
				}
			}

			System.out.println();
		}
	}
}