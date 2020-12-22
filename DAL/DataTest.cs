using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppTest1.DAL
{
    public class DataTest
    {
        public DaoData funcReturn()
        {
            var objDaoData = new DaoData();
            objDaoData.id = "10000";

            return objDaoData;
        }

    }
}
