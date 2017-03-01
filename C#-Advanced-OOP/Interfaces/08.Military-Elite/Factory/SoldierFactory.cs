namespace _08.Military_Elite.Factory
{
    using System;
    using Interfaces;
    using Models;

    public class SoldierFactory
    {
        public static ISoldier Soldier(string input)
        {
            var soldierInfo = input.Split();

            var soldierType = soldierInfo[0];
            var soldierId = soldierInfo[1];
            var soldierFirstName = soldierInfo[2];
            var soldierSecondName = soldierInfo[3];

            switch (soldierType)
            {
                case "Private":
                    {
                        var soldierSalary = decimal.Parse(soldierInfo[4]);
                        return new Private(soldierId, soldierFirstName, soldierSecondName, soldierSalary);
                    }

                case "LeutenantGeneral":
                    {
                        var soldierSalary = decimal.Parse(soldierInfo[4]);
                        var leutenant = new LeutenantGeneral(soldierId, soldierFirstName, soldierSecondName, soldierSalary);

                        for (int i = 5; i < soldierInfo.Length; i++)
                        {
                            leutenant.AddPrivate(soldierInfo[i]);
                        }

                        return leutenant;
                    }

                case "Engineer":
                    {
                        var soldierSalary = decimal.Parse(soldierInfo[4]);
                        var soldeirCorps = soldierInfo[5];

                        var engineer = new Engineer(soldierId, soldierFirstName, soldierSecondName, soldierSalary, soldeirCorps);

                        for (int i = 6; i < soldierInfo.Length; i += 2)
                        {
                            var part = soldierInfo[i];
                            var hours = int.Parse(soldierInfo[i + 1]);

                            var repair = new Repair(part, hours);

                            engineer.AddRepair(repair);
                        }

                        return engineer;
                    }

                case "Commando":
                    {
                        var soldierSalary = decimal.Parse(soldierInfo[4]);
                        var soldeirCorps = soldierInfo[5];

                        var commando = new Commando(soldierId, soldierFirstName, soldierSecondName, soldierSalary, soldeirCorps);

                        for (int i = 6; i < soldierInfo.Length; i += 2)
                        {
                            var missionName = soldierInfo[i];
                            var missionState = soldierInfo[i + 1];

                            try
                            {
                                var mission = new Mission(missionName, missionState);

                                commando.AddMission(mission);
                            }
                            catch (Exception)
                            {

                            }
                        }

                        return commando;
                    }

                case "Spy":
                    {
                        var soldeirCodeNumber = soldierInfo[4];

                        return new Spy(soldierId, soldierFirstName, soldierSecondName, int.Parse(soldeirCodeNumber));
                    }
            }

            return null;
        }
    }
}
