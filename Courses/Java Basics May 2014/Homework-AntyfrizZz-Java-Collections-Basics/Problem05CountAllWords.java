/*
 * Write a program to count the number of words in given sentence. 
 * Use any non-letter character as word separator.
 *
 * https://softuni.bg/downloads/svn/java-basics/May-2014/4.%20Java-Collections-Basics-Homework.docx
 */

import java.util.Scanner;

public class Problem05CountAllWords {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);

		/*
		 * While loop for faster checking. Don't forget to terminate the program
		 * after you finish with it)
		 */
		while (true) {
			String inputStrings = in.nextLine();
			String[] stringArray = inputStrings.split("[' ;-]");

			int counter = 0;

			for (String words : stringArray) {
				counter++;
			}

			System.out.println(counter);
		}
	}
}