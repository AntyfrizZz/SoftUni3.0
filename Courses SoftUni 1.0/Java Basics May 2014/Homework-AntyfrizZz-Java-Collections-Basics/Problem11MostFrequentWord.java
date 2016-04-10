/*
 * Write a program to find the most frequent word in a text and print it, as well as how many 
 * times it appears in format "word -> count". Consider any non-letter character as a word 
 * separator. Ignore the character casing. If several words have the same maximal frequency, 
 * print all of them in alphabetical order.
 *
 * https://softuni.bg/downloads/svn/java-basics/May-2014/4.%20Java-Collections-Basics-Homework.docx
 */

import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;

public class Problem11MostFrequentWord {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);

		/*
		 * While loop for faster checking. Don't forget to terminate the program
		 * after you finish with it)
		 */
		while (true) {
			String[] input = in.nextLine().toLowerCase()
					.split("([().,!?:;'\"-]|\\s)+");

			Map<String, Integer> wordsCount = new TreeMap<String, Integer>();

			int maxCount = 0;

			for (String word : input) {
				Integer count = wordsCount.get(word);

				if (count == null) {
					count = 0;
				}

				if (count + 1 > maxCount) {
					maxCount = count + 1;
				}

				wordsCount.put(word, count + 1);
			}

			for (Map.Entry<String, Integer> max : wordsCount.entrySet()) {

				if (max.getValue() == maxCount) {

					System.out.printf("%s -> %d times\n", max.getKey(),
							max.getValue());
				}
			}
		}
	}
}