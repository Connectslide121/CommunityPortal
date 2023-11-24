using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseConnection
{
    public class DataConnection : IDataConnection
    {
        readonly DataContext _dataContext;

        public DataConnection(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
    }
}
