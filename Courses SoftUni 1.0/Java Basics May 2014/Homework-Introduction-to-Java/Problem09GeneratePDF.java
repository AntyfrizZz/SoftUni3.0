/*Write a program to generate a PDF document called Deck-of-Cards.pdf
and print in it a standard deck of 52 cards, following one after
another. Each card should be a rectangle holding its face and suit.*/

//https://softuni.bg/downloads/svn/java-basics/May-2014/1.%20Introduction-to-Java-Homework.docx

import com.itextpdf.text.*;
import com.itextpdf.text.pdf.*;

import java.io.FileOutputStream;

public class Problem09GeneratePDF {

	public static void main(String[] args) {
		String[] suits = {"\u2663", "\u2666", "\u2665", "\u2660"};
        String[] ranks = {"2","3","4","5","6","7","8","9","10","J","Q","K","A"};
		
        try {
			Document document = new Document(PageSize.LETTER.rotate());			
			PdfWriter.getInstance(document, new FileOutputStream("Deck-of-Cards.pdf"));	
			document.open();
			
			PdfPTable table = new PdfPTable(13);
            table.setWidthPercentage(90);
            table.getDefaultCell().setFixedHeight(60);
            
            BaseFont baseFont = BaseFont.createFont("times.ttf", BaseFont.IDENTITY_H, true);
            Font deckFont = new Font(baseFont, 18f);
                        
            for (int i = 0; i < suits.length; i++) {
				for (int j = 0; j < ranks.length; j++) {
					
					if(i == 1 || i ==2)	{
						deckFont.setColor(BaseColor.RED);                                                       
		            }
					
					table.addCell(new Paragraph(ranks[j] + suits[i],deckFont));
					table.setSpacingAfter(5);
				}
				
				document.add(table);
                table.deleteLastRow();
                
                deckFont.setColor(BaseColor.BLACK);
			}     
        
        document.close();
        }	catch (Exception e) {
            e.printStackTrace();
        }
        
	}
	
}
