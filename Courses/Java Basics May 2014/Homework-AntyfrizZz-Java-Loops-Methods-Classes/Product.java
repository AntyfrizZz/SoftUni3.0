public class Product implements Comparable<Product> {
	private String name;
	private double price;

	public Product(String name, double price) {
		this.name = name;
		this.price = price;
	}

	public String getName() {
		return name;
	}

	public double getPrice() {
		return price;
	}

	public int compareTo(Product compareFruit) {

		double otherPrice = ((Product) compareFruit).getPrice();

		if (this.price > otherPrice)
			return 1;
		else if (this.price == otherPrice)
			return 0;
		return -1;
	}
}