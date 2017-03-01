namespace LambdaCore_Skeleton.Core.Factories
{
    using System;
    using Contracts.Core;
    using Contracts.Models;

    public class FragmentFactory : IFragmentFactory
    {
        private const string NamespacePath = "LambdaCore_Skeleton.Models.Fragments.";
        private const string PostText = "Fragment";

        public IFragment CreateFragment(string type, string name, int pressure)
        {
            var fragmentFullName = NamespacePath + type + PostText;

            Type t = Type.GetType(fragmentFullName);
            object[] fragmentParameters = new object[] { name, pressure };

            IFragment fragment;
            try
            {
                fragment = (IFragment)Activator.CreateInstance(t, fragmentParameters);
            }
            catch
            {
                throw new InvalidOperationException($"Failed to attach Fragment {name}!");
            }

            return fragment;
        }
    }
}