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

        //Create new Auto
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
                    PolicyStartDate = model.PolicyStartDate,
                    LiabilityLimit = model.LiabilityLimit,
                    LossesLastFiveYears = model.LossesLastFiveYears,
                    YearOfLoss = model.YearOfLoss,
                    ClaimsLastFiveYears = model.ClaimsLastFiveYears,
                    AmountOfClaim = model.AmountOfClaim,
                    YearOfClaim = model.YearOfClaim
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Autos.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //Read - GET - List of Autos
        public IEnumerable<AutoListItem> GetAutos()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Autos
                    .Where(e => e.OwnerId == _ownerId)
                    .Select(
                        e =>
                        new AutoListItem
                        {
                            AutoID = e.AutoID,
                            Make = e.Make,
                            CarModel = e.CarModel,
                            Year = e.Year,
                            VINNumber = e.VINNumber
                        });
                return query.ToArray();
            }
        }

        //GET : Auto Details
        public AutoDetail GetAutoById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Autos
                    .Single(e => e.AutoID == id && e.OwnerId == _ownerId);
                return
                    new AutoDetail
                    {
                        AutoID = entity.AutoID,
                        Make = entity.Make,
                        CarModel = entity.CarModel,
                        Year = entity.Year,
                        Mileage = entity.Mileage,
                        VINNumber = entity.VINNumber,
                        CurrentCarrier = entity.CurrentCarrier,
                        CurrentDeductible = entity.CurrentDeductible,
                        PolicyNumber = entity.PolicyNumber,
                        PolicyStartDate = entity.PolicyStartDate,
                        PolicyEndDate = entity.PolicyEndDate,
                        LiabilityLimit = entity.LiabilityLimit,
                        LossesLastFiveYears = entity.LossesLastFiveYears,
                        YearOfLoss = entity.YearOfLoss,
                        ClaimsLastFiveYears = entity.ClaimsLastFiveYears,
                        AmountOfClaim = entity.AmountOfClaim,
                        YearOfClaim = entity.YearOfClaim
                    };
            }
        }

        //POST: AutoDetail
        public bool UpdateAuto (AutoEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Autos
                    .Single(e => e.AutoID == model.AutoID && e.OwnerId == _ownerId);

                entity.Make = model.Make;
                entity.CarModel = model.CarModel;
                entity.Year = model.Year;
                entity.Mileage = model.Mileage;
                entity.VINNumber = model.VINNumber;
                entity.CurrentCarrier = model.CurrentCarrier;
                entity.CurrentDeductible = model.CurrentDeductible;
                entity.PolicyNumber = model.PolicyNumber;
                entity.PolicyStartDate = model.PolicyEndDate;
                entity.LiabilityLimit = model.LiabilityLimit;
                entity.LossesLastFiveYears = model.LossesLastFiveYears;
                entity.YearOfLoss = model.YearOfLoss;
                entity.ClaimsLastFiveYears = model.ClaimsLastFiveYears;
                entity.AmountOfClaim = model.AmountOfClaim;
                entity.YearOfClaim = model.YearOfClaim;

                return ctx.SaveChanges() == 1;
            }
        }

        //GET: Auto/Delete
        public bool DeleteAuto (int autoId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Autos
                    .Single(e => e.AutoID == autoId && e.OwnerId == _ownerId);

                ctx.Autos.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
