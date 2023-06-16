using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthChanger : MonoBehaviour
{
    [SerializeField] private Button _healButton;
    [SerializeField] private Button _damageButton;
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private Player _player;
    [SerializeField] private int _healValue;
    [SerializeField] private int _damageValue;

    private void OnEnable()
    {
        _healButton.onClick.AddListener(OnHealButtonClick);
        _damageButton.onClick.AddListener(OnDamageButtonClick);
    }

    private void OnDisable()
    {
        _healButton.onClick.RemoveListener(OnHealButtonClick);
        _damageButton.onClick.RemoveListener(OnDamageButtonClick);
    }

    private void OnHealButtonClick()
    {
        _player.ApplyHeal(_healValue);
    }

    private void OnDamageButtonClick()
    {
        _player.ApplyDamage(_damageValue);
    }
}
