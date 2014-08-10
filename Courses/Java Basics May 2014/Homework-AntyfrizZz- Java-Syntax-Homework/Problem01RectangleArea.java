/*Write a program that enters the sides of a rectangle (two integers a and b) and calculates and prints the rectangle's area. */

//https://softuni.bg/downloads/svn/java-basics/May-2014/2.%20Java-Syntax-Homework.docx

import java.util.Scanner;

public class Problem01RectangleArea {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);

		// While loop for easy checking
		while (true) {
			int firstSide = in.nextInt();
			int secondSide = in.nextInt();

			System.out.println("The rectangle's area is: " + firstSide * secondSide);
		}
	}
}