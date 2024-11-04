using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnCubeOnClick : MonoBehaviour
{
    [SerializeField]
    private GameObject objectToSpawn = null;

    void Start()
    {
        InputManager.Instance.registerOnClick(OnClick);
    }

    void OnDestroy()
    {
        InputManager.Instance.unregisterOnClick(OnClick);
    }

    public void OnClick(InputAction.CallbackContext callBackContext)
    {
        Vector3 spawnPosition = GetMouseWorldPosition();
        if(objectToSpawn != null)
            GameObject.Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePosition = Mouse.current.position.ReadValue();
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            return hit.point; 
        }

        return ray.GetPoint(10);
    }
}
