using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerControll : MonoBehaviour
{
    [SerializeField] private float PlayerSpeed = 2.0f;

    private CharacterController _characterController => GetComponent<CharacterController>();
    private NewControls _inputActions;
    private bool _isPressed = false;
    private Vector3 _playerVelocity;

    private void Update()
    {
        if (_isPressed)
            _characterController.Move(_playerVelocity * Time.deltaTime * PlayerSpeed);
    }

    private void Move(InputAction.CallbackContext callback)
    {
        Vector2 input = callback.ReadValue<Vector2>();
        _playerVelocity.x = input.x;
        _playerVelocity.z = input.y;
        _isPressed = input.x != 0 || input.y != 0;
    }

    private void OnEnable()
    {
        _inputActions = new NewControls();
        _inputActions.Enable();
        _inputActions.Player.Movement.performed += Move;
        _inputActions.Player.Movement.canceled += Move;
    }

    private void OnDisable()
    {
        _inputActions.Player.Movement.performed -= Move;
        _inputActions.Player.Movement.canceled -= Move;
        _inputActions.Disable();
    }
}
