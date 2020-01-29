using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace Reefaktor.Omega
{
    public class PlayerShipController : MonoBehaviour
    {
        private Vector3 initialPosition;
        private Rect boundaries;
        private SpriteRenderer spriteRenderer;

        public void Initialize(Camera mainCamera)
        {
            gameObject.SetActive(false);
            spriteRenderer = GetComponent<SpriteRenderer>();
            initialPosition = mainCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.05f));
            initialPosition.z = transform.position.z;
            boundaries = new Rect()
            {
                min = mainCamera.ViewportToWorldPoint(Vector3.zero),
                max = mainCamera.ViewportToWorldPoint(Vector3.one)
            };
        }

        public void Setup()
        {
            transform.position = initialPosition;
            gameObject.SetActive(true);
        }

        #region Unity Member Functions

        private void LateUpdate()
        {
            LockVerticalPosition();
            ClampHorizontalPosition();
        }
        #endregion

        private void LockVerticalPosition()
        {
            var position = transform.position;
            position.y = position.y != initialPosition.y ? initialPosition.y : position.y;
            transform.position = position;
        }

        private void ClampHorizontalPosition()
        {
            var position = transform.position;
            
            if (position.x - spriteRenderer.bounds.extents.x < boundaries.xMin)
            {
                position.x = boundaries.xMin + spriteRenderer.bounds.extents.x;
            }
            else if (position.x > boundaries.xMax - spriteRenderer.bounds.extents.x)
            {
                position.x = boundaries.xMax - spriteRenderer.bounds.extents.x;
            }

            transform.position = position;
        }

    }
}