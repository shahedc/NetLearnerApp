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
        Task<ResourceList> Get(int id);
        Task<ResourceList> Add(ResourceList resourceList);
        Task<ResourceList> Update(ResourceList resourceList);
        Task<ResourceList> Delete(int id);
    }
}
