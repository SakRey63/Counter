using TMPro;
using UnityEngine;

public class DisplayCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Counter _counter;
    
    private string _textInstruction = "Нажмите левую клавишу мышы для включения счетчика.";

    private void OnEnable()
    {
        _counter.CountChanged += ChangeNumber;
    }

    private void OnDisable()
    {
        _counter.CountChanged -= ChangeNumber;
    }

    private void Start()
    {
        _text.text = _textInstruction;
    }
    
    private void ChangeNumber()
    {
        _text.text = _counter.NumberOnDisplay.ToString();
    }
}
