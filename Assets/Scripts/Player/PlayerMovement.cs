using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private string _verticalMovementName = "vertical";
    [SerializeField] private string _horizontalMovementName = "horizontal";
    [SerializeField] private string _horizontalRotationName = "MouseX";

    [SerializeField] private float _movementSpeed = 10f;
    [SerializeField] private float _rotateSpeed = 100f;

    private float _verticalMovementValue = 0f;
    private float _horizontalMovementValue = 0f;

    private float _horizontalRotationValue = 0f;

    private void Update()
    {
        SetVerticalMovementValue(Input.GetAxis(_verticalMovementName));
        SetHorizontalMovementValue(Input.GetAxis(_horizontalMovementName));
        
        // SetVerticalRotationValue(Input.GetAxis(verticalRotationName));
        SetHorizontalRotationValue(Input.GetAxis(_horizontalRotationName));
        
        Move();
        Rotate();
    }

    void Move()
    {
        Vector3 direction = transform.forward * _verticalMovementValue + transform.right * _horizontalMovementValue;
        
        transform.position += direction * _movementSpeed * Time.deltaTime;
    }

    void Rotate()
    {
        transform.eulerAngles += transform.up * _horizontalRotationValue * _rotateSpeed * Time.deltaTime;
    }

    void SetVerticalMovementValue(float _value) => _verticalMovementValue = _value;
    void SetHorizontalMovementValue(float _value) => _horizontalMovementValue = _value;

    // void SetVerticalRotationValue(float _value) => verticalRotationValue = _value;
    void SetHorizontalRotationValue(float _value) => _horizontalRotationValue = _value;
}
