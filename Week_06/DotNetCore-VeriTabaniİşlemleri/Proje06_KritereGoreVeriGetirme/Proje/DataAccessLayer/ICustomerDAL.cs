using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Proje.DataAccessLayer.Entities;

namespace Proje.DataAccessLayer
{
    public interface ICustomerDAL
    {
        void Create(Customer customer);
        List<Customer> GetAll();
        Customer GetById(int id);
        void Update(Customer customer);
        void Delete(int id);
    }
}