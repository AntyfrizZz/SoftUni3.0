class Employee
{
    public string name;
    public decimal salary;
    public string position;
    public string department;
    public string email;
    public int age;

    public Employee(string name, decimal salary, string position, string department)
    {
        this.name = name;
        this.salary = salary;
        this.position = position;
        this.department = department;
        this.email = "n/a";
        this.age = -1;
    }
}