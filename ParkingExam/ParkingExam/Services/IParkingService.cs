using ParkingExam.Data;
using System.Collections.Generic;

namespace ParkingExam.Services
{
    public interface IParkingService
    {
        void AddCar(Car cartoAdd);

        List<Car> GetCars();

        Car GetById(int id);

        void EditCar(Car car);

        void DeleteCar(int id);
    }
}
