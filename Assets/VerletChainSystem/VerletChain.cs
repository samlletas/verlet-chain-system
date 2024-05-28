using UnityEngine;

namespace VerletChainSystem
{
    [RequireComponent(typeof(LineRenderer))]
    [AddComponentMenu("Verlet Chain System/Verlet Chain")]
    public class VerletChain : Simulator
    {
        [Header("Body")]
        [SerializeField] protected float length = 2.5f;
        [SerializeField] protected int resolution = 19;

        [Header("Dynamics")]
        [SerializeField] public float drag = 0.7f;
        [SerializeField] public float gravityForce = 25f;
        [SerializeField] public float gravityDirection = 270f;

        protected LineRenderer lineRenderer;
        protected VerletNode[] nodes;
        protected float nodeDistance;

        protected override void Awake()
        {
            base.Awake();
            lineRenderer = GetComponent<LineRenderer>();
            lineRenderer.positionCount = resolution;
            CreateNodes();
        }

        protected virtual void CreateNodes()
        {
            nodes = new VerletNode[resolution];
            nodeDistance = length / resolution;

            for (int i = 0; i < nodes.Length; i++)
            {
                Vector2 position = transform.position + (i * nodeDistance * Vector3.down);
                nodes[i] = new VerletNode(position);
            }
        }

        protected override void Simulate(float stepTime)
        {
            VerletNode root = nodes[0];
            root.previous = root.current;
            root.current = transform.position;
            SimulateNodes(stepTime);
            ConstrainNodes();
        }

        protected virtual void SimulateNodes(float stepTime)
        {
            Vector2 gravity = CalculateGravity();

            for (int i = 1; i < nodes.Length; i++)
            {
                VerletNode node = nodes[i];
                Vector2 velocity = node.current - node.previous;
                node.previous = node.current;
                node.current += velocity * drag;
                node.current += stepTime * stepTime * gravity;
            }
        }

        protected virtual Vector2 CalculateGravity()
        {
            float direction = (transform.lossyScale.x > 0f) ? gravityDirection : Maths.FlipAngleY(gravityDirection);
            return Maths.GetDirection(direction) * gravityForce;
        }

        protected virtual void ConstrainNodes()
        {
            for (int i = 0; i < nodes.Length - 1; i++)
            {
                VerletNode nodeA = nodes[i];
                VerletNode nodeB = nodes[i + 1];
                Vector2 offset = nodeB.current - nodeA.current;
                nodeB.current = nodeA.current + (offset.normalized * nodeDistance);
            }
        }

        protected override void Render(float interpolation)
        {
            Vector2 origin = Vector2.Lerp(nodes[0].previous, nodes[0].current, interpolation);
            Vector2 offset = (Vector2)transform.position - origin;

            for (int i = 0; i < nodes.Length; i++)
            {
                Vector2 position = Vector2.Lerp(nodes[i].previous, nodes[i].current, interpolation);
                lineRenderer.SetPosition(i, position + offset);
            }
        }
    }
}
