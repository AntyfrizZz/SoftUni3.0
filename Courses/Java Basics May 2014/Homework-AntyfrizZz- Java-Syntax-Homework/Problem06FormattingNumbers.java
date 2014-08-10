/*Write a program that reads 3 numbers: an integer a (0 ≤ a ≤ 500), a floating-point b and a floating-point 
 * c and prints them in 4 virtual columns on the console. Each column should have a width of 10 characters. 
 * The number a should be printed in hexadecimal, left Write a program that reads 3 numbers: an integer a 
 * (0 ≤ a ≤ 500), a floating-point b and a floating-point c and prints them in 4 virtual columns on the console. 
 * Each column should have a width of 10 characters. The number a should be printed in hexadecimal, left */

//https://softuni.bg/downloads/svn/java-basics/May-2014/2.%20Java-Syntax-Homework.docx

import java.util.Scanner;

public class Problem06FormattingNumbers {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);

		// While loop for easy checking
		while (true) {
			int firstInput = in.nextInt();
			double secondInput = in.nextDouble();
			double thirdInput = in.nextDouble();

			String toBinary = String.format("%10s", Integer.toBinaryString(firstInput)).replace(' ', '0');

			System.out.printf("|%-10X|%s|%10.2f|%-10.3f|", firstInput, toBinary, secondInput, thirdInput);

		}
	}
}