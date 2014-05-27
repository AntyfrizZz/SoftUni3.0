/*Write a program to read a text file "Input.txt" holding a sequence of integer numbers, each at a separate line. 
 * Print the sum of the numbers at the console. Ensure you close correctly the file in case of exception or in 
 * case of normal execution. In case of exception (e.g. the file is missing), print "Error" as a result.*/

//https://softuni.bg/downloads/svn/java-basics/May-2014/3.%20Java-Loops-Methods-Classes-Homework.docx

import java.io.BufferedReader;
import java.io.FileReader;

public class Problem08SumNumbersFromATextFile {

	public static void main(String[] args) {
		try {
			BufferedReader fileReader = new BufferedReader(new FileReader("inputNumbers.txt"));
			
			String line = null;
			int result = 0;
			
			while ((line = fileReader.readLine()) != null) {
				result += Integer.parseInt(line);
			}

			System.out.println(result);

		} catch (Exception ex) {
			System.out.println("Error");
		}
	}
}