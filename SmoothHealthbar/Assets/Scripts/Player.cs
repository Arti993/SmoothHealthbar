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
        if (_currentHealth >= damage)
            _currentHealth -= damage;
        else
            _currentHealth = 0;

        HealthChanged?.Invoke(_currentHealth, _health);
    }

    public void ApplyHeal(int heal)
    {
        if (_currentHealth + heal <= _health)
            _currentHealth += heal;
        else
            _currentHealth = _health;

        HealthChanged?.Invoke(_currentHealth, _health);
    }
}
