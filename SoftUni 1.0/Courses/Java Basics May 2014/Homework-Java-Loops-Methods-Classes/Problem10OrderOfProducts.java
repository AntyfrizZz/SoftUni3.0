import java.io.BufferedWriter;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Locale;
import java.util.Scanner;

public class Problem10OrderOfProducts {

	public static void main(String[] args) throws IOException {
		Locale.setDefault(Locale.ROOT);
		
        ArrayList<Product> products = new ArrayList<Product>();
        
        try (Scanner in = new Scanner(new FileReader("ProductsInput.txt"))) {                    
            while (in.hasNextLine()) {
                products.add(new Product(in.next(), in.nextDouble()));
            }                              
        }
        
        double result = 0;
        
        try (Scanner in = new Scanner(new FileReader("Order.txt"))) {                       
            while (in.hasNextLine()) {
                double quantity = in.nextDouble();
                
                String currentProduct = in.next();
                
                for (Product product : products) {
                    if (product.getName().equals(currentProduct)) {
                            result += quantity * product.getPrice();
                    }
                }
            }                              
        }
        
        try (BufferedWriter output = new BufferedWriter(new FileWriter("ProductsTotalPrice.txt"))) {
            output.write(String.format("%.2f", result));
        }
	}
}