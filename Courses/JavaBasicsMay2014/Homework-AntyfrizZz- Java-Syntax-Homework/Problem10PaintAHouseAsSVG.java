/*Write a program to visualize the house and the points from the image above as SVG graphic 
 * embedded into a HTML document. The SVG format (Scalable Vector Graphics) is a XML based 
 * format for describing vector graphics used in the modern Web applications that supports 
 * drawing lines, circles, ellipses, rectangles, paths and other objects like text and raster 
 * images. You may find in Internet some Java library to build SVG graphics or you may build 
 * it through an XML parser or by printing plain text. You are free to choose the libraries and tools.
 * •	The output should look similar to the image above.
 * •	The coordinate axes should be thin dotted lines. The coordinates should have numbers as above.
 * •	The house should consist of two rectangles and a triangle above them, with solid lines 
 * and filled in semi-transparent gray color.
 * •	The points inside the house should be painted as black circles.
 * •	The points outside the house should be painted as gray circles with thin black border.
 * •	You are not allowed to use ready SVG, use Java code to draw everything!
 * Take as input the coordinates of the points (the first line holds the number of points n and 
 * the next n lines hold a point coordinates separated by a space). Produce as output a file names 
 * house.html, which visualizes the house and the points inside and outside of it through an embedded SVG graphic.*/

//https://softuni.bg/downloads/svn/java-basics/May-2014/2.%20Java-Syntax-Homework.docx

import java.io.BufferedWriter;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.OutputStreamWriter;
import java.io.Writer;
import java.util.Scanner;

public class Problem10PaintAHouseAsSVG {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);

		int n = in.nextInt();

		String points = "";

		for (int i = 0; i < n; i++) {
			double x = in.nextDouble() * 30;
			double y = in.nextDouble() * 30;

			double aX = 12.5 * 30;
			double aY = 8.5 * 30;
			double bX = 17.5 * 30;
			double bY = 3.5 * 30;
			double cX = 22.5 * 30;
			double cY = 8.5 * 30;

			double firstLine = ((bX - aX) * (y - aY)) - ((bY - aY) * (x - aX));
			double secondLine = ((bX - cX) * (y - cY)) - ((bY - cY) * (x - cX));

			if ((x >= 12.5 * 30) && (x <= 17.5 * 30) && (y >= 8.5 * 30)
					&& (y <= 13.5 * 30)) {
				points += "<circle cx=\"" + x + "\" cy=\"" + y + "\" r=\"3\" stroke=\"black\" stroke-width=\"1\" fill=\"black\" />";
			} else if ((x >= 20 * 30) && (x <= 22.5 * 30) && (y >= 8.5 * 30)
					&& (y <= 13.5 * 30)) {
				points += "<circle cx=\"" + x + "\" cy=\"" + y + "\" r=\"3\" stroke=\"black\" stroke-width=\"1\" fill=\"black\" />";
			} else if ((y <= 8.5 * 30) && (firstLine >= 0) && (x > 12.5 * 30)
					&& (x <= 17.5 * 30)) {
				points += "<circle cx=\"" + x + "\" cy=\"" + y + "\" r=\"3\" stroke=\"black\" stroke-width=\"1\" fill=\"black\" />";
			} else if ((y <= 8.5 * 30) && (secondLine <= 0) && (x < 22.5 * 30)
					&& (x > 17.5 * 30)) {
				points += "<circle cx=\"" + x + "\" cy=\"" + y + "\" r=\"3\" stroke=\"black\" stroke-width=\"1\" fill=\"black\" />";
			} else {
				points += "<circle cx=\"" + x + "\" cy=\"" + y + "\" r=\"3\" stroke=\"#BFBFBF\" stroke-width=\"1\" fill=\"#BFBFBF\" />";
			}
		}

		Writer writer = null;

		try {
			writer = new BufferedWriter(new OutputStreamWriter(
					new FileOutputStream("house.html"), "utf-8"));
			// house
			String triangle = "<polygon points=\"375,255   675,255  525,105\"style=\"stroke:#001C60; fill:#BFBFBF;\"/>";
			String rect1 = "<polygon points=\"375,255  525,255  525,405 375,405\"style=\"stroke:#001C60; fill:#BFBFBF;\"/>";
			String rect2 = "<polygon points=\"600,255  675,255  675,405 600,405\"style=\"stroke:#001C60; fill:#BFBFBF;\"/>";
			// coord system
			String vLine1 = "<line x1=\"300\" y1=\"80\" x2=\"300\" y2=\"500\" style=\"stroke:#DFEBF7;\"stroke-dasharray=\"1, 1\"/>";
			String vLine2 = "<line x1=\"375\" y1=\"80\" x2=\"375\" y2=\"500\" style=\"stroke:#DFEBF7;\"stroke-dasharray=\"1, 1\"/>";
			String vLine3 = "<line x1=\"450\" y1=\"80\" x2=\"450\" y2=\"500\" style=\"stroke:#DFEBF7;\"stroke-dasharray=\"1, 1\"/>";
			String vLine4 = "<line x1=\"525\" y1=\"80\" x2=\"525\" y2=\"500\" style=\"stroke:#DFEBF7;\"stroke-dasharray=\"1, 1\"/>";
			String vLine5 = "<line x1=\"600\" y1=\"80\" x2=\"600\" y2=\"500\" style=\"stroke:#DFEBF7;\"stroke-dasharray=\"1, 1\"/>";
			String vLine6 = "<line x1=\"675\" y1=\"80\" x2=\"675\" y2=\"500\" style=\"stroke:#DFEBF7;\"stroke-dasharray=\"1, 1\"/>";
			String hLine1 = "<line x1=\"275\" y1=\"105\" x2=\"700\" y2=\"105\" style=\"stroke:#DFEBF7;\"stroke-dasharray=\"1, 1\"/>";
			String hLine2 = "<line x1=\"275\" y1=\"180\" x2=\"700\" y2=\"180\" style=\"stroke:#DFEBF7;\"stroke-dasharray=\"1, 1\"/>";
			String hLine3 = "<line x1=\"275\" y1=\"255\" x2=\"700\" y2=\"255\" style=\"stroke:#DFEBF7;\"stroke-dasharray=\"1, 1\"/>";
			String hLine4 = "<line x1=\"275\" y1=\"330\" x2=\"700\" y2=\"330\" style=\"stroke:#DFEBF7;\"stroke-dasharray=\"1, 1\"/>";
			String hLine5 = "<line x1=\"275\" y1=\"405\" x2=\"700\" y2=\"405\" style=\"stroke:#DFEBF7;\"stroke-dasharray=\"1, 1\"/>";
			String hLine6 = "<line x1=\"275\" y1=\"480\" x2=\"700\" y2=\"480\" style=\"stroke:#DFEBF7;\"stroke-dasharray=\"1, 1\"/>";
			// coord system text
			String textVLine1 = "<text x=\"292\" y=\"75\" fill=\"black\">10</text>";
			String textVLine2 = "<text x=\"360\" y=\"75\" fill=\"black\">12.5</text>";
			String textVLine3 = "<text x=\"442\" y=\"75\" fill=\"black\">15</text>";
			String textVLine4 = "<text x=\"510\" y=\"75\" fill=\"black\">17.5</text>";
			String textVLine5 = "<text x=\"592\" y=\"75\" fill=\"black\">20</text>";
			String textVLine6 = "<text x=\"660\" y=\"75\" fill=\"black\">22.5</text>";
			String textHLine1 = "<text x=\"250\" y=\"110\" fill=\"black\">3.5</text>";
			String textHLine2 = "<text x=\"250\" y=\"185\" fill=\"black\">6</text>";
			String textHLine3 = "<text x=\"250\" y=\"260\" fill=\"black\">8.5</text>";
			String textHLine4 = "<text x=\"250\" y=\"335\" fill=\"black\">11</text>";
			String textHLine5 = "<text x=\"250\" y=\"410\" fill=\"black\">13.5</text>";
			String textHLine6 = "<text x=\"250\" y=\"485\" fill=\"black\">16</text>";

			writer.write("<div>\n<svg>\n" + vLine1 + vLine2 + vLine3 + vLine4
					+ vLine5 + vLine6 + hLine1 + hLine2 + hLine3 + hLine4
					+ hLine5 + hLine6 + textVLine1 + textVLine2 + textVLine3
					+ textVLine4 + textVLine5 + textVLine6 + textHLine1
					+ textHLine2 + textHLine3 + textHLine4 + textHLine5
					+ textHLine6 + triangle + rect1 + rect2 + points

					+ "</svg></div>");
		} catch (IOException ex) {
		} finally {
			try {
				writer.close();
			} catch (Exception ex) {
			}
		}
	}
}