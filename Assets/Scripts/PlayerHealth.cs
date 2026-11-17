using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private float _maxHealth = 100f;
    private PlayerAnimator _playerAnimator;

    private float _currentHealth;
    public bool IsDead => _currentHealth <= 0;
    public float HealthPercent => _currentHealth / _maxHealth;
    private void Awake()
    {
        _currentHealth = _maxHealth;
        _playerAnimator = GetComponent<PlayerAnimator>();
    }

    public void TakeDamage(float amount)
    {
        if (IsDead == true) return;

        if (amount < 0) amount = 0;

        _currentHealth = Mathf.Max(0, _currentHealth - amount);

        if (IsDead == false) _playerAnimator.PlayHit();
    }
}
