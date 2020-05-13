using UnityEngine;

public class MouseLook : MonoBehaviour
{
    private const string MouseAxesNameX = "Mouse X";
    private const string MouseAxesNameY = "Mouse Y";
    private const float RotationClampValue = 90f;


    [SerializeField] private float _mouseSensitivity = 100f;
    [SerializeField] private Transform _playerBody = null;
    [SerializeField] private Transform _mainCamera = null;
    private float xRotation = 0f;


    private void Update()
    {
        ProcessMouseLook();
    }

    private void ProcessMouseLook()
    {
        float mouseX = Input.GetAxis(MouseAxesNameX) * _mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis(MouseAxesNameY) * _mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -RotationClampValue, RotationClampValue);

        _mainCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        _playerBody.Rotate(Vector3.up * mouseX);
    }
}
