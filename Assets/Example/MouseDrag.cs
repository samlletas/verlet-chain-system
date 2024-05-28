using UnityEngine;

namespace VerletChainSystem.Example
{
    public class MouseDrag : MonoBehaviour
    {
        private bool dragging;
        private Vector3 offset;

        private void Update()
        {
            if (dragging)
            {
                transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            }
        }

        private void OnMouseDown()
        {
            offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            dragging = true;
        }

        private void OnMouseUp()
        {
            dragging = false;
        }
    }
}
