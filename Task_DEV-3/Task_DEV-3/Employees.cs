namespace Task_DEV_3
{
    abstract class Employee
    {
        public int Salary { get; protected set; }
        public int Productivity { get; protected set; }
        public double Optimality { get; protected set; }
    }
    class Junior : Employee
    {
        public Junior()
        {
            Salary = 500;
            Productivity = 5;
            Optimality = (double)Salary / Productivity;
        }
    }
    class Middle : Junior
    {
        public Middle()
        {
            Salary = 1250;
            Productivity = 15;
            Optimality = (double)Salary / Productivity;
        }
    }
    class Senior : Middle
    {
        public Senior()
        {
            Salary = 1800;
            Productivity = 25;
            Optimality = (double)Salary / Productivity;
        }
    }
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
