using DefaultNamespace;
using TMPro;
using UnityEngine;

namespace GlobalNamespace
{
    public class ScoreUI : MonoBehaviour
    {
        public TextMeshProUGUI scoreText;

        void Start()
        {
            UpdateScore(0);
        }

        private void OnEnable()
        {
            CoinManager.OnCoinsChanged += UpdateScore;
            CoinManager.OnGameWon += OnGameWon;
        }

        private void OnDisable()
        {
            CoinManager.OnCoinsChanged -= UpdateScore;
            CoinManager.OnGameWon -= OnGameWon;
        }

        private void OnGameWon()
        {
            gameObject.SetActive(false);
        }

        private void UpdateScore(int score)
        {
            scoreText.text = score.ToString();
        }
    }
}