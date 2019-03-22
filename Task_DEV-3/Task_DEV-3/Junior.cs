namespace Task_DEV_3
{
    class Junior : Employee
    {
        public Junior()
        {
            Salary = 500;
            Productivity = 5;
            Optimality = (double)Salary / Productivity;
        }
    }
}
