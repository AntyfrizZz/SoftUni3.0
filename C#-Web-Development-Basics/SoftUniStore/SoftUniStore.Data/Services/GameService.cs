using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AutoMapper;
using SoftUniStore.Common;
using SoftUniStore.Models;
using SoftUniStore.Models.BindingModels;
using SoftUniStore.Models.ViewModels;

namespace SoftUniStore.Data.Services
{
    public class GameService : Service
    {
        public GameDetailsViewModel GetGameDetails(int id)
        {
            var game = this.unitOfWork.GamesRepository.GetByID(id);

            return Mapper.Map<Game, GameDetailsViewModel>(game);
        }

        public HashSet<AdminGameViewModel> GetAllAdminGames()
        {
            var result = new HashSet<AdminGameViewModel>();

            var games = this.unitOfWork.GamesRepository.Get();

            foreach (var game in games)
            {
                result.Add(Mapper.Map<Game, AdminGameViewModel>(game));
            }

            return result;
        }

        public bool IsGameModelValid(GameBindingModel model)
        {
            if (model.Title.Length < 3 || model.Title.Length > 100)
            {
                return false;
            }

            if (char.IsLower(model.Title[0]))
            {
                return false;
            }

            if (model.Price <= 0)
            {
                return false;
            }

            if (model.Size <= 0)
            {
                return false;
            }

            if (!Regex.IsMatch(model.ImageThumbnail, GlobalConstants.ImageLinkPattern))
            {
                return false;
            }

            if (model.Description.Length < GlobalConstants.DescriptionMinLength)
            {
                return false;
            }

            return true;
        }

        public void BuyGame(string sessionId, GameIdBindingModel model)
        {
            var user = base.GetUserFromSession(sessionId);
            var game = this.unitOfWork.GamesRepository.Get(g => g.Id == model.Id).SingleOrDefault();

            user.Games.Add(game);

            this.unitOfWork.Save();
        }

        public GameBindingModel GetGame(int id)
        {
            var game = this.unitOfWork.GamesRepository.GetByID(id);

            return Mapper.Map<Game, GameBindingModel>(game);
        }

        public void AddGame(GameBindingModel model)
        {
            Game game = Mapper.Map<GameBindingModel, Game>(model);

            this.unitOfWork.GamesRepository.Insert(game);
            this.unitOfWork.Save();
        }

        public void UpdateGame(GameBindingModel model, int id)
        {
            var game = this.unitOfWork.GamesRepository.GetByID(id);

            game.Title = model.Title;
            game.Trailer = model.Trailer;
            game.ImageThumbnail = model.ImageThumbnail;
            game.Size = model.Size;
            game.Price = model.Price;
            game.Description = model.Description;

            this.unitOfWork.Save();
        }

        public DeleteGameViewModel GetGameForDeletion(int id)
        {
            var game = this.unitOfWork.GamesRepository.GetByID(id);

            return Mapper.Map<Game, DeleteGameViewModel>(game);
        }

        public void DeleteGame(int id)
        {
            var game = this.unitOfWork.GamesRepository.GetByID(id);

            this.unitOfWork.GamesRepository.Delete(game);
            this.unitOfWork.Save();
        }
    }
}
