using System.Collections;

namespace Froggy
{
    public class Lake : IEnumerable<int>
    {
        private readonly int[] _stones;

        public Lake(int[] stones)
        {
            this._stones = stones;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < _stones.Length; i += 2)
                yield return this._stones[i];

            for (int i = (_stones.Length - (_stones.Length % 2) - 1); i >= 0; i -= 2)
                yield return this._stones[i];
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
