using NetLearner.SharedLib.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetLearner.SharedLib.Services
{
    public interface ILearningResourceService
    {
        Task<List<LearningResource>> Get();
        Task<List<LearningResource>> GetForList(int id);
        Task<List<LearningResource>> GetTop(int topX);
        Task<LearningResource> Get(int id);
        Task<LearningResource> Add(LearningResource learningResource);
        Task<LearningResource> Update(LearningResource learningResource);
        Task<LearningResource> Delete(int id);
    }
}
