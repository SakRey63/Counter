using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private InputManager _inputManager;

    private float _delay = 0.5f;
    private int _start = 0;
    private int _numberСounter = 1;
    private bool _isOpen;

    public int NumberOnDisplay => _start;

    public event Action CountChanged;

    private void OnEnable()
    {
        _inputManager.GetClicked += CounterManager;
    }

    private void OnDisable()
    {
        _inputManager.GetClicked -= CounterManager;
    }
    
    private IEnumerator CounterActivation()
    {
        var wait = new WaitForSecondsRealtime(_delay);

        while (_isOpen)
        {
            _start += _numberСounter;

            CountChanged?.Invoke();
            
            yield return wait; 
        }
    }

    private void CounterManager()
    {
        if (_isOpen == false)
        {
            _isOpen = true;
            
            StartCoroutine(CounterActivation());
        }
        else
        {
            _isOpen = false;
            
            StopCoroutine(CounterActivation());
        }
    }
}
