using System.Collections.Generic;
using System.Linq;

namespace VehicleSelector
{
    public class DataService
    {
        private readonly TransportSelectionDBEntities _dbContext;

        public DataService()
        {
            _dbContext = new TransportSelectionDBEntities();
        }

        public List<Car> SearchCars(string brand, string model, int year, decimal minPrice, decimal maxPrice, string color, int mileage, string condition, string type)
        {
            var query = _dbContext.Car.AsNoTracking()
                .Include("Image")
                .Include("CarDescription")
                .Where(c => (string.IsNullOrEmpty(brand) || c.brand.Contains(brand))
                            && (string.IsNullOrEmpty(model) || c.model.Contains(model))
                            && (year <= 0 || c.year == year)
                            && (minPrice <= 0 || c.price >= minPrice)
                            && (maxPrice == decimal.MaxValue || c.price <= maxPrice)
                            && (string.IsNullOrEmpty(color) || c.color.Contains(color))
                            && (mileage <= 0 || c.mileage == mileage)
                            && (string.IsNullOrEmpty(condition) || c.condition.Contains(condition))
                            && (string.IsNullOrEmpty(type) || c.type.Contains(type)))
                .ToList();

            query.ForEach(car =>
            {
                if (car.Image != null)
                {
                    car.Image.image1 = _dbContext.Image.AsNoTracking().FirstOrDefault(i => i.id == car.Image.id)?.image1;
                }
            });

            return query;
        }

        public string GetCarDescription(int carId)
        {
            return _dbContext.CarDescription.AsNoTracking().FirstOrDefault(cd => cd.Car_id == carId)?.description;
        }

        public List<Part> SearchParts(string name, string description, decimal minPrice, decimal maxPrice)
        {
            var query = _dbContext.Part.AsNoTracking()
                .Include("PartImage")
                .Where(p => (string.IsNullOrEmpty(name) || p.name.Contains(name))
                            && (string.IsNullOrEmpty(description) || p.description.Contains(description))
                            && (minPrice <= 0 || p.price >= minPrice)
                            && (maxPrice == decimal.MaxValue || p.price <= maxPrice))
                .ToList();

            query.ForEach(part =>
            {
                if (part.PartImage != null)
                {
                    part.PartImage.image = _dbContext.PartImage.AsNoTracking().FirstOrDefault(pi => pi.id == part.PartImage.id)?.image;
                }
            });

            return query;
        }
    }
}