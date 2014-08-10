/*Write a program to count how many sequences of two equal bits ("00" or "11") can be found in the binary 
 * representation of given integer number n (with overlapping).*/

//https://softuni.bg/downloads/svn/java-basics/May-2014/2.%20Java-Syntax-Homework.docx

import java.util.Scanner;

public class Problem08CountOfEqualBitPairs {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);

		// While loop for easy checking
		while (true) {
			int inputNum = in.nextInt();

			int counter = 0;

			while (inputNum > 0) {
				int firstNum = inputNum % 2;
				int secondNum = (inputNum >> 1) % 2;

				if (firstNum == secondNum) {
					counter++;
				}

				inputNum = inputNum >> 1;
			}

			System.out.println(counter);

		}
	}
}