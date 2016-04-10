/*Write a program SumTwoNumbers.java that enters two integers from the console, calculates and prints their sum. 
Search in Internet to learn how to read numbers from the console.*/ 

//https://softuni.bg/downloads/svn/java-basics/May-2014/1.%20Introduction-to-Java-Homework.docx

import java.util.Scanner;

public class Problem06SumTwoNumbers {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		
		double firstNum = input.nextDouble();
		double secondNum = input.nextDouble();
		double sum = firstNum + secondNum;
		
		System.out.printf("%.2f", sum);
		
	}

}
