using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Starcounter;

namespace StarcounterApplication1
{
    class DataModel
    {
        public void createData()
        {
            var company1 = Db.Transact(() => new Company()
            {
                name = "MyCompany"
            });

            var departmentFinanse = Db.Transact(() => new Department()
            {
                name = "Finanse",
                Company = company1
            });

            var departmentIt = Db.Transact(() => new Department()
            {
                name = "IT",
                Company = company1
            });

      
            var positionManager = Db.Transact(() => new Position()
            {
                name = "Manager",
                salary = 4500
            });

            var positionKsiegowy = Db.Transact(() => new Position()
            {
                name = "Ksiegowy",
                salary = 5000
            });

            var positionAdministrator = Db.Transact(() => new Position()
            {
                name = "Administrator",
                salary = 6000
            });


            var adres1 = Db.Transact(() => new Address()
            {
                country = "Polska",
                buldingNo = 124,
                Street = "Kasprowicza"
            });

            var adres2 = Db.Transact(() => new Address()
            {
                country = "Polska",
                buldingNo = 12,
                Street = "Kasprzaka"
            });

            var emp1 = Db.Transact(() => new Employee()
            {
                FirstName = "Krzysztof",
                LastName = "Kowalski",
                Department = departmentFinanse,
                position = positionKsiegowy,
                adress = adres1


            });
            var emp2 = Db.Transact(() => new Employee()
            {
                FirstName = "Jan",
                LastName = "Malinowski",
                Department = departmentFinanse,
                position = positionManager,
                adress = adres2

            });

            var emp3 = Db.Transact(() => new Employee()
            {
                FirstName = "Wojciech",
                LastName = "Adamski",
                Department = departmentIt,
                position = positionManager,
                adress = adres2

            });

            var emp4 = Db.Transact(() => new Employee()
            {
                FirstName = "Adam",
                LastName = "Abacki",
                Department = departmentIt,
                position = positionAdministrator,
                adress = adres2

            });

            var emp5 = Db.Transact(() => new Employee()
            {
                FirstName = "Michal",
                LastName = "Kochanowski",
                Department = departmentIt,
                position = positionManager,
                adress = adres1

            });

        }

        public void deleteData()
        {
            //DELETE FROM StarCounterApplication1.Employee
           //Delete  FROM  StarCounterApplication1.Position
           // DELETE FROM StarCounterApplication1.Address
            // DELETE FROM StarCounterApplication1.Department
            //DELETE FROM StarCounterApplication1.Company

        }
    }
}
