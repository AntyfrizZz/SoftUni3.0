/*Write a program to calculate the difference between two dates in number of days. 
 * The dates are entered at two consecutive lines in format day-month-year. 
 * Days are in range [1…31]. Months are in range [1…12]. Years are in range [1900…2100].*/

//https://softuni.bg/downloads/svn/java-basics/May-2014/3.%20Java-Loops-Methods-Classes-Homework.docx

import java.text.ParseException;
import java.util.Scanner;
import org.joda.time.DateTime;
import org.joda.time.Days;

public class Problem07DaysBetweenTwoDates {

	public static void main(String[] args) throws ParseException {
		Scanner in = new Scanner(System.in);
		
		while (true) {
			String firstDate = in.next();
			String secondDate = in.next();

			String[] dateFirst = firstDate.split("-");
			String[] dateSecond = secondDate.split("-");

			int firstYear = Integer.parseInt(dateFirst[2]);
			int firstMonth = Integer.parseInt(dateFirst[1]);
			int firstDay = Integer.parseInt(dateFirst[0]);
			int secondYear = Integer.parseInt(dateSecond[2]);
			int secondMonth = Integer.parseInt(dateSecond[1]);
			int secondDay = Integer.parseInt(dateSecond[0]);

			DateTime past = new DateTime(firstYear, firstMonth, firstDay, 0, 0);
			DateTime today = new DateTime(secondYear, secondMonth, secondDay, 0, 0);

			int days = Days.daysBetween(past, today).getDays();

			System.out.print(days);
			System.out.println();
		}
	}
}