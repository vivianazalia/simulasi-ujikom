using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MatchTile.Base;

namespace MatchTile.Inputs
{
    public class InputHandler : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastObject(Input.mousePosition);
            }
        }

        public void RaycastObject(Vector2 screenPos)
        {
            Vector2 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
            var hit = Physics2D.Raycast(worldPos, Vector2.zero);

            if (hit.collider != null)
            {
                IRaycastable obj = hit.collider.GetComponent<IRaycastable>();
                obj?.OnRaycastHit();
            }
        }
    }
}

