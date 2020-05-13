using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const string HorizontalAxesName = "Horizontal";
    private const string VerticalAxesName = "Vertical";
    private const string JumpAxesName = "Jump";
    private const float RotationClampValue = 90f;


    [SerializeField] private CharacterController _controller = null;
    [SerializeField] private Transform _groundCheck = null;
    [SerializeField] private float _groundDistance = .4f;
    [SerializeField] private LayerMask _groundMask = ~0;
    [SerializeField] private float _speed = 12f;
    [SerializeField] private float _gravity = -9.81f;
    [SerializeField] private float _jumpHeight = 3f;
    private Vector3 _velocity;
    bool isGrounded;


    private void Update()
    {
        ProcessMovementAndInput();
    }

    private void ProcessMovementAndInput()
    {
        isGrounded = Physics.CheckSphere(_groundCheck.position, _groundDistance, _groundMask);

        if (isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2f; //force a player closer to the ground
        }

        float x = Input.GetAxis(HorizontalAxesName);
        float z = Input.GetAxis(VerticalAxesName);

        Vector3 move = transform.right * x + transform.forward * z;

        _controller.Move(move * _speed * Time.deltaTime);

        if (Input.GetButtonDown(JumpAxesName) && isGrounded)
        {
            _velocity.y = Mathf.Sqrt(_jumpHeight * -2f * _gravity); //physics equation to jump a certain height
        }

        _velocity.y += _gravity * Time.deltaTime;

        _controller.Move(_velocity * Time.deltaTime);
    }
}
