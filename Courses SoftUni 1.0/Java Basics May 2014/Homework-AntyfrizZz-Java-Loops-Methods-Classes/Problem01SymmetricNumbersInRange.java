/*Write a program to generate and print all symmetric numbers in given range [start…end]. 
 * A number is symmetric if its digits are symmetric toward its middle. For example, the 
 * numbers 101, 33, 989 and 5 are symmetric, but 102, 34 and 997 are not symmetric.*/

//https://softuni.bg/downloads/svn/java-basics/May-2014/3.%20Java-Loops-Methods-Classes-Homework.docx

import java.util.Scanner;

public class Problem01SymmetricNumbersInRange {

	public static void main(String[] args) {
		while (true) {
			Scanner in = new Scanner(System.in);
			int firstNum = in.nextInt();
			int secondNum = in.nextInt();

			for (int number = firstNum; number <= secondNum; number++) {
				if (checkSymmetricity(number)) {
					System.out.print(number);
					if (number != secondNum)
						System.out.print(" ");
				}
			}
		}
	}

	public static boolean checkSymmetricity(int number) {

		if (Integer.toString(number).equals(
				new StringBuilder(Integer.toString(number)).reverse()
						.toString())) {
			return true;
		} else {
			return false;
		}
	}
}