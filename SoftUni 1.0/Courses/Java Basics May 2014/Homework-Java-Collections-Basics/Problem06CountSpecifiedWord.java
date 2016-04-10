/*
 * Write a program to find how many times a word appears in given text. 
 * The text is given at the first input line. The target word is given at the second input line. 
 * The output is an integer number. Please ignore the character casing. 
 * Consider that any non-letter character is a word separator.
 *
 * https://softuni.bg/downloads/svn/java-basics/May-2014/4.%20Java-Collections-Basics-Homework.docx
 */

import java.util.Scanner;

public class Problem06CountSpecifiedWord {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);

		/*
		 * While loop for faster checking. Don't forget to terminate the program
		 * after you finish with it)
		 */
		while (true) {
			String inputString = in.nextLine();
			String word = in.nextLine();
			String[] stringArray = inputString.toLowerCase().split("[' ;-]");

			int counter = 0;

			for (String words : stringArray) {
				if (word.equals(words)) {
					counter++;
				}
			}

			System.out.println(counter);
		}
	}
}