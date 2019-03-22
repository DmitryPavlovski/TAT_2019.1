namespace Task_DEV_3
{
    class Senior : Middle
    {
        public Senior()
        {
            Salary = 1800;
            Productivity = 25;
            Optimality = (double)Salary / Productivity;
        }
    }
}
