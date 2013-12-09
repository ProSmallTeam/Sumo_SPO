using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public interface IQueryConvector
    {
        List<int> Convert(string query);
    }
}
