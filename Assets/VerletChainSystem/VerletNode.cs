using UnityEngine;

namespace VerletChainSystem
{
    public class VerletNode
    {
        public Vector2 current;
        public Vector2 previous;

        public VerletNode(Vector2 position)
        {
            current = position;
            previous = position;
        }
    }
}
