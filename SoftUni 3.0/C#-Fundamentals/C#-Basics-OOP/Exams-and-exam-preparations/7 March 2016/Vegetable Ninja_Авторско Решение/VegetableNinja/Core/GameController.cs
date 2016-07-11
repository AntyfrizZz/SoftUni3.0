namespace VegetableNinja.Core
{
    using System;
    using System.Linq;

    using VegetableNinja.Enumerations;
    using VegetableNinja.Interfaces;
    using VegetableNinja.Models;
    using VegetableNinja.Models.Vegetables;

    public class GameController : IGameController
    {
        private readonly IDatabase database;

        private INinja currentNinja;

        private INinja winnerNinja;

        public GameController(IDatabase database)
        {
            this.database = database;
            this.winnerNinja = null;
        }

        public IDatabase Database
        {
            get
            {
                return this.database;
            }
        }

        public INinja WinnerNinja
        {
            get
            {
                return this.winnerNinja;
            }
        }

        public void InitialiseGameData(string firstNinjaName)
        {
            this.currentNinja = this.Database.Ninjas.First(ninja => ninja.Name.Equals(firstNinjaName));
            this.AttachEvents();
        }

        public void ProcessInput(string inputLine)
        {
            foreach (var direction in inputLine)
            {
                IMatrixPosition newPosition = this.GetNewPosition(this.currentNinja.Position, direction);
                
                if (newPosition == null)
                {
                    this.currentNinja.Move(newPosition);
                }
                else
                {
                    this.ProcessMove(newPosition);
                }

                if (this.WinnerNinja != null)
                {
                    return;
                }

                if (this.currentNinja.Stamina == 0)
                {
                    this.currentNinja.EatVegetables();
                    this.SwitchPlayer();
                }

                this.GrowVegetables();
            }
        }

        private void ProcessMove(IMatrixPosition newPosition)
        {
            IMatrixPosition oldNinjaPosition = this.currentNinja.Position;
            this.currentNinja.Move(newPosition);

            if (
                this.Database.Vegetables.Any(
                    veg =>
                    veg.Position.Equals(newPosition)))
            {
                IVegetable currentVegetable =
                    this.Database.Vegetables.First(
                        veg =>
                    veg.Position.Equals(newPosition));

                this.Database.RemoveVegetable(currentVegetable);
                this.currentNinja.CollectVegetable(currentVegetable);
                
                IBlankSpace newBlankSpace = new BlankSpace(
                    this.currentNinja.Position,
                    currentVegetable.TimeToGrow,
                    (VegetableType)Enum.Parse(typeof(VegetableType), currentVegetable.GetType().Name));

                this.Database.AddGrowingVegetable(newBlankSpace);

                IBlankSpace oldFieldPositionElement = new BlankSpace(oldNinjaPosition, -1, VegetableType.Blank);

                if (
                    this.Database.GrowingVegetables.Any(
                        growingVegetable =>
                        growingVegetable.Position.Equals(oldNinjaPosition)))
                {
                    oldFieldPositionElement =
                        this.Database.GrowingVegetables.First(
                            growingVegetable =>
                            growingVegetable.Position.Equals(oldNinjaPosition));
                }

                this.Database.SetGameFieldObject(oldNinjaPosition, oldFieldPositionElement);
                this.Database.SetGameFieldObject(this.currentNinja.Position, this.currentNinja);
                return;
            }

            INinja otherNinja = this.Database.GetOtherPlayer(this.currentNinja.Name);

            if (this.currentNinja.Position.Equals(otherNinja.Position))
            {
                this.Fight();
            }
        }

        private void SwitchPlayer()
        {
            this.currentNinja = this.Database.GetOtherPlayer(this.currentNinja.Name);
        }

        private void Fight()
        {
            this.winnerNinja = this.currentNinja.Power >= this.Database.GetOtherPlayer(this.currentNinja.Name).Power
                       ? this.currentNinja
                       : this.Database.GetOtherPlayer(this.currentNinja.Name);
        }

        private void GrowVegetables()
        {
            foreach (var growingVegetable in this.Database.GrowingVegetables)
            {
                if (!this.Database.Ninjas.Any(ninja => 
                    ninja.Position.Equals(growingVegetable.Position)))
                {
                    growingVegetable.Grow();    
                }
                
                if (growingVegetable.GrowthTime == 0)
                {
                    IVegetable newVegetable = null;

                    IMatrixPosition position = growingVegetable.Position;
                            
                    switch (growingVegetable.VegetableHolder)
                    {
                        case VegetableType.Asparagus:
                            newVegetable = new Asparagus(position);
                            break;
                        case VegetableType.Broccoli:
                            newVegetable = new Broccoli(position);
                            break;
                        case VegetableType.CherryBerry:
                            newVegetable = new CherryBerry(position);
                            break;
                        case VegetableType.Mushroom:
                            newVegetable = new Mushroom(position);
                            break;
                        case VegetableType.Royal:
                            newVegetable = new Royal(position);
                            break;
                    }

                    this.Database.AddVegetable(newVegetable);
                    this.Database.SetGameFieldObject(growingVegetable.Position, newVegetable);
                }
            }
        }

        private void AttachEvents()
        {
            foreach (var ninja in this.Database.Ninjas)
            {
                INinja currentEventNinja = ninja;
                currentEventNinja.MeloLemonMelonEaten += this.ApplyMeloLemonMelon;
            }
        }

        private void ApplyMeloLemonMelon(INinja givenNinja, EventArgs args)
        {
            var enemies = this.Database.Ninjas.Where(ninja => !ninja.Equals(givenNinja));
            foreach (var enemy in enemies)
            {
                for (int i = 0; i < 5; i++)
                {
                    IVegetable mushroom = new Mushroom(new MatrixPosition(0, 0));
                    enemy.CollectVegetable(mushroom);
                }

                enemy.EatVegetables();
            }
        }

        private bool ValidateCoordinate(int positionX, int positionY)
        {
            return positionX >= 0 && positionX < this.Database.GameField.Count() &&
            positionY >= 0 && positionY < this.Database.GameField.First().Count();
        }

        private IMatrixPosition GetNewPosition(IMatrixPosition oldPosition, char direction)
        {
            switch (direction)
            {
                case 'U':
                    if (!this.ValidateCoordinate(oldPosition.PositionX - 1, oldPosition.PositionY))
                    {
                        break;
                    }

                    return new MatrixPosition(oldPosition.PositionX - 1, oldPosition.PositionY);
                case 'R':
                    if (!this.ValidateCoordinate(oldPosition.PositionX, oldPosition.PositionY + 1))
                    {
                        break;
                    }

                    return new MatrixPosition(oldPosition.PositionX, oldPosition.PositionY + 1);
                case 'D':
                    if (!this.ValidateCoordinate(oldPosition.PositionX + 1, oldPosition.PositionY))
                    {
                        break;
                    }

                    return new MatrixPosition(oldPosition.PositionX + 1, oldPosition.PositionY);
                case 'L':
                    if (!this.ValidateCoordinate(oldPosition.PositionX, oldPosition.PositionY - 1))
                    {
                        break;
                    }

                    return new MatrixPosition(oldPosition.PositionX, oldPosition.PositionY - 1);
            }

            return null;
        }
    }
}
