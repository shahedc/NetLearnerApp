using NetLearner.SharedLib.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetLearner.SharedLib.Services
{
    public interface IResourceListService
    {
        Task<List<ResourceList>> Get();
    }
}
