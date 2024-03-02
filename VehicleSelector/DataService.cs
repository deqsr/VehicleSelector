using System;
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


        public List<Part> SearchParts(string name, string compatible_with, decimal minPrice, decimal maxPrice, string category)
        {
            IQueryable<Part> query = _dbContext.Part.Include("PartImage");

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(p => p.name.Contains(name));
            }

            if (!string.IsNullOrEmpty(compatible_with))
            {
                query = query.Where(p => p.compatible_with.Contains(compatible_with));
            }

            if (minPrice > 0)
            {
                query = query.Where(p => p.price >= minPrice);
            }

            if (maxPrice < decimal.MaxValue)
            {
                query = query.Where(p => p.price <= maxPrice);
            }

            if (!string.IsNullOrEmpty(category))
            {
                query = query.Where(p => p.name.Contains(category));
            }

            List<Part> parts = query.ToList();
            foreach (var part in parts)
            {
                if (part.PartImage != null)
                {
                    part.PartImage.image = _dbContext.PartImage.Find(part.PartImage.id)?.image;
                }
            }
            return parts;
        }

        public List<string> GetUniqueVehicleModels()
        {
            return _dbContext.Part
                              .Where(p => !string.IsNullOrEmpty(p.compatible_with))
                              .Select(p => p.compatible_with)
                              .Distinct()
                              .ToList();
        }
        public List<string> GetUniqueCategories()
        {
            return _dbContext.Part.Select(p => p.name).Distinct().ToList();
        }


    }
}
