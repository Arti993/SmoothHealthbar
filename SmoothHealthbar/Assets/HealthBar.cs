using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Player _player;
    [SerializeField] float _healthChangeSpeed;

    private float _nextSliderValue;

    private void OnEnable()
    {
        _player.HealthChanged += OnValueChanged;
        _slider.value = 1;
        _nextSliderValue = _slider.value;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnValueChanged;
    }

    private void Update()
    {
        _slider.value = Mathf.MoveTowards(_slider.value, _nextSliderValue, _healthChangeSpeed * Time.deltaTime);
    }

    private void OnValueChanged(int value, int maxValue)
    {
        _nextSliderValue = (float)value / maxValue;
    }
}
