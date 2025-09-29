using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class CoinManager : MonoBehaviour
    {
        public int coins;
        public int coinsToWin = 50;
        public static event Action<int> OnCoinsChanged;
        public static event Action OnGameWon;

        private void OnEnable() => Coin.OnCoinCollected += AddCoins;
        private void OnDisable() => Coin.OnCoinCollected -= AddCoins;

        private void AddCoins(int value)
        {
            coins += value;
            OnCoinsChanged?.Invoke(coins);
            if (coins >= coinsToWin)
            {
                Debug.Log("You win!");
                OnGameWon?.Invoke();
            }
        }
    }
}