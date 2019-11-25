namespace Task_DEV_3
{
    class Junior : Employee
    {
        public Junior()
        {
            this.Salary = 500;
            this.Productivity = 5;
            this.Optimality = (double)this.Salary / this.Productivity;
        }
    }
}
