/*Write a program to generate n random hands of 5 different cards form a standard suit of 52 cards. */

//https://softuni.bg/downloads/svn/java-basics/May-2014/3.%20Java-Loops-Methods-Classes-Homework.docx

import java.util.ArrayList;
import java.util.Random;
import java.util.Scanner;

public class Problem06RandomHandsOf5Cards {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);

		ArrayList<String> cardHand = new ArrayList<>();

		int n = in.nextInt();
		Random random = new Random();

		String[] cards = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J",
				"Q", "K", "A" };
		char[] suits = { '♣', '♦', '♥', '♠' };

		for (int i = 0; i < n; i++) {
			for (int j = 0; j < 5; j++) {
				int cardNumber = random.nextInt(cards.length);
				int suitNumber = random.nextInt(suits.length);
				String cardNumberString = String.valueOf(cards[cardNumber]);
				String suitNumberString = String.valueOf(suits[suitNumber]);
				String fullCard = cardNumberString + suitNumberString;
				
				if (j != 4) {
					cardHand.add(fullCard + " ");
				} else {
					cardHand.add(fullCard);
				}
				
				if (j == 1) {
					if (cardHand.get(1).equals(cardHand.get(0))) {
						cardHand.remove(fullCard);
						j--;
					}
				} else if (j == 2) {
					if (cardHand.get(2).equals(cardHand.get(1))
							|| cardHand.get(2).equals(cardHand.get(1))) {
						cardHand.remove(fullCard);
						j--;
					}
				} else if (j == 3) {
					if (cardHand.get(3).equals(cardHand.get(0))
							|| cardHand.get(3).equals(cardHand.get(1))
							|| cardHand.get(3).equals(cardHand.get(2))) {
						cardHand.remove(fullCard);
						j--;
					}
				} else if (j == 4) {
					if (cardHand.get(4).equals(cardHand.get(0))
							|| cardHand.get(4).equals(cardHand.get(1))
							|| cardHand.get(4).equals(cardHand.get(2))
							|| cardHand.get(4).equals(cardHand.get(3))) {
						cardHand.remove(fullCard);
						j--;
					}
				}
			}

			for (String finalCards : cardHand) {
				System.out.printf("%s", finalCards);
			}

			System.out.println();

			cardHand.clear();
		}
	}
}