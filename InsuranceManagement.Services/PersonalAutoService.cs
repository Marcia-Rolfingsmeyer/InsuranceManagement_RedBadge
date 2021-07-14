using InsuranceManagement.Data;
using InsuranceManagement.Models;
using InsuranceManagement.Models.PersonalAuto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceManagement.Services
{
    public class PersonalAutoService
    {
        private readonly Guid _ownerId;

        public PersonalAutoService(Guid ownerId)
        {
            _ownerId = ownerId;
        }

        //Create new Personal Auto
        public bool CreatePersonalAuto(PersonalAutoCreate model)
        {
            var entity =
                new PersonalAuto()
                {
                    //Auto
                    OwnerId = _ownerId,
                    ClientID = model.ClientID,
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
                    YearOfClaim = model.YearOfClaim,

                    //PersonalAuto
                    IsFullCoverage = model.IsFullCoverage,
                    IsLiability = model.IsLiability,
                    IsUninsuredMotorist = model.IsUninsuredMotorist,
                    IsCarRental = model.IsUninsuredMotorist,
                    IsMedicalCoverage = model.IsUninsuredMotorist
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Autos.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //Read - GET - List of Personal Autos
        public IEnumerable<PersonalAutoList> GetPersonalAutos()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .PersonalAutos
                    .Where(e => e.OwnerId == _ownerId)
                    .Select(
                        e =>
                        new PersonalAutoList
                        {
                            AutoID = e.AutoID,
                            ClientID = e.ClientID,
                            //FirstName = e.Client.FirstName,
                            //LastName = e.Client.LastName,
                            Make = e.Make,
                            CarModel = e.CarModel,
                            Year = e.Year,
                            VINNumber = e.VINNumber
                        });
                return query.ToArray();
            }
        }

        //GET : PersonalAuto Details
        public PersonalAutoDetail GetPersonalAutoById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .PersonalAutos
                    .Single(e => e.AutoID == id && e.OwnerId == _ownerId);
                    
                return new PersonalAutoDetail
                    {
                        AutoID = entity.AutoID,
                        ClientID = entity.ClientID,

                        //Auto
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
                        YearOfClaim = entity.YearOfClaim,

                        //PersonalAuto
                        IsFullCoverage = entity.IsFullCoverage,
                        IsLiability = entity.IsLiability,
                        IsUninsuredMotorist = entity.IsUninsuredMotorist,
                        IsCarRental = entity.IsCarRental,
                        IsMedicalCoverage = entity.IsMedicalCoverage,
                };
            }
        }

        //POST: PersonalAutoDetail
        public bool UpdatePersonalAuto(PersonalAutoEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .PersonalAutos
                    .Single(e => e.AutoID == model.AutoID && e.OwnerId == _ownerId);

                // Auto
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

                //PersonalAuto
                entity.IsFullCoverage = model.IsFullCoverage;
                entity.IsLiability = model.IsLiability;
                entity.IsUninsuredMotorist = model.IsUninsuredMotorist;
                entity.IsCarRental = model.IsCarRental;
                entity.IsMedicalCoverage = model.IsMedicalCoverage;

                //FK
                entity.ClientID = model.ClientID;

                return ctx.SaveChanges() == 1;
            }
        }

        //GET: PersonalAuto/Delete
        public bool DeletePersonalAuto(int personalAutoId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .PersonalAutos
                    .Single(e => e.AutoID == personalAutoId && e.OwnerId == _ownerId);

                ctx.PersonalAutos.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
