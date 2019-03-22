namespace Task_DEV_3
{
    class Lead : Senior
    {
        public Lead()
        {
            Salary = 3200;
            Productivity = 50;
            Optimality = (double)Salary / Productivity;
        }
    }
}
