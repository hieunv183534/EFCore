using CandidateTestService.Core.Entities;
using CandidateTestService.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CandidateTestService.Repository.Implement
{
    public class SectionRepository : BaseRepository<Section>, ISectionRepository
    {
        public SectionRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }
    }
}
