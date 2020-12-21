using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskBackEnd.Entites;
using TaskBackEnd.Entites.InnerEntities;

namespace TaskBackEnd.IRepos
{
    public interface ITestRepo
    {
        Task <List<InnerTask1Model>> Test();
    }
}
