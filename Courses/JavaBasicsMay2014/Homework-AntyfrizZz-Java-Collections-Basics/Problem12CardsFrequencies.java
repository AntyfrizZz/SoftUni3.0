/*
 * We are given a sequence of N playing cards from a standard deck. The input consists of 
 * several cards (face + suit), separated by a space. Write a program to calculate and 
 * print at the console the frequency of each card face in format "card_face -> frequency". 
 * The frequency is calculated by the formula appearances / N and is expressed in percentages 
 * with exactly 2 digits after the decimal point. The card faces with their frequency should 
 * be printed in the order of the card face's first appearance in the input. The same card 
 * can appear multiple times in the input, but it's face should be listed only once in the output.
 *
 * https://softuni.bg/downloads/svn/java-basics/May-2014/4.%20Java-Collections-Basics-Homework.docx
 */

import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;

public class Problem12CardsFrequencies {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);

		/*
		 * While loop for faster checking. Don't forget to terminate the program
		 * after you finish with it)
		 */
		while (true) {
			String[] cards = in.nextLine().split("[ ♥♣♦♠]+");

			Map<String, Integer> cardsMap = new LinkedHashMap<String, Integer>();

			for (String card : cards) {
				Integer count = cardsMap.get(card);
				if (count == null) {
					count = 0;
				}
				cardsMap.put(card, count + 1);
			}

			for (Map.Entry<String, Integer> entry : cardsMap.entrySet()) {
				double precentage = (double) entry.getValue() * 100
						/ cards.length;
				System.out.printf("%s -> %.2f%%\n", entry.getKey(), precentage);
			}
			
			System.out.println();
		}
	}
}