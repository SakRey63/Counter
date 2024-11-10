using System.Collections;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private InputManager _inputManager;
    [SerializeField] private TextMeshProUGUI _text;

    private float _delay = 0.5f;
    private int _start = 0;
    private int _numberСounter = 1;
    private bool _isOpen;
    private string _textInstruction = "Нажмите левую клавишу мышы для включения счетчика.";

    private void OnEnable()
    {
        _inputManager.GetClicked += CounterManager;
    }

    private void OnDisable()
    {
        _inputManager.GetClicked -= CounterManager;
    }

    private void Start()
    {
        _text.text = _textInstruction;
    }
    
    private IEnumerator CounterActivation()
    {
        var wait = new WaitForSecondsRealtime(_delay);

        while (_isOpen)
        {
            _start += _numberСounter;
            
            DisplayCounter(_start);
            
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

    private void DisplayCounter(int counter)
    {
        _text.text = counter.ToString();
    }
}
