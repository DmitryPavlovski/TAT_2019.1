namespace Task_DEV_3
{
    class Middle : Junior
    {
        public Middle()
        {
            this.Salary = 1250;
            this.Productivity = 15;
            this.Optimality = (double)this.Salary / this.Productivity;
        }
    }
}
