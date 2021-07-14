using InsuranceManagement.Data;
using InsuranceManagement.Models;
using InsuranceManagement.Models.CommercialAuto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceManagement.Services
{
    public class CommercialAutoService
    {
        private readonly Guid _ownerId;

        public CommercialAutoService(Guid ownerId)
        {
            _ownerId = ownerId;
        }

        //Create new Commercial Auto
        public bool CreateCommercialAuto(CommercialAutoCreate model)
        {
            var entity =
                new CommercialAuto()
                {
                    OwnerId = _ownerId,
                    ClientID = model.ClientID,

                    //CommercialAuto
                    NumberInFleet = model.NumberInFleet,

                   //make method (per vehicle in fleet)
                    Make = model.Make,
                    CarModel = model.CarModel,
                    Year = model.Year,
                    Mileage = model.Mileage,
                    VINNumber = model.VINNumber,

                    NumberOfDrivers = model.NumberOfDrivers,
                    DOTNumber = model.DOTNumber,
                    RadiusOfOperation = model.RadiusOfOperation,
                    CompDeductible = model.CompDeductible,
                    CollisionDeductible = model.CollisionDeductible,

                    //Auto
                    CurrentCarrier = model.CurrentCarrier,
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
                ctx.CommercialAutos.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //Read - GET - List of Commercial Autos
        public IEnumerable<CommercialAutoList> GetCommercialAutos()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .CommercialAutos
                    .Where(e => e.OwnerId == _ownerId)
                    .Select(
                        e =>
                        new CommercialAutoList
                        {
                            AutoID = e.AutoID,
                            ClientID = e.ClientID,
                            NumberInFleet = e.NumberInFleet
                        });
                return query.ToArray();
            }
        }

        //GET : CommercialAuto Details
        public CommercialAutoDetail GetCommercialAutoById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .CommercialAutos
                    .Single(e => e.AutoID == id && e.OwnerId == _ownerId);
                return
                    new CommercialAutoDetail
                    {

                        //CommercialAuto
                        AutoID = entity.AutoID,
                        ClientID = entity.ClientID,


                        NumberInFleet = entity.NumberInFleet,

                        //make method (per vehicle in fleet)
                        Make = entity.Make,
                        CarModel = entity.CarModel,
                        Year = entity.Year,
                        Mileage = entity.Mileage,
                        VINNumber = entity.VINNumber,


                        NumberOfDrivers = entity.NumberOfDrivers,
                        DOTNumber = entity.DOTNumber,
                        RadiusOfOperation = entity.RadiusOfOperation,
                        CompDeductible = entity.CompDeductible,
                        CollisionDeductible = entity.CollisionDeductible,

                        //Auto
                        CurrentCarrier = entity.CurrentCarrier,
                        PolicyNumber = entity.PolicyNumber,
                        PolicyStartDate = entity.PolicyStartDate,
                        PolicyEndDate = entity.PolicyEndDate,
                        LiabilityLimit = entity.LiabilityLimit,
                        LossesLastFiveYears = entity.LossesLastFiveYears,
                        YearOfLoss = entity.YearOfLoss,
                        ClaimsLastFiveYears = entity.ClaimsLastFiveYears,
                        AmountOfClaim = entity.AmountOfClaim,
                        YearOfClaim = entity.YearOfClaim,
                    };
            }
        }

        //POST: CommercialAutoDetail
        public bool UpdateCommercialAuto(CommercialAutoEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .CommercialAutos
                    .Single(e => e.AutoID == model.AutoID && e.OwnerId == _ownerId);

                //make method (per vehicle in fleet)
                entity.Make = model.Make;
                entity.CarModel = model.CarModel;
                entity.Year = model.Year;
                entity.Mileage = model.Mileage;
                entity.VINNumber = model.VINNumber;

                //CommercialAuto
                entity.NumberInFleet = model.NumberInFleet;
                entity.NumberOfDrivers = model.NumberOfDrivers;
                entity.DOTNumber = model.DOTNumber;
                entity.RadiusOfOperation = model.RadiusOfOperation;
                entity.CompDeductible =
                    model.CompDeductible;
                entity.CollisionDeductible = model.CollisionDeductible;

                //Auto
                entity.CurrentCarrier = model.CurrentCarrier;
                entity.PolicyNumber = model.PolicyNumber;
                entity.PolicyStartDate = model.PolicyEndDate;
                entity.LiabilityLimit = model.LiabilityLimit;
                entity.LossesLastFiveYears = model.LossesLastFiveYears;
                entity.YearOfLoss = model.YearOfLoss;
                entity.ClaimsLastFiveYears = model.ClaimsLastFiveYears;
                entity.AmountOfClaim = model.AmountOfClaim;
                entity.YearOfClaim = model.YearOfClaim;

                //FK
                entity.ClientID = model.ClientID;

                return ctx.SaveChanges() == 1;
            }
        }

        //GET: CommercialAuto/Delete
        public bool DeleteCommercialAuto(int AutoId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .CommercialAutos
                    .Single(e => e.AutoID == AutoId && e.OwnerId == _ownerId);

                ctx.CommercialAutos.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
