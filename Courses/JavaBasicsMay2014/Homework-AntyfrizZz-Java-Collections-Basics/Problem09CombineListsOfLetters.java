/*
 * Write a program that reads two lists of letters l1 and l2 and combines them: appends all 
 * letters c from l2 to the end of l1, but only when c does not appear in l1. Print the 
 * obtained combined list. All lists are given as sequence of letters separated by a single 
 * space, each at a separate line. Use ArrayList<Character> of chars to keep the input and 
 * output lists. 
 *
 * https://softuni.bg/downloads/svn/java-basics/May-2014/4.%20Java-Collections-Basics-Homework.docx
 */

import java.util.ArrayList;
import java.util.Scanner;

public class Problem09CombineListsOfLetters {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);

		/*
		 * While loop for faster checking. Don't forget to terminate the program
		 * after you finish with it)
		 */
		while (true) {
			char[] firstLine = in.nextLine().replaceAll("\\W", "")
					.toCharArray();
			char[] secondLine = in.nextLine().replaceAll("\\W", "")
					.toCharArray();

			ArrayList<Character> l1 = new ArrayList<>();
			ArrayList<Character> l2 = new ArrayList<>();

			for (int i = 0; i < firstLine.length; i++) {
				l1.add(firstLine[i]);
			}
			for (int i = 0; i < secondLine.length; i++) {
				l2.add(secondLine[i]);
			}
			
			ArrayList<Character> clonel1 = new ArrayList<>(l1);

			for (Character character : l2) {
				if (!clonel1.contains(character)) {
					l1.add(character);
				}
			}

			for (Character character : l1) {
				System.out.print(character + " ");
			}
			
			System.out.println();
		}
	}
}