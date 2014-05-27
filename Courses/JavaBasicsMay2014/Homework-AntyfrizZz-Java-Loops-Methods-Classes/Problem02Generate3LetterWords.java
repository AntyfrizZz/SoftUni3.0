/*Write a program to generate and print all 3-letter words consisting of given set of characters. 
 * For example if we have the characters 'a' and 'b', all possible words will be 
 * "aaa", "aab", "aba", "abb", "baa", "bab", "bba" and "bbb". The input characters are given as 
 * string at the first line of the input. Input characters are unique (there are no repeating characters).*/

//https://softuni.bg/downloads/svn/java-basics/May-2014/3.%20Java-Loops-Methods-Classes-Homework.docx

import java.util.Scanner;

public class Problem02Generate3LetterWords {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);
        
        String inputChars = in.nextLine();
       
        String charComb = "";

        for (int i = 0; i < inputChars.length(); i++) {
            for (int j = 0; j < inputChars.length(); j++) {
                for (int k = 0; k < inputChars.length(); k++) {
                    charComb = "" + inputChars.charAt(i) + inputChars.charAt(j) + inputChars.charAt(k);
                    System.out.print(charComb + " ");
                }
            }
        }
	}
}