/*Write a program that enters from the console number n and n strings, then sorts them alphabetically and prints them. 
Note: you might need to learn how to use loops and arrays in Java (search in Internet).*/

//https://softuni.bg/downloads/svn/java-basics/May-2014/1.%20Introduction-to-Java-Homework.docx

import java.util.Arrays;
import java.util.Scanner;


public class Problem08SortArrayOfStrings {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
				
		int nNumber = input.nextInt();
		String[] array = new String[nNumber];
		
		for (int i = 0; i < nNumber; i++) {
			array[i] = input.next();
		}
		
		Arrays.sort(array);
		
		for (int i = 0; i < nNumber; i++) {
			System.out.println(array[i]);
		}
		
	}

}
