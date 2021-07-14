using InsuranceManagement.Data;
using InsuranceManagement.Models;
using InsuranceManagement.Models.Client;
using InsuranceManagement.Models.CommercialAuto;
using InsuranceManagement.Models.PersonalAuto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceManagement.Services
{
    public class ClientService
    {
        private readonly Guid _ownerId;

        public ClientService(Guid ownerId)
        {
            _ownerId = ownerId;
        }

        //Create a new Client
        public bool CreateClient(ClientCreate model)
        {
            var entity =
                new Client()
                {
                    OwnerId = _ownerId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Phone = model.Phone,
                    Email = model.Email,
                    Address = model.Address,
                    City = model.City,
                    State = model.State,
                    //ZipCode = model.ZipCode,
                    //County = model.County,
                    //Township = model.Township,
                    //SSNumberTaxID = model.SSNumberTaxID,
                    CreatedUtc = DateTimeOffset.Now,

                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Clients.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        // Read - GET - List of Clients
        public IEnumerable<ClientList> GetClients()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Clients
                    .Where(e => e.OwnerId == _ownerId)
                    .Select(
                        e =>
                            new ClientList
                            {
                                ClientID = e.ClientID,
                                FirstName = e.FirstName,
                                LastName = e.LastName,
                                Phone = e.Phone,
                                Email = e.Email,
                                CreatedUtc = e.CreatedUtc,
                            });
                return query.ToArray();
            }
        }

        //GET : Client Details
        public ClientDetail GetClientById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Clients
                        .Where(e => e.OwnerId == _ownerId)
                        .Single(e => e.ClientID == id);
                return
                new ClientDetail
                {
                    ClientID = entity.ClientID,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    Phone = entity.Phone,
                    Email = entity.Email,
                    Address = entity.Address,
                    City = entity.City,
                    State = entity.State,
                    CreatedUtc = entity.CreatedUtc,
                    ModifiedUtc = entity.ModifiedUtc,

                    PersonalAutos = entity.PersonalAutos

                    .Select(e => new PersonalAutoList()
                    {
                        AutoID = e.AutoID,
                        Make = e.Make,
                        CarModel = e.CarModel,
                        Year = e.Year,
                        VINNumber = e.VINNumber,
                        IsLiability = e.IsLiability,
                        IsFullCoverage = e.IsFullCoverage

                    }).ToList(),

                    CommercialAutos = entity.CommercialAutos

                    .Select(e => new CommercialAutoList()
                    {
                        AutoID = e.AutoID,
                        NumberInFleet = e.NumberInFleet

                    }).ToList()
                };
            }
        }

        // POST : ClientDetail
        public bool UpdateClient(ClientEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Clients
                        .Single(e => e.ClientID == model.ClientID && e.OwnerId == _ownerId);

                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.Phone = model.Phone;
                entity.Email = model.Email;
                entity.Address = model.Address;
                entity.City = model.City;
                entity.State = model.State;

                return ctx.SaveChanges() == 1;
            }
        }

        //Delete
        public bool DeleteClient(int clientId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Clients
                    .Single(e => e.ClientID == clientId && e.OwnerId == _ownerId);

                ctx.Clients.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
