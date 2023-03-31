using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBehaviour : MonoBehaviour
{
    private Rigidbody _rb;
    private Vector2 _moveDirection;

    public float Acceleration;
    public float MaxSpeed;
    public float JumpPower;
    public GroundColliderBehaviour GroundCollider;
    public float AirAccelerationReduction = 2;

    // Start is called before the first frame update

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void SetMoveDirection(Vector3 direction)
    {
        _moveDirection = direction;
    }

    public void MoveLeft(Vector3 left)
    {
        _rb.AddForce(Vector3.left * MaxSpeed, ForceMode.Force);
    }

    public void Jump()
    {
        if (GroundCollider.IsGrounded)
            _rb.AddForce(Vector3.up * JumpPower, ForceMode.Impulse);
    }

    // Update is called once per frame

    void Update()
    {
        float acceleration = Acceleration;

        if (!GroundCollider.IsGrounded)
            acceleration /= AirAccelerationReduction;

        _rb.AddForce(_moveDirection * acceleration * Time.deltaTime, ForceMode.VelocityChange);

        if (_rb.velocity.magnitude > MaxSpeed)
        {
            _rb.velocity = _rb.velocity.normalized * MaxSpeed;
        }
    }
}

