/*
 * Write a program to enter a number n and n integer numbers and sort and print them. 
 * Keep the numbers in array of integers: int[].
 *
 * https://softuni.bg/downloads/svn/java-basics/May-2014/4.%20Java-Collections-Basics-Homework.docx
 */

import java.util.Arrays;
import java.util.Scanner;

public class Problem01SortArrayOfNumbers {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);

		/*
		 * While loop for faster checking. Don't forget to terminate the program
		 * after you finish with it)
		 */
		while (true) {

			int inputNum = in.nextInt();
			in.nextLine();
			int[] arrayNums = new int[inputNum];

			for (int i = 0; i < inputNum; i++) {
				arrayNums[i] = in.nextInt();
			}

			Arrays.sort(arrayNums);

			for (int i = 0; i < arrayNums.length; i++) {
				if (i != arrayNums.length) {
					System.out.println(arrayNums[i] + " ");
				} else {
					System.out.println(arrayNums[i]);
				}
			}
		}
	}
}