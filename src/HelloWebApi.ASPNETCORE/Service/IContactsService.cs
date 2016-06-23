using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWebApi.ASPNETCORE.Models;

namespace HelloWebApi.ASPNETCORE.Repositorys
{
    public interface IContactsService
    {
        void Add(Contacts item);
        IEnumerable<Contacts> GetAll();
        Contacts Find(string key);
        void Remove(string Id);
        void Update(Contacts item);
    }
}
