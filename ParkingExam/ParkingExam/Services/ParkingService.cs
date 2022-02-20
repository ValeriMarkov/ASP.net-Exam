using ParkingExam.Data;
using ParkingExam.DataAccess;
using System.Collections.Generic;
using System.Linq;

namespace ParkingExam.Services
{
    public class ParkingService : IParkingService
    {
        private readonly ApplicationDbContext db;

        public ParkingService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void AddCar(Car cartoAdd)
        {
            db.Cars.Add(cartoAdd);
            db.SaveChanges();
        }

        public void DeleteCar(int id)
        {
            var carToBeDeleted = this.GetById(id);
            this.db.Cars.Remove(carToBeDeleted);
            db.SaveChanges();
        }

        public void EditCar(Car cartoEdit)
        {
            var car = this.GetById(cartoEdit.Id);

            car.PersonName = cartoEdit.PersonName;
            car.CarBrand = cartoEdit.CarBrand;
            car.LicensePlate = cartoEdit.LicensePlate;

            db.SaveChanges();
        }

        public List<Car> GetCars()
        {
            return db.Cars.ToList();
        }

        public Car GetById(int id)
        {
            return this.db.Cars.FirstOrDefault(x => x.Id == id);
        }
    }
}
