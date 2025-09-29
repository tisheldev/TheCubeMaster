using DefaultNamespace;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private VictoryScreen victoryScreen;
    public Speedometer speedometer;

    private void OnEnable()
    {
        CoinManager.OnGameWon += HandleGameWon;
    }

    private void OnDisable()
    {
        CoinManager.OnGameWon -= HandleGameWon;
    }

    private void HandleGameWon()
    {
        victoryScreen.Show();
        speedometer.Hide();
    }
    
}
