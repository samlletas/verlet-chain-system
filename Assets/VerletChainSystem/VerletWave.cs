using UnityEngine;

namespace VerletChainSystem
{
    [RequireComponent(typeof(VerletChain))]
    [AddComponentMenu("Verlet Chain System/Verlet Wave")]
    public class VerletWave : MonoBehaviour
    {
        [SerializeField] private float amplitude = 60f;
        [SerializeField] private float frequency = 5f;

        private VerletChain chain;
        private float time;
        private float direction;

        private void Awake()
        {
            chain = GetComponent<VerletChain>();
        }

        private void OnEnable()
        {
            time = 0f;
            direction = chain.gravityDirection;
            chain.Simulated += OnSimulated;
        }

        public void OnSimulated(float stepTime)
        {
            time = Mathf.Repeat(time + stepTime, Mathf.PI * 2f);
            float cosine = Mathf.Cos(time * frequency);
            float offset = amplitude / 2f;
            float directionMin = direction - offset;
            float directionMax = direction + offset;
            chain.gravityDirection = Maths.Remap(cosine, -1f, 1f, directionMin, directionMax);
        }

        private void OnDisable()
        {
            chain.Simulated -= OnSimulated;
        }
    }
}
