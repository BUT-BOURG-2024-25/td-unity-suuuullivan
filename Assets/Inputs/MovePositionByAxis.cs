using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovePositionByAxis : MonoBehaviour
{
    float horizontalSpeed = 2.0f;
    float verticalSpeed = 2.0f;
    public float speed = 5f;
    [SerializeField]
    private float jumpPower = 200.0f;
    [SerializeField]
    private Rigidbody physicsBody;

    // Start is called before the first frame update
    void Start()
    {
        InputManager.Instance.registerJumpInput(jump);
    }

    void OnDestroy()
    {
        InputManager.Instance.unregisterJumpInput(jump);
    }

    // Update is called once per frame
    void Update()
    {
        float h = horizontalSpeed * Input.GetAxis("Mouse X");
        float v = verticalSpeed * Input.GetAxis("Mouse Y");
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput) * speed * Time.deltaTime;
        physicsBody.velocity = InputManager.Instance.movementInput * speed;
        transform.Translate(movement);
        transform.Rotate(v, h, 0);

    }

    private void jump(InputAction.CallbackContext callbackContext)
    {
        physicsBody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
    }
}
