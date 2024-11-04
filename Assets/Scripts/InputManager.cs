using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private InputActionReference MovementAction = null;
    [SerializeField]
    private InputActionReference JumpAction = null;
    [SerializeField]
    private InputActionReference ClickAction = null;

    private static InputManager _instance = null;
    public static InputManager Instance { get { return _instance; } }

  

    public Vector3 movementInput { get; private set; }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }

    void Update()
    {
        Vector2 MoveInput = MovementAction.action.ReadValue<Vector2>();
        movementInput = new Vector3(MoveInput.x, 0, MoveInput.y);
    }

    public void registerJumpInput(Action<InputAction.CallbackContext> OnJumpAction)
    {
        JumpAction.action.performed += OnJumpAction;
    }

    public void unregisterJumpInput(Action<InputAction.CallbackContext> OnJumpAction)
    {
        JumpAction.action.performed -= OnJumpAction;
    }
    public void registerOnClick(Action<InputAction.CallbackContext> OnClickAction)
    {
        ClickAction.action.performed += OnClickAction;
    }

    public void unregisterOnClick(Action<InputAction.CallbackContext> OnClickAction)
    {
        ClickAction.action.performed -= OnClickAction;
    }



}