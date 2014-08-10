/*
 * Write a program to find how many times given string appears in given text as substring. 
 * The text is given at the first input line. The search string is given at the second input line. 
 * The output is an integer number. Please ignore the character casing.
 *
 * https://softuni.bg/downloads/svn/java-basics/May-2014/4.%20Java-Collections-Basics-Homework.docx
 */

import java.util.Scanner;

public class Problem07CountSubstringOccurrences {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);

		/*
		 * While loop for faster checking. Don't forget to terminate the program
		 * after you finish with it)
		 */
		while (true) {
			String inputString = in.nextLine().toLowerCase();
			String word = in.nextLine().toLowerCase();

			int counter = 0;

			for (int i = 0; i <= inputString.length() - word.length(); i++) {
				if (inputString.substring(i, i + word.length()).equals(word)) {
					counter++;
				}
			}

			System.out.println(counter);
		}
	}
}