using System;

namespace Task_DEV_6
{
    /// <summary>
    /// class for car
    /// </summary>
    class Car
    {
        public string Mark { get; set; }
        public string Model { get; set; }
        public int Quantity { get; set; }
        public int Cost { get; set; }

        /// <summary>
        /// constructor with check on exceptoin
        /// </summary>
        /// <param name="mark"></param>
        /// <param name="model"></param>
        /// <param name="quantity"></param>
        /// <param name="cost"></param>
        public Car(string mark, string model, int quantity, int cost)
        {
            Mark = mark;
            Model = model;
            Quantity = quantity;
            Cost = cost;
        }
    }
}
