using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public event Action Clicked;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Clicked?.Invoke();
        }
    }
}
