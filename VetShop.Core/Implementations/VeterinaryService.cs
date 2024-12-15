using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetShop.Core.Interfaces;
using VetShop.Core.Models;
using VetShop.Infrastructure.Data.Common;
using VetShop.Infrastructure.Data.Models;

namespace VetShop.Core.Implementations
{
    public class VeterinaryService : IVeterinaryService
    {
        private readonly IRepository<Veterinary> repository;
        private ILogger<VeterinaryService> logger;

        public VeterinaryService(IRepository<Veterinary> repository, ILogger<VeterinaryService> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<IEnumerable<VeterinaryServiceModel>> GetAllVeterinariansAsync()
        {
            var veterinaries = await repository.All().Include(x => x.User).ToListAsync();

            var mappedVeterinaries = veterinaries.Select(x => new VeterinaryServiceModel
            {
                Id = x.Id,
                PhoneNumber = x.PhoneNumber,
                FullName = x.User.FirstName + " " + x.User.LastName,
                Specialty = x.Specialty,
                UserId = x.UserId,
            });

            return mappedVeterinaries;
        }



        public Task<VeterinaryServiceModel?> GetVeterinarianByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
