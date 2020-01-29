using System;
using UnityEngine;

namespace Reefaktor.Omega
{
    public class PlayerShipController : MonoBehaviour
    {
        private Vector3 initialPosition;
        
        private void Start()
        {
            initialPosition = transform.position;

        }

        private void LateUpdate()
        {
            var position = transform.position;
            position.y = position.y != initialPosition.y ? initialPosition.y : position.y;
            transform.position = position;
        }
    }
}