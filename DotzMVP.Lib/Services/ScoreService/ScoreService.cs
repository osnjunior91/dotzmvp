using DotzMVP.Lib.Infrastructure.Data.Model;
using DotzMVP.Lib.Infrastructure.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DotzMVP.Lib.Services.ScoreService
{
    public class ScoreService : IScoreService
    {
        private readonly IRepository<Score> _scoreRepository;
        public ScoreService(IRepository<Score> scoreRepository)
        {
            _scoreRepository = scoreRepository;
        }
        public async Task<Score> CreateAsync(Score item)
        {
            return await _scoreRepository.CreateAsync(item);
        }

        public async Task<List<Score>> GetByFilterAsync(Expression<Func<Score, bool>> filter, List<Expression<Func<Score, object>>> including = null)
        {
            return await _scoreRepository.GetByFilterAsync(filter, including);
        }

        public async Task<Score> GetByIdAsync(Guid id, List<Expression<Func<Score, object>>> including = null)
        {
            return await _scoreRepository.GetByIdAsync(id, including);
        }

        public async Task<Score> UpdateAsync(Score item)
        {
            return await _scoreRepository.UpdateAsync(item);
        }
    }
}
