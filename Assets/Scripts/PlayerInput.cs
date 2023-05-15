using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerInput : MonoBehaviour
{
    private InputActions inputActions;

    public event EventHandler OnInteraction;
    private void Awake()
    {
        inputActions = new InputActions();
        inputActions.Player.Enable();
        inputActions.Player.Interact.performed += Interact_performed;
        // suscribe with Lamba inputActions.Player.Interact.performed += (UnityEngine.InputSystem.InputAction.CallbackContext ob) => OnInteraction?.Invoke(this, EventArgs.Empty);
        
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
       OnInteraction?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetPlayerInputNormalize() {
        Vector2 inputVector = inputActions.Player.Movements.ReadValue<Vector2>();

        inputVector = inputVector.normalized;

        return inputVector;
    }
}
