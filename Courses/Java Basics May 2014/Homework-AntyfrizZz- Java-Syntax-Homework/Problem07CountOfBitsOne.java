/*Write a program to calculate the count of bits 1 in the binary representation of given integer number n.*/

//https://softuni.bg/downloads/svn/java-basics/May-2014/2.%20Java-Syntax-Homework.docx

import java.util.Scanner;

public class Problem07CountOfBitsOne {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);

		// While loop for easy checking
		while (true) {
			int inputNum = in.nextInt();

			System.out.println(Integer.bitCount(inputNum));

		}
	}
}