using System;

namespace Task_DEV_6
{
    /// <summary>
    /// class for car
    /// </summary>
    class Car
    {
        private string _mark;
        private string _model;
        private int _quantity;
        private int _cost;

        public string Mark
        {
            get => this._mark;
            set => this._mark = value != string.Empty ? value.ToLower() : throw new Exception("Mark should not be empty");
        }

        public string Model
        {
            get => this._model;
            set => this._model = value != string.Empty ? value.ToLower() : throw new Exception("Model should not be empty");
        }

        public int Quantity
        {
            get => this._quantity;
            set => this._quantity = value >= 0 ? value : throw new Exception("Quantity should be non-negative");
        }
        public int Cost
        {
            get => this._cost;
            set => this._cost = value >= 0 ? value : throw new Exception("Cost should be non-negative");
        }

        /// <summary>
        /// constructor with check on exceptoin
        /// </summary>
        /// <param name="mark"></param>
        /// <param name="model"></param>
        /// <param name="quantity"></param>
        /// <param name="cost"></param>
        public Car(string mark, string model, int quantity, int cost)
        {
            this.Mark = mark;
            this.Model = model;
            this.Quantity = quantity;
            this.Cost = cost;
        }
    }
}
