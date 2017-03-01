namespace _08PetClinics
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Clinic
    {
        public static Dictionary<string, Clinic> clinics = new Dictionary<string, Clinic>();

        private readonly Room[] rooms;
        private int numberOfPetsInClinic;

        private string name;
        private int numberOfRooms;

        public Clinic(string name, int numberOfRooms)
        {
            this.name = name;
            this.NumberOfRooms = numberOfRooms;

            this.rooms = new Room[numberOfRooms];

            for (int i = 0; i < numberOfRooms; i++)
            {
                this.rooms[i] = new Room();
            }

            clinics.Add(this.name, this);
        }

        private int NumberOfRooms
        {
            set
            {
                if (value % 2 == 0)
                {
                    throw new InvalidOperationException("Invalid Operation!");
                }

                this.numberOfRooms = value;
            }
        }

        public bool AddPet(Pet pet)
        {
            if (this.numberOfPetsInClinic == this.rooms.Length)
            {
                return false;
            }

            var startRoom = this.rooms.Length / 2;

            for (int i = 0; i < this.rooms.Length; i++)
            {
                if (i % 2 == 1)
                {
                    startRoom += i * -1;
                }
                else
                {
                    startRoom += i;
                }

                if (!this.rooms[startRoom].IsFree) continue;

                this.rooms[startRoom].AddPet(pet);
                this.numberOfPetsInClinic++;
                return true;
            }

            throw new InvalidOperationException("Something gone wrong with AddPet lol");
        }

        public bool ReleasePet()
        {
            if (this.numberOfPetsInClinic == 0)
            {
                return false;
            }

            var startRoom = this.rooms.Length / 2;

            for (int i = 0; i < this.rooms.Length; i++)
            {
                if (!this.rooms[(startRoom + i) % this.rooms.Length].IsFree)
                {
                    this.numberOfPetsInClinic--;
                    this.rooms[(startRoom + i) % this.rooms.Length].RemovePet();
                    return true;
                }
            }

            throw new InvalidOperationException("Something gone wrong with ReleasePet lol");
        }

        public bool HasEmptyRooms()
        {
            return this.numberOfPetsInClinic != this.numberOfRooms;
        }

        public string PrintRoom(int room)
        {
            return this.rooms[room - 1].ToString();
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            for (int i = 0; i < this.numberOfRooms; i++)
            {
                result.AppendLine(this.rooms[i].ToString());
            }

            return result.ToString().Trim();
        }
    }
}
