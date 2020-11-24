using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotzMVP.Model.User
{
    public class UserListScoreResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double TotalScore { get; set; }
        public List<UserRegisterScoreResponse> Scores { get; set; }
    }
}
