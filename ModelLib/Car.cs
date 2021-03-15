using System;

namespace ModelLib
{
    public class Car
    {

        public Car(string model, string color, int reg)
        {
            Model = model;
            Color = color;
            RegiNo = reg;
        }

        public string Model { get; set; }

        public string Color { get; set; }

        public int RegiNo { get; set; }
    }
}
