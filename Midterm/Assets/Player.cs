using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Implementation of player movement was from previous tutorials in class (3D Tutorial)
    [SerializeField] float _mouseSensitivity = 10f;
    [SerializeField] float _moveSpeed = 3f;
    [SerializeField] Camera _cam;
    float _currentTilt = 0f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Aim();
        Movement();
    }

    void Aim()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        transform.Rotate(Vector3.up, mouseX * _mouseSensitivity);

        _currentTilt -= mouseY * _mouseSensitivity;
        _currentTilt = Mathf.Clamp(_currentTilt, -90, 90);
        _cam.transform.localEulerAngles = new Vector3(_currentTilt, 0, 0);
    }

    void Movement()
    {
        Vector3 sidewaysMovementVector = transform.right * Input.GetAxis("Horizontal");
        Vector3 forwardBackwardMovementVector = transform.forward * Input.GetAxis("Vertical");
        Vector3 movementVector = sidewaysMovementVector + forwardBackwardMovementVector;

        GetComponent<CharacterController>().Move(movementVector * _moveSpeed * Time.deltaTime);
    }
}
