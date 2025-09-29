using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class PowerUp : MonoBehaviour, IConsumable
    {
        public PowerUpEffect effect;
        public static event Action<PowerUpEffect, GameObject> OnPowerUpCollected; 

        public void Consume(GameObject consumer)
        {
            OnPowerUpCollected?.Invoke(effect, consumer);
        }
    }
}