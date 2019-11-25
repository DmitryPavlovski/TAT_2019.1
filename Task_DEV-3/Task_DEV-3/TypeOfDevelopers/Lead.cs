namespace Task_DEV_3
{
    class Lead : Senior
    {
        public Lead()
        {
            this.Salary = 3200;
            this.Productivity = 50;
            this.Optimality = (double)this.Salary / this.Productivity;
        }
    }
}
