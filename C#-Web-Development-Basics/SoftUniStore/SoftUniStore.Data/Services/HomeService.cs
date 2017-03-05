using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SoftUniStore.Models;
using SoftUniStore.Models.ViewModels;

namespace SoftUniStore.Data.Services
{
    public class HomeService : Service
    {
        public HashSet<GameHomePageViewModel> GetAllGames(string filter, string sessionId)
        {
            var result = new HashSet<GameHomePageViewModel>();

            if (filter == "owned")
            {
                var user = base.GetUserFromSession(sessionId);

                foreach (var game in user.Games)
                {
                    result.Add(Mapper.Map<Game, GameHomePageViewModel>(game));
                }
            }
            else
            {
                var games = this.unitOfWork.GamesRepository.Get();

                foreach (var game in games)
                {
                    result.Add(Mapper.Map<Game, GameHomePageViewModel>(game));
                }
            }

            return result;
        }
    }
}
