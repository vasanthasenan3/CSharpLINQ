using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LogicalProgsPractice
{
    /// <summary>
    /// Interaction logic for Linqprogss.xaml
    /// </summary>
    public partial class Linqprogss : Window
    {
        List<Employees> employees = new List<Employees>();
        public Linqprogss()
        {
            InitializeComponent();
            employees.Add(new Employees
            {
                Name = "Vasanthasenan",
                Department = "IT",
                ID = 1, 
                Salary = 25000, 
                Skills= new List<String> { "C#" , "HTML" }
            });
            employees.Add(new Employees
            {
                Name = "Kanishka",
                Department = "CSE",
                ID = 2,
                Salary = 30000,
                Skills = new List<String> { "Python", "Java" }

            });
            employees.Add(new Employees
            {
                Name = "Ishu",
                Department = "IT",
                ID = 3,
                Salary = 50000,
                Skills = new List<String> { "CSS", "JavaScript" }

            });

        }

        private void btnExecute_Click(object sender, RoutedEventArgs e)
        {
            lstOutput.Items.Clear();
            if(cmbMethods.SelectedItem == null)
            {
                MessageBox.Show("Please Select Linq method");
            }
            string method = ((ComboBoxItem)cmbMethods.SelectedItem).Content.ToString();
            switch(method)
            {
                case "Where()":
                    var whereresult = employees.Where(e => e.Salary > 10000);
                    foreach(var emps in whereresult)
                    {
                        lstOutput.Items.Add($"{emps.ID} {emps.Name} - {emps.Salary}");
                    }
                    break;

                case "Sum()":
                    lstOutput.Items.Add(employees.Sum(e=> e.Salary)); 
                    break;

                case "Max()":
                    lstOutput.Items.Add(employees.Max(e => e.Salary));
                    break;
                case "Min()":
                    lstOutput.Items.Add(employees.Min(e => e.Salary));
                    break;
                case "Count()":
                   lstOutput.Items.Add(employees.Count(e => e.Department == "IT"));
                   break;
                case "Average()":
                    lstOutput.Items.Add(employees.Average(e => e.Salary));
                    break;
                case "Select()":
                    var selects = employees.Select(e=> $@"{e.Name} - {e.Department}");
                    foreach(var results in selects)
                    {
                        lstOutput.Items.Add(results);
                    }
                    break;
                case "OrderBy()":
                    var items = employees.OrderBy(e => e.Salary);
                    foreach (var emp in items)
                    {
                        lstOutput.Items.Add($"{emp.Name} - {emp.Salary}");
                    }
                    break;
                case "OrderByDescending()":
                    var item = employees.OrderByDescending (e => e.Salary);
                    foreach (var emp in item)
                    {
                        lstOutput.Items.Add($"{emp.Name}-{emp.Salary}");
                    }
                    break;
                case "Expect()":
                    List<int> A = new List<int>() { 1,2,3,4,5 };
                    List<int> B = new List<int>() { 3, 4, 5 };
                    var expects = A.Except(B);
                    foreach (var expect in expects)
                    {
                        lstOutput.Items.Add(expect);
                    }
                    break;
                    
                   


            }

        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            lstOutput.Items.Clear();
        }
    }
}
