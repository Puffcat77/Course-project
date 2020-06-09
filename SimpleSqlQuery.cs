using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_project
{
    public class SimpleSqlQuery
    {
        public string Sql { get; set; }
        public string Name { get; set; }

        public SimpleSqlQuery(string sql, string name)
        {
            Sql = sql;
            Name = name;
        }
    }
}
