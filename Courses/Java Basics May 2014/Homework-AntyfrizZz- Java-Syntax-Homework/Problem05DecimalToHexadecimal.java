/*Write a program that enters a positive integer number num and converts and prints it in hexadecimal form. 
 * You may use some built-in method from the standard Java libraries. */

//https://softuni.bg/downloads/svn/java-basics/May-2014/2.%20Java-Syntax-Homework.docx

import java.util.Scanner;

public class Problem05DecimalToHexadecimal {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);

		// While loop for easy checking
		while (true) {
			int inputNum = in.nextInt();

			System.out.printf("%X%n", inputNum);	
		}		
	}
}