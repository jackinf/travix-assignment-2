using System.Collections.Generic;
using WingsOn.Domain.Dto.Requests;

namespace WingsOn.Domain.Repository
{
    public interface IPersonRepository : IRepository<Person>
    {
        List<Person> Search(PersonSearchRequestDto options);
    }
}