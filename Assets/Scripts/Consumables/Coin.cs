using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Coin : MonoBehaviour, IConsumable
    {
        public int value = 1;
        public static event Action<int> OnCoinCollected;

        public void Consume(GameObject consumer)
        {
            OnCoinCollected?.Invoke(value);
        }

    }
}