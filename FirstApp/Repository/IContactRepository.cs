using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApp.Repository
{
    interface IContactRepository
    {
        DataTable Search(string parameter);
        DataTable SelectAll();
        DataTable SelectRow(int contactId);

        bool Insert(string name, string family, string mobile, string email, int age, string address);
        bool Update(int contactId , string name, string family, string mobile, string email, int age, string address);
        bool Delete(int contactId);
    }
}
