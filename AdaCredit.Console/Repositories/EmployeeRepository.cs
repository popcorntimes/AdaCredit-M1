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

        public static List<Employee> AllActives() => Employees.Where(emp => !emp.Inactive.Equals("x")).ToList();

        public static void PrintAllActives()
        {
            List<Employee> emps = AllActives();

            if (emps.Count != 0)
            {
                foreach (Employee emp in emps)
                {
                    System.Console.WriteLine($"Employee username: {emp.Username}");
                    if (emp.LastLoginAt == null)
                    {
                        System.Console.WriteLine($"Last login at: never\r\n");
                    }
                    else
                    {
                        System.Console.WriteLine($"Last login at: {emp.LastLoginAt}\r\n");
                    }

                }
            }
            else
            {
                System.Console.WriteLine("No active employee");
            }




        }

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

        public static string IsActive(Employee emp) => emp.Inactive;

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

            if (IsActive(emp) == "x")
            {
                System.Console.WriteLine("Inactive user");
                return false;
            }

            LastLogin(emp);

            System.Console.WriteLine("Successful login");
            return true;
        }

        public static void FirstAccess()
        {
            System.Console.WriteLine("Enter username:");
            var username = System.Console.ReadLine();

            System.Console.WriteLine("Enter password:");
            var password = System.Console.ReadLine();


            if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password))
            {
                System.Console.WriteLine("Fields must not be empty");
                System.Console.ReadKey();
                return;
            }

            //var client = new Client(username, password);

            //var repository = new EmployeeRepository();

            var result = Add(username, password);

            if (result)
            {
                System.Console.WriteLine("Employee registered");
                System.Console.WriteLine("Use your credentials to log in");
            }
            else
            {
                System.Console.WriteLine("Register failed");

            }

        }
        
        public static void EditPassword(Employee emp)
        {
            string password;
            System.Console.Write("Enter new password: ");
            password = System.Console.ReadLine();
            if (string.IsNullOrEmpty(password))
            {
                System.Console.WriteLine("Password should not be empty");
                System.Console.ReadKey();
                System.Console.Clear();
                return;
            }

            string salt = Password.SaltGeneration();
            string strPassword = Password.HashGeneration(password, salt);

            emp.ChangePassword(strPassword, salt);
            Save();
            System.Console.WriteLine("Password updated");
        }

        public static void Print(Employee emp)
        {
            string status;
            System.Console.WriteLine($"Employee username: {emp.Username}");
            if (emp.LastLoginAt == null)
            {
                System.Console.WriteLine($"Last login at: never\r\n");
            }
            else
            {
                System.Console.WriteLine($"Last login at: {emp.LastLoginAt}\r\n");
            }
            if (emp.Inactive.Equals("x"))
            {
                status = "Inactive";
            }
            else
            {
                status = "Active";
            }
            System.Console.WriteLine($"Status: {status}");


        }
        public static void Deactivate(Employee emp)
        {
            emp.Inactive = "x";
            Save();
        }

    }
}
