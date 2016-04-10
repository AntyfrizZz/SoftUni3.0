/*Write a program to check whether a point is inside or outside the house below. 
 * The point is given as a pair of floating-point numbers, separated by a space. 
 * Your program should print "Inside" or "Outside". */

//https://softuni.bg/downloads/svn/java-basics/May-2014/2.%20Java-Syntax-Homework.docx

import java.util.Scanner;

public class Problem09PointsInsideTheHouse {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);

		// While loop for easy checking
		while (true) {
			double inputNumX = in.nextDouble();
			double inputNumY = in.nextDouble();

			double aX = 12.5;
			double aY = 8.5;
			double bX = 17.5;
			double bY = 3.5;
			double cX = 22.5;
			double cY = 8.5;

			double firstLine = ((bX - aX) * (inputNumY - aY)) - ((bY - aY)	* (inputNumX - aX));
			double secondLine = ((bX - cX) * (inputNumY - cY)) - ((bY - cY) * (inputNumX - cX));

			if ((inputNumX >= 12.5) && (inputNumX <= 17.5) && (inputNumY >= 8.5) && (inputNumY <= 13.5)) {
				System.out.println("Inside");
			} else if ((inputNumX >= 20) && (inputNumX <= 22.5) && (inputNumY >= 8.5) && (inputNumY <= 13.5)) {
				System.out.println("Inside");
			} else if ((inputNumY <= 8.5) && (firstLine >= 0) && (inputNumX > 12.5)	&& (inputNumX <= 17.5)) {
				System.out.println("Inside");
			} else if ((inputNumY <= 8.5) && (secondLine <= 0) && (inputNumX < 22.5) && (inputNumX > 17.5)) {
				System.out.println("Inside");
			} else {
				System.out.println("Outside");
			}
		}
	}
}