namespace Task_DEV_3
{
    class Senior : Middle
    {
        public Senior()
        {
            this.Salary = 1800;
            this.Productivity = 25;
            this.Optimality = (double)this.Salary / this.Productivity;
        }
    }
}
