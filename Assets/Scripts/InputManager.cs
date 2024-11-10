using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public event Action GetClicked;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GetClicked?.Invoke();
        }
    }
}
