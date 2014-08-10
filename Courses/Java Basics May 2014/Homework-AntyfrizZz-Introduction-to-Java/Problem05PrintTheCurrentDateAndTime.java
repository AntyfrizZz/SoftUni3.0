/*Create a simple Java program CurrentDateTime.java to print the current date and time. 
Submit the Java class CurrentDateTime as part of your homework.*/

//https://softuni.bg/downloads/svn/java-basics/May-2014/1.%20Introduction-to-Java-Homework.docx

import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.Date;


public class Problem05PrintTheCurrentDateAndTime {

	public static void main(String[] args) {
		DateFormat dateFormat = new SimpleDateFormat("yyyy/MM/dd HH:mm:ss");
		Date date = new Date();
		System.out.println(dateFormat.format(date));
		
	}
	
}
