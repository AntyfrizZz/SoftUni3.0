public class Problem04FullHouseWithJokers {

	public static void main(String[] args) {

		int counter = 0;

		for (int firstCard = 2; firstCard <= 15; firstCard++) {
			for (int secondCard = 2; secondCard <= 15; secondCard++) {
				if ((secondCard != firstCard) && (secondCard != 15)) {
					continue;
				}
				for (int thirdCard = 2; thirdCard <= 15; thirdCard++) {
					if ((thirdCard != secondCard) && (thirdCard != 15)) {
						continue;
					}
					
					for (int fourthCard = 2; fourthCard <= 15; fourthCard++) {
						if ((fourthCard == firstCard) && (fourthCard != 15)) {
							continue;
						}
						for (int fifthCard = 2; fifthCard <= 14; fifthCard++) {
							if (fifthCard != fourthCard) {
								continue;
							}

							for (int firstSuit = 1; firstSuit <= 4; firstSuit++) {
								for (int secondSuit = firstSuit + 1; secondSuit <= 4; secondSuit++) {
									for (int thirdSuit = secondSuit + 1; thirdSuit <= 4; thirdSuit++) {
										for (int fourthSuit = 1; fourthSuit <= 4; fourthSuit++) {
											for (int fifthSuit = fourthSuit + 1; fifthSuit <= 4; fifthSuit++) {
//												printCardAndSuits(firstCard, firstSuit);
//												printCardAndSuits(secondCard, secondSuit);
//												printCardAndSuits(thirdCard, thirdSuit);
//												printCardAndSuits(fourthCard, fourthSuit);
//												printCardAndSuits(fifthCard, fifthSuit);
//												System.out.println();
												counter++;
											}
										}
									}
								}
							}
						}
					}					
				}				
			}
		}

		System.out.println(counter);

	}

	public static void printCardAndSuits(int number, int suitNumber) {
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
			case 15:
				System.out.print("*");
				break;
			}
		}

		char clubs = '♣';
		char diamonds = '♦';
		char hearts = '♥';
		char spades = '♠';
		
		if (number != 15) {
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
}