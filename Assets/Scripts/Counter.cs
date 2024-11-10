using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private InputManager _inputManager;

    private float _delay = 0.5f;
    private int _numberCounter = 0;
    private Coroutine _counterCoroutine;
    
    public event Action<int> CountChanged;

    private void OnEnable()
    {
        _inputManager.Clicked += OnClicked;
    }

    private void OnDisable()
    {
        _inputManager.Clicked -= OnClicked;
    }
    
    private IEnumerator CounterActivation()
    {
        var wait = new WaitForSecondsRealtime(_delay);

        while (true)
        {
            _numberCounter ++;

            CountChanged?.Invoke(_numberCounter);
            
            yield return wait; 
        }
    }

    private void OnClicked()
    {
        if (_counterCoroutine == null)
        {
           _counterCoroutine = StartCoroutine(CounterActivation());
        }
        else
        {
            StopCoroutine(_counterCoroutine);
            
            _counterCoroutine = null;
        }
    }
}
