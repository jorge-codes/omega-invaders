using UnityEngine;

namespace Reefaktor.Omega
{
    public class SpaceBackgroundController : MonoBehaviour
    {
        [SerializeField, Range(0.1f, 20f)] private float speed;
        [SerializeField] private Material material;
        private bool isActive;

        public void Play()
        {
            isActive = true;
        }

        public void Stop()
        {
            isActive = false;
        }
        private void Update()
        {
            if (isActive)
            {
                MoveBackground();
            }

        }

        private void MoveBackground()
        {
            var offset = material.mainTextureOffset;
            offset.y += speed * Time.deltaTime;
            material.mainTextureOffset = offset;
        }
    }
}