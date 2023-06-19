using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Player _player;
    [SerializeField] private float _healthChangeSpeed;

    private Coroutine _currentCoroutine;

    private float _nextSliderValue;

    private void OnEnable()
    {
        _player.HealthChanged += OnValueChanged;
        _slider.value = 1;
        _nextSliderValue = _slider.value;
        _currentCoroutine = null;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnValueChanged;
    }

    private void OnValueChanged(int value, int maxValue)
    {
        _nextSliderValue = Mathf.Clamp((float)value / maxValue, 0f, 1f);

        if(_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
        }

        _currentCoroutine = StartCoroutine(ChangeSliderValue(_nextSliderValue));
    }

    private IEnumerator ChangeSliderValue(float nextSliderValue)
    {
        while(_slider.value != nextSliderValue)
        {
            _slider.value = Mathf.Clamp(Mathf.MoveTowards(_slider.value, _nextSliderValue, _healthChangeSpeed * Time.deltaTime), 0f, 1f);
            yield return null;
        }

        _currentCoroutine = null;
    }
}
