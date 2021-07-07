using InsuranceManagement.Data;
using InsuranceManagement.Models.Auto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceManagement.Services
{
    public class AutoService
    {
        private readonly Guid _ownerId;

        public AutoService(Guid ownerId)
        {
            _ownerId = ownerId;
        }

        public bool CreateAuto(AutoCreate model)
        {
            var entity =
                new Auto()
                {
                    OwnerId = _ownerId,
                    Make = model.Make,
                    CarModel = model.CarModel,
                    Year = model.Year,
                    Mileage = model.Mileage,
                    VINNumber = model.VINNumber,
                    CurrentCarrier = model.CurrentCarrier,
                    CurrentDeductible = model.CurrentDeductible,
                    PolicyNumber = model.PolicyNumber,
                    PolicyEndDate = model.PolicyEndDate,
                    PolicyStartDate = model.PolicyStartDate
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Autos.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<AutoListItem> GetAutos()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Autos.AsEnumerable()
                    .Where(e => e.OwnerId != null)
                    .Select(
                        e =>
                        new AutoListItem
                        {
                            AutoID = e.AutoID,
                            Make = e.Make,
                            CarModel = e.CarModel,
                            Year = e.Year,
                            VINNumber = e.VINNumber
                        }
                        );
                return query.ToArray();
            }
        }
    }
}
