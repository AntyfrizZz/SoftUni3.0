/*Write a method to convert from degrees to radians. Write a method to convert from radians to degrees. 
 * You are given a number n and n queries for conversion. Each conversion query will consist of a 
 * number + space + measure. Measures are "deg" and "rad". Convert all radians to degrees and all 
 * degrees to radians. Print the results as n lines, each holding a number + space + measure. 
 * Format all numbers with 6 digit after the decimal point.*/

//https://softuni.bg/downloads/svn/java-basics/May-2014/3.%20Java-Loops-Methods-Classes-Homework.docx

import java.util.ArrayList;
import java.util.Scanner;

public class Problem05AngleUnitConverter {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);

		int n = in.nextInt();

		ArrayList<String> convertedList = new ArrayList<>();

		for (int i = 0; i < n; i++) {
			double number = in.nextDouble();
			String measure = in.next();
			
			if (measure.equals("rad")) {
				String angleToString = String.valueOf(number);
				convertedList.add(radiansToDegree(angleToString));
			} else if (measure.equals("deg")) {
				String angleToString = String.valueOf(number);
				convertedList.add(degreesToRadians(angleToString));
			}
		}

		System.out.println();

		for (String convertedAngles : convertedList) {
			System.out.printf("%s\n", convertedAngles);
		}
	}

	private static String radiansToDegree(String value) {
		double angle = Double.parseDouble(value);
		double convertedAngle = Math.toDegrees(angle);
		double roundedConvertedAngle = Math.round(convertedAngle * 1000000) / 1000000.0d;
		String angleString = String.valueOf(roundedConvertedAngle);
		String finalString = angleString + " deg";
		return finalString;

	}

	private static String degreesToRadians(String value) {
		double angle = Double.parseDouble(value);
		double convertedAngle = Math.toRadians(angle);
		double roundedConvertedAngle = Math.round(convertedAngle * 1000000) / 1000000.0d;
		String angleString = String.valueOf(roundedConvertedAngle);
		String finalString = angleString + " rad";
		return finalString;
	}
}
