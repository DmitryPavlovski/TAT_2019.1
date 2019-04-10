namespace Task_DEV_6
{
    class Car
    {
        public string Mark { get; set; }
        public string Model { get; set; }
        public int Quantity { get; set; }
        public int Cost { get; set; }

        public Car(string mark, string model, int quantity, int cost)
        {
            Mark = mark;
            Model = model;
            Quantity = quantity;
            Cost = cost;
        }
    }
}
