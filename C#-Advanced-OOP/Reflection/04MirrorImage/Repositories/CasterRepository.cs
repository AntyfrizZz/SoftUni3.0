namespace _04MirrorImage.Repositories
{
    using System.Collections.Generic;
    using Contracts;

    public static class CasterRepository
    {
        static Dictionary<int, ICast> casters = new Dictionary<int, ICast>();

        public static void AddCaster(ICast caster)
        {
            CasterRepository.casters.Add(caster.Id, caster);
        }

        public static ICast GetCaster(int id)
        {
            return casters[id];
        }
    }
}
