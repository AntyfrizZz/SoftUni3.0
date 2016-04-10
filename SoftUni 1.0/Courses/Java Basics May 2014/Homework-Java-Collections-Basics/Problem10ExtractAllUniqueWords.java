/*
 * At the first line at the console you are given a piece of text. Extract all words from it and 
 * print them in alphabetical order. Consider each non-letter character as word separator. Take 
 * the repeating words only once. Ignore the character casing. Print the result words in a single 
 * line, separated by spaces.
 *
 * https://softuni.bg/downloads/svn/java-basics/May-2014/4.%20Java-Collections-Basics-Homework.docx
 */

import java.util.Scanner;
import java.util.Set;
import java.util.TreeSet;

public class Problem10ExtractAllUniqueWords {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);

		/*
		 * While loop for faster checking. Don't forget to terminate the program
		 * after you finish with it)
		 */
		while (true) {
			String[] input = in.nextLine().toLowerCase()
					.split("([().,!?:;'\"-]|\\s)+");

			Set<String> words = new TreeSet<>();

			for (String string : input) {
				words.add(string);
			}

			for (String string : words) {
				System.out.print(string + " ");
			}

			System.out.println();
		}
	}
}