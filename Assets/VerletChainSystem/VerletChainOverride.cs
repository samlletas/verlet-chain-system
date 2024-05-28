using UnityEngine;

namespace VerletChainSystem
{
    public abstract class VerletChainOverride<T> : ScriptableObject where T : VerletChain
    {
        [Header("Dynamics")]
        [SerializeField] private float drag = 0.7f;
        [SerializeField] private float gravityForce = 25f;
        [SerializeField] private float gravityDirection = 270f;

        public virtual void Apply(T chain)
        {
            chain.drag = drag;
            chain.gravityForce = gravityForce;
            chain.gravityDirection = gravityDirection;
        }
    }

    [CreateAssetMenu(menuName = "Verlet Chain System/Verlet Chain Override")]
    public class VerletChainOverride : VerletChainOverride<VerletChain>
    {
    }
}
