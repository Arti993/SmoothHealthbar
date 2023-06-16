using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;

    private int _currentHealth;

    public event UnityAction<int, int> HealthChanged;

    private void Start()
    {
        _currentHealth = _health;
    }

    public void ApplyDamage(int damage)
    {
        if (_currentHealth > 0)
        {
            _currentHealth -= damage;

            HealthChanged?.Invoke(_currentHealth, _health);
        }
    }

    public void ApplyHeal(int heal)
    {
        if (_currentHealth < _health)
        {
            _currentHealth += heal;

            HealthChanged?.Invoke(_currentHealth, _health);
        }
    }
}
