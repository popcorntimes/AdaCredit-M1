using AdaCredit;
using AdaCredit.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaCredit
{
    public static class EmployeeRepository
    {
        static EmployeeRepository(){
            try
            {
                // Faz a leitura do arquivo e joga na Employees
                Read();
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
            }
            

        }
        private static List<Employee> Employees { get; set; } = new List<Employee>();


        public static bool Add(string username, string password)
        {
            Read();
            Employee? isRegistered = EmployeeRepository.GetByUser(username);
            if (isRegistered != null)
            {
                System.Console.WriteLine("This employee is already registered!");
                System.Console.ReadKey();
                return false;
            }

            string salt = Password.SaltGeneration();
            string strPassword = Password.HashGeneration(password, salt);

            

            var entity = new Employee(username, strPassword, salt);

            Employees.Add(entity);

            Save();

            return true;


        }
        
        public static void LastLogin(Employee emp)
        {
            emp.LastLoginAt = DateTime.Now;
            Save();
        }


        public static Employee? GetByUser(string? username) => Employees.FirstOrDefault(employee => employee.Username == username);


        public static void Start()
        {
            Read();
        }

        private static void Read()
        {
            FileManager file = new FileManager("employees.csv");
            Employees = file.CsvReader<Employee>();

        }

        private static void Save()
        {
            FileManager file = new FileManager("employees.csv");

            file.CsvWriter(Employees);
        }

        public static int IsActive(Employee employee) => employee.IsActive;

        public static bool TryLogin(string username, string password)
        {
            Employee? emp = GetByUser(username);
            if(emp == null)
            {
                System.Console.WriteLine("User not registered");
                return false;
            }

            if (!Password.PasswordCompare(password, emp.Password))
            {
                System.Console.WriteLine("Incorrect password");
                return false;
            }

            if (IsActive(emp) == 0)
            {
                System.Console.WriteLine("Inactive user");
                return false;
            }

            LastLogin(emp);

            System.Console.WriteLine("Successful login");
            return true;
        }

        public static void Show(Employee emp)
        {
            System.Console.WriteLine(emp.Username);
            System.Console.WriteLine(emp.LastLoginAt);


        }
        public static void Deactivate(Employee emp)
        {
            emp.IsActive = 0;
            Save();
        }

    }
}
