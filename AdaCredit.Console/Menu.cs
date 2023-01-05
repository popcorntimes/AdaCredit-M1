using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdaCredit.Console.UseCases;
using ConsoleTools;

namespace AdaCredit
{
    public static class Menu
    {
        public static void Show()
        {
            var subClient = new ConsoleMenu(Array.Empty<string>(), level: 1)
                .Add("Add new client", AddNewClient.Execute)
                .Add("Show client info", GetClient.Execute)
                .Add("Edit client info", EditClient.Execute)
                .Add("Deactivate client", DeactivateClient.Execute)
                .Add("Back", ConsoleMenu.Close)
                .Configure(config =>
                {
                    config.Selector = "--> ";
                    config.EnableFilter = false;
                    config.Title = "Clients";
                    config.EnableBreadcrumb = true;
                    config.WriteBreadcrumbAction = titles => System.Console.WriteLine(string.Join(" / ", titles));
                    config.SelectedItemForegroundColor = ConsoleColor.Black;
                    config.SelectedItemBackgroundColor = ConsoleColor.White;
                });

            var subEmployee = new ConsoleMenu(Array.Empty<string>(), level: 1)
                .Add("Add new employee", AddNewEmployee.Execute)
                .Add("Show employee info", GetEmployee.Execute)
                .Add("Deactivate employee", DeactivateEmployee.Execute)
                .Add("Change employee password", EditEmployeePassword.Execute)
                .Add("Show all active employees and their last login date", ShowActiveEmployees.Execute)
                .Add("Back", ConsoleMenu.Close)
                .Configure(config =>
                {
                    config.Selector = "--> ";
                    config.EnableFilter = false;
                    config.Title = "Employees";
                    config.EnableBreadcrumb = true;
                    config.WriteBreadcrumbAction = titles => System.Console.WriteLine(string.Join(" / ", titles));
                    config.SelectedItemForegroundColor = ConsoleColor.Black;
                    config.SelectedItemBackgroundColor = ConsoleColor.White;
                });

            var subReport = new ConsoleMenu(Array.Empty<string>(), level: 1)
                .Add("Show all active clients and their balances", ShowActiveClients.Execute)
                .Add("Show all inactive clients", ShowInactiveClients.Execute)
                .Add("Show all active employees and their last login date", ShowActiveEmployees.Execute)
                .Add("Back", ConsoleMenu.Close)
                .Configure(config =>
                {
                    config.Selector = "--> ";
                    config.EnableFilter = false;
                    config.Title = "Reports";
                    config.EnableBreadcrumb = true;
                    config.WriteBreadcrumbAction = titles => System.Console.WriteLine(string.Join(" / ", titles));
                    config.SelectedItemForegroundColor = ConsoleColor.Black;
                    config.SelectedItemBackgroundColor = ConsoleColor.White;
                });

            var menu = new ConsoleMenu(Array.Empty<string>(), level: 0)
                .Add("Clients", subClient.Show)
                .Add("Employees", subEmployee.Show)
                .Add("Reports", subReport.Show)
                .Add("Exit", () => Environment.Exit(0))
                .Configure(config =>
                {
                    config.Selector = "--> ";
                    config.EnableFilter = false;
                    config.Title = "Ada Credit";
                    config.EnableWriteTitle = false;
                    config.EnableBreadcrumb = true;
                    config.SelectedItemForegroundColor = ConsoleColor.Black;
                    config.SelectedItemBackgroundColor = ConsoleColor.White;
                });

            menu.Show();
        }

        private static void SomeAction(string subOne)
        {
        }
    }
}
