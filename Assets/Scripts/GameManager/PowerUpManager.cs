using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    private readonly Dictionary<PowerUpEffect, Coroutine> activeEffects = new();
    public float duration = 12f;
    public float Multiplier = 1.2f;

    private void OnEnable() => PowerUp.OnPowerUpCollected += PowerUpConsumed;
    private void OnDisable() => PowerUp.OnPowerUpCollected -= PowerUpConsumed;

    private void PowerUpConsumed(PowerUpEffect effect, GameObject consumer)
    {
        var playerStats = consumer.GetComponent<PlayerStats>();
        if (playerStats == null) return;

        if (activeEffects.TryGetValue(effect, out var running))
        {
            StopCoroutine(running);
        }

        activeEffects[effect] = StartCoroutine(ApplyPowerUp(effect, playerStats, 12f));
    }

    private IEnumerator ApplyPowerUp(PowerUpEffect effect, PlayerStats playerStats, float duration)
    {
        switch (effect)
        {
            case PowerUpEffect.Speed:
                playerStats.ModifyMoveSpeed(playerStats.baseMoveSpeed * Multiplier);
                break;
            case PowerUpEffect.Jump:
                playerStats.ModifyJumpForce(playerStats.baseJumpForce * Multiplier);
                break;
            case PowerUpEffect.Size:
                playerStats.ModifySize(playerStats.size * 1.5f);
                break;
        }
        
        yield return new WaitForSeconds(duration);

        switch (effect)
        {
            case PowerUpEffect.Speed:
                playerStats.ResetMoveSpeed();
                break;
            case PowerUpEffect.Jump:
                playerStats.ResetJumpForce();
                break;
            case PowerUpEffect.Size:
                playerStats.ResetSize();
                break;
        }
        activeEffects.Remove(effect);
    }
}
