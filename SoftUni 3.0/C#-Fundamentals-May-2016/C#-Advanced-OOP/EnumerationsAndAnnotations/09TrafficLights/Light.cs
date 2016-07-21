namespace _09TrafficLights
{
    public class Light
    {
        private Lights lightColor;

        public Light(Lights lightColor)
        {
            this.lightColor = lightColor;
        }

        public void Update()
        {
            this.lightColor = (Lights)(((int)this.lightColor + 1) % 3);
        }

        public override string ToString()
        {
            return $"{this.lightColor}";
        }
    }
}
