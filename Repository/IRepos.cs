using projectapi.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projectapi.Repository
{
    public interface IRepos
    {
        List<UserAccountTable> GetData();
    }
}
