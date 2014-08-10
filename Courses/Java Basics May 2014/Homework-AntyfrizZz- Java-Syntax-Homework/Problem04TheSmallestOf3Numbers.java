/*Write a program that finds the smallest of three numbers.*/

//https://softuni.bg/downloads/svn/java-basics/May-2014/2.%20Java-Syntax-Homework.docx

import java.util.Scanner;

public class Problem04TheSmallestOf3Numbers {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);

		// While loop for easy checking
		while (true) {
			double firstNum = in.nextDouble();
			double secondNum = in.nextDouble();
			double thirdNum = in.nextDouble();

			double smaler = Math.min(firstNum, secondNum);

			System.out.println("Smallest of the numbers: " + Math.min(smaler, thirdNum));

		}
	}
}