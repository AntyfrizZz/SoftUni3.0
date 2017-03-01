using System.Text;

class Car
{
    #region fields
    private string model;
    private double fuelAmount;
    private double fuelCostPerKilometer;
    private double distance;
    #endregion fields

    #region properties
    public string Model => this.model;
    public double FuelAmount => this.fuelAmount;
    public double FuelCostPerKilometer => this.fuelCostPerKilometer;
    public double Distance => this.distance;
    #endregion properties

    #region constructors

    public Car(string model, double fuelAmount, double fuelPerKilometer)
    {
        this.model = model;
        this.fuelAmount = fuelAmount;
        this.fuelCostPerKilometer = fuelPerKilometer;
        this.distance = 0;
    }
    #endregion constructors

    #region Methods
    public void Drive(double kilometers, StringBuilder resultForPrint)
    {
        if (kilometers <= this.fuelAmount / this.fuelCostPerKilometer)
        {
            this.fuelAmount -= kilometers * this.fuelCostPerKilometer;
            this.distance += kilometers;
        }
        else
        {
            resultForPrint.AppendLine("Insufficient fuel for the drive");
        }
    }
    #endregion Methods
}