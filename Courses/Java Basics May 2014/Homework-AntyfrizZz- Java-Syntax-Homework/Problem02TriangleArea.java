/*Write a program that enters 3 points in the plane (as integer x and y coordinates), 
 * calculates and prints the area of the triangle composed by these 3 points. Round 
 * the result to a whole number. In case the three points do not form a triangle, print "0" as result. */

//https://softuni.bg/downloads/svn/java-basics/May-2014/2.%20Java-Syntax-Homework.docx

import java.util.Scanner;

public class Problem02TriangleArea {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);

		// While loop for easy checking
		while (true) {
			double aX = in.nextDouble();
			double aY = in.nextDouble();
			double bX = in.nextDouble();
			double bY = in.nextDouble();
			double cX = in.nextDouble();
			double cY = in.nextDouble();

			double area = Math.abs((aX * (bY - cY) + bX * (cY - aY) + cX * (aY - bY)) / 2);
			System.out.println(Math.round(area));

		}
	}
}