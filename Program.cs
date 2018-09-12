using System;
using System.Collections;
using System.Linq;
using Starcounter;
using Starcounter.Internal;

namespace StarcounterApplication1
{
    
   
    [Database]
    public class Person
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName { get { return FirstName + " " + LastName; } }
    }

    [Database]
    public class Employee : Person
    {
      
        public Department Department { get; set;  }
        public Address adress;
        public Position position { get; set; }

        public String introduce()
        {
            return LastName + " " + FirstName;
        }

        public void setPosition(Position position)
        {
            Db.Transact(() => this.position = position);
        }

    }

    [Database]
    public class Department 
    {
        public String name;
        public Company Company { get; set; }
        IEnumerable Employees  =>  Db.SQL<Employee>(
        "SELECT e FROM Employee e WHERE e.Department = ?", this);


        public double countSalary()
        {
            double sum = 0;
            foreach (var empl in Employees)
            {
                Employee e = (Employee) empl;
                sum += e.position.salary;
            }
            return sum;
        }
    }
    [Database]
    public class Company
    {
        public String name;
        public IEnumerable Department =>
        Db.SQL<Department>(
        "SELECT e FROM Employee e WHERE e.Company = ?", this);
       

    }

    [Database]
    public class Address
    {
        public String country;
        public int buldingNo;
        public String Street;

    }

    [Database]
    public class Position
    {
        public String name;
        public int salary;
        public IEnumerable Employees =>  Db.SQL<Employee>(  "SELECT e FROM Employee e WHERE e.Position = ?", this);

        public void setSalary(int salary)
        {
            Db.Transact(() => this.salary = salary);
        }
    }
    class Program
    {
        static void Main()
        {
            // new DataModel().createData();
            
            
           var department = Db.SQL<Department>("SELECT d FROM Department d Where d.name = ?", "Finanse").First();
            Console.Write("Suma pensji dla departamentu: "+department.countSalary());

            var manager = Db.SQL<Position>("SELECT p FROM StarcounterApplication1.Position p where name = ? ", "Manager").First();
           manager.setSalary(6700);

            var employee = Db.SQL<Employee>("SELECT e FROM Employee e Where e.FirstName = ?", "Krzysztof").First();
            employee.setPosition(manager);
            
        }
    }
}