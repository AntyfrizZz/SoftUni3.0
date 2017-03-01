namespace _08PetClinics
{
    using System;

    public class Room : IComparable<Room>
    {
        public Room()
        {
            this.CurrentPet = null;
            this.IsFree = true;
        }

        public Pet CurrentPet { get; private set; }

        public bool IsFree { get; private set; }

        public void AddPet(Pet pet)
        {
            this.CurrentPet = pet;
            IsFree = false;
        }

        public void RemovePet()
        {
            this.CurrentPet = null;
            IsFree = true;
        }

        public int CompareTo(Room other)
        {
            var result = this.CurrentPet.CompareTo(other.CurrentPet);

            if (result == 0)
            {
                result = this.IsFree.CompareTo(other.IsFree);
            }

            return result;
        }

        public override string ToString()
        {
            if (IsFree)
            {
                return "Room empty";
            }

            return this.CurrentPet.ToString();
        }
    }
}
