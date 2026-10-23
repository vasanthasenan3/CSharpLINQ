using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Practiceforunstd2
{
    /// <summary>
    /// Interaction logic for Linqpractice.xaml
    /// </summary>
    public partial class Linqpractice : Window
    {
        public Linqpractice()
        {
            InitializeComponent();
        }

        private void linq_Click(object sender, RoutedEventArgs e)
        {
            int[] numbers = { 1, 10, 200, 300, 34, 64, 836, 432, 7, 1, 3, 4, 5, 8736, 736 };
            string[] letters = { "Vasanthasenan", "Vinoth", "kanishka", "Ishu", "Deva", "thiru", "Nivi", "ravi", "Posi", "Muthu" };
            //1.find even and odd numbers using linq
            var even = numbers.Where(n => n % 2 == 0);
            even.ToList();
            var odd = numbers.Where(n => n % 2 != 0);
            odd.ToList();
            //2.duplicate elements
            var dups = numbers.GroupBy(x => x)
                       .Where(n => n.Count() > 1)
                       .Select(n => n.Key);
            dups.ToList();
            //3.remove dupliate elements
            var removedups = numbers.Distinct();
            foreach (var s in removedups)
            {
                MessageBox.Show(s.ToString());
            }
            //4.max and min numbers in list

            var large = numbers.Max();
            var small = numbers.Min();
            MessageBox.Show(large.ToString());
            MessageBox.Show(small.ToString());

            //5.Ascending and decending order
            var asec = numbers.OrderBy(x => x);
            foreach (var sm in asec)
            {
                MessageBox.Show(sm.ToString());
            }
            var desec = numbers.OrderByDescending(x => x);
            foreach (var d in desec)
            {
                MessageBox.Show(d.ToString());
            }
            //6.Second highest num
            var secondhigh = numbers.Distinct()
                           .OrderByDescending(x => x)
                           .Skip(1)
                           .FirstOrDefault();
            MessageBox.Show(secondhigh.ToString());
            //7.find number greter than given value
            var findvalue = numbers.Where(v => v > 25);
            MessageBox.Show(findvalue.ToString());
            //8.count the number of elements matching a condition
            var find = numbers.Count(v => v > 25);
            MessageBox.Show(findvalue.ToString());
            //9. find non repeating characters
            string text = "swiss";
            var finds = text.GroupBy(x => x)
                        .Where(d => d.Count() == 1)
                        .Select(g => g.Key);
            foreach (var d in finds)
            {
                MessageBox.Show(d.ToString());
            }
            //10.Group Emoloyees by department
            var employees = new[]
            {
               new {Name = "Ravi", Department = "IT"},
               new {Name = "Vasanth", Department = "IT"},
               new {Name = "Thiru", Department = "HR"},
           };
            var groups = employees.GroupBy(x => x.Department);
            foreach (var group in groups)
            {
                MessageBox.Show(group.Key);
                foreach (var employee in group)
                {
                    MessageBox.Show(employee.Name);

                } 

            }
            //11.Salary Greter than 30k
            var emps = new[]
          {
               new {Name = "Ravi", Salary = 20000},
               new {Name = "Vasanth", Salary = 40000},
               new {Name = "Thiru", Salary = 10000},
          };
            var sal = emps.Where(x => x.Salary > 30000);
            foreach (var employee in sal)
            {
                MessageBox.Show(employee.Name);
            }

            //12.slect only employee names
            var names = emps.Select(x => x.Name);
            foreach (var employee in names)
            {
                MessageBox.Show(employee);
            }

            //13.common elements between two collections
            int[] a = { 1, 3, 5, 7, 8, 9, 10, 11, 12, };
            int[] b = { 1, 3, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, };
            var resut = a.Intersect(b);
            foreach (var nums in resut)
            {
                MessageBox.Show(resut.ToString());
            }
            //14.find elements present in the one collection but not another
            int[] x = { 1, 3, 5, 7 };
            int[] z = { 1, 3, 2, 4, 8 };
            var value = x.Except(b);
            foreach (var nums in value)
            {
                MessageBox.Show(nums.ToString());
            }
            //15.join two collections
            var emp = new[]
            {
                new {ID = 1, Name="Ravi"},
                new {ID = 2, Name="Vasanth"}
            };
            var dept = new[]
            {
                new {ID = 1, Department="IT"},
                new {ID = 2, Department ="Cse"}
            };
            var join = emp.Join(dept, e=>e.ID, d=>d.ID, (e,d) => new {e.Name, d.Department});
            foreach (var namess in join)
            {
                MessageBox.Show($"{namess.Name}-{namess.Department}");
            }
        }


    }
}