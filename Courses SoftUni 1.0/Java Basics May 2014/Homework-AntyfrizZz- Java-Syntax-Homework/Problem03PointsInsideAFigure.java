/*Write a program to check whether a point is inside or outside of the figure below. 
 * The point is given as a pair of floating-point numbers, separated by a space. 
 * Your program should print "Inside" or "Outside".*/

//https://softuni.bg/downloads/svn/java-basics/May-2014/2.%20Java-Syntax-Homework.docx

import java.util.Scanner;

public class Problem03PointsInsideAFigure {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);

		// While loop for easy checking
		while (true) {
			double aX = in.nextDouble();
			double aY = in.nextDouble();

			if ((aX >= 12.5) && (aX <= 17.5) && (aY >= 6) && (aY <= 13.5)) {
				System.out.println("Inside");
			} else if ((aX >= 20) && (aX <= 22.5) && (aY >= 6) && (aY <= 13.5)) {
				System.out.println("Inside");
			} else if ((aX >= 17.5) && (aX <= 20) && (aY >= 6) && (aY <= 8.5)) {
				System.out.println("Inside");
			} else {
				System.out.println("Outside");
			}

		}
	}
}