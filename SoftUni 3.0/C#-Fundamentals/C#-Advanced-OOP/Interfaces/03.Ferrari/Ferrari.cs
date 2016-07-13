﻿namespace _03.Ferrari
{
    public class Ferrari : ICar
    {
        public Ferrari(string driver)
        {
            Model = "488-Spider";
            Driver = driver;
        }
        public string Model { get; }
        public string Driver { get; }

        public string Brakes()
        {
            return "Brakes!";
        }

        public string GasPedal()
        {
            return "Zadu6avam sA!";
        }

        public override string ToString()
        {
            return $"{this.Model}/{this.Brakes()}/{this.GasPedal()}/{this.Driver}";
        }
    }
}
