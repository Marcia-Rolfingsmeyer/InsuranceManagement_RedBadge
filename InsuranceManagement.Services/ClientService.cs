using InsuranceManagement.Data;
using InsuranceManagement.Models;
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
                    ZipCode = model.ZipCode,
                    County = model.County,
                    Township = model.Township,
                    SSNumberTaxID = model.SSNumberTaxID,
                    CreatedUtc = DateTimeOffset.Now
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
                                CreatedUtc = e.CreatedUtc
                            });
                return query.ToArray();
            }
        }
    }
}
