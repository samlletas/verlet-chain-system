using System;
using UnityEngine;

namespace VerletChainSystem
{
    public abstract class Simulator : MonoBehaviour
    {
        [Header("Simulation")]
        [SerializeField] private int framerate = 30;
        [SerializeField] private float maxStepTime = 0.04f;
        [SerializeField] private bool interpolate = true;

        private float stepTime;
        private float accumulator;

        public event Action<float> Simulated;

        protected virtual void Awake()
        {
            stepTime = Maths.FramesToSeconds(1, framerate);
        }

        protected virtual void LateUpdate()
        {
            accumulator += Time.deltaTime;
            accumulator = Mathf.Min(accumulator, maxStepTime);

            while (accumulator >= stepTime)
            {
                Simulate(stepTime);
                accumulator -= stepTime;
                Simulated?.Invoke(stepTime);
            }

            float interpolation = interpolate ? (accumulator / stepTime) : 1f;
            Render(interpolation);
        }

        protected abstract void Simulate(float stepTime);
        protected abstract void Render(float interpolation);
    }
}
