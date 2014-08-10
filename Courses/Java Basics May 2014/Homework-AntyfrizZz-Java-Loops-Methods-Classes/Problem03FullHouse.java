/*In most Poker games, the "full house" hand is defined as three cards of the same face + two 
 * cards of the  * same face, other than the first, regardless of the card's suits. 
 * The cards faces are "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" and "A". 
 * The card suits are "♣", "♦", "♥" and "♠". Write a program to generate and print 
 * all full houses and print their number.*/

//https://softuni.bg/downloads/svn/java-basics/May-2014/3.%20Java-Loops-Methods-Classes-Homework.docx

public class Problem03FullHouse {

	public static void main(String[] args) {
		int counter = 0;

		for (int firstCard = 2; firstCard <= 14; firstCard++) {
			for (int secondCard = 2; secondCard <= 14; secondCard++) {
				if (secondCard == firstCard) {
					continue;
				}

				for (int firstSuit = 1; firstSuit <= 4; firstSuit++) {
					for (int secondSuit = firstSuit + 1; secondSuit <= 4; secondSuit++) {
						for (int thirdSuit = secondSuit + 1; thirdSuit <= 4; thirdSuit++) {
							for (int fourthSuit = 1; fourthSuit <= 4; fourthSuit++) {
								for (int fifthSuit = fourthSuit + 1; fifthSuit <= 4; fifthSuit++) {
									printCard(firstCard);
									printSuit(firstSuit);
									printCard(firstCard);
									printSuit(secondSuit);
									printCard(firstCard);
									printSuit(thirdSuit);
									printCard(secondCard);
									printSuit(fourthSuit);
									printCard(secondCard);
									printSuit(fifthSuit);
									System.out.println();
									counter++;
								}
							}
						}
					}
				}
			}
		}

		System.out.println(counter);
	}

	public static void printCard(int number) {
		if (number <= 10) {
			System.out.print(number);
		} else {
			switch (number) {
			case 11:
				System.out.print("J");
				break;
			case 12:
				System.out.print("Q");
				break;
			case 13:
				System.out.print("K");
				break;
			case 14:
				System.out.print("A");
				break;
			}
		}
	}

	public static void printSuit(int suitNumber) {
		char clubs = '♣';
		char diamonds = '♦';
		char hearts = '♥';
		char spades = '♠';

		switch (suitNumber) {
		case 1:
			System.out.print(clubs + " ");
			break;
		case 2:
			System.out.print(diamonds + " ");
			break;
		case 3:
			System.out.print(hearts + " ");
			break;
		case 4:
			System.out.print(spades + " ");
			break;
		}
	}
}