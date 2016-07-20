namespace _04Froggy
{
    using System.Collections;
    using System.Collections.Generic;

    public class Lake : IEnumerable<int>
    {
        private List<int> stones;

        public Lake(List<int> stones)
        {
            this.stones = stones;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < this.stones.Count; i += 2)
            {
                yield return this.stones[i];
            }

            int lastIndex = 0;

            if (this.stones.Count % 2 == 0)
            {
                lastIndex = this.stones.Count - 1;
            }
            else
            {
                lastIndex = this.stones.Count - 2;
            }

            for (int i = lastIndex; i >= 0; i -= 2)
            {
                yield return this.stones[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
