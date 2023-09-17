using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    public class Person
    {
        private string name;
        private string address;
        private double salary;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        public double Salary
        {
            get { return salary; }
            set { salary = value; }
        }

        public static Person InputPersonInfo()
        {
            string name, address;
            double salary = 0;
            bool checksalary = false;
            Console.Write("Mời bạn nhập tên: ");
            name = Console.ReadLine();
            Console.Write("Mời bạn nhập địa chỉ: ");
            address = Console.ReadLine();
            while (!checksalary)
            {
                Console.Write("Mời bạn nhập lương: ");
                string salarycheck = Console.ReadLine();
                if (Double.TryParse(salarycheck, out salary))
                {
                    if (salary < 0)
                    {
                        Console.WriteLine("Error message: Lương không được nhỏ hơn không !!!");
                        Console.WriteLine("Vui lòng nhập lại !!!");
                    }
                    else
                    {
                        checksalary = true;
                    }
                }
                else
                {
                    Console.WriteLine("Error message: Lương nhập vào phải là một số !!!");
                    Console.WriteLine("Vui lòng nhập lại !!!");
                }
            }
            return new Person { Name = name, Address = address, Salary = salary };
        }

        public void DisplayPersonInfo()
        {
            Console.WriteLine("Tên: " + Name);
            Console.WriteLine("Địa chỉ: " + Address);
            Console.WriteLine("Lương: " + Salary);
        }

        public static Person[] SortBySalary(Person[] people)
        {
            for (int i = 0; i < people.Length - 1; i++)
            {
                for (int j = 0; j < people.Length - i - 1; j++)
                {
                    if (people[j].Salary > people[j + 1].Salary)
                    {
                        // Swap people[j] and people[j+1]
                        Person temp = people[j];
                        people[j] = people[j + 1];
                        people[j + 1] = temp;
                    }
                }
            }
            return people;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Person[] people = new Person[3];
            for (int i = 0; i < people.Length; i++)
            {
                Console.WriteLine("Mời bạn nhập thông tin của người thứ " + (i + 1));
                try
                {
                    people[i] = Person.InputPersonInfo();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    i--; // Re-prompt for input
                }
            }

            Console.WriteLine("Thông tin các người đã nhập:");
            foreach (Person person in people)
            {
                person.DisplayPersonInfo();
                Console.WriteLine();
            }

            Console.WriteLine("Sắp xếp theo lương tăng dần:");
            Person[] sortedPeople = Person.SortBySalary(people);
            foreach (Person person in sortedPeople)
            {
                person.DisplayPersonInfo();
                Console.WriteLine();
            }
        }
    }
}