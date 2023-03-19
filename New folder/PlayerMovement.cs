using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector3 currentVelocity;
    public bool groundedPlayer;
    public float playerSpeed = 2.0f;
    public float drag = 1.0f;
    public float jumpHeight = 1.0f;
    public float stopCoeff = 2.0f;
    public SpriteRenderer sprite;
    public bool facingRight;

    public float gravity = 10f;

    private void Start()
    {
        groundedPlayer = false;
    }

    void Update()
    {
        ApplyDrag();
        ApplyGravity();
    }

    public void MovePlayer()
    {
        Vector3 movementForce = playerSpeed * new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;

        GetComponent<Rigidbody>().AddForce(movementForce);

        FlipSprite(currentVelocity);

    }

    public void ApplyDrag()
    {
        Vector3 movementForce = playerSpeed * new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        bool isMoving = movementForce.magnitude >= playerSpeed * float.Epsilon;

        currentVelocity = GetComponent<Rigidbody>().velocity;
        currentVelocity.y = 0;
        Vector3 dragForce = drag * Mathf.Sqrt(currentVelocity.magnitude) * currentVelocity.normalized;

        if (!isMoving)
        {
            dragForce *= stopCoeff;
        }

        if (!isMoving && currentVelocity.magnitude <= 1)
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
        else
        {
            GetComponent<Rigidbody>().AddForce(-dragForce);
        }
    }

    public void ApplyGravity()
    {
        if (!groundedPlayer)
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, -gravity, 0));
        }
    }


    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Floor")
        {
            groundedPlayer = true;
        }
    }

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Floor")
        {
            groundedPlayer = false;
        }
    }

    void FlipSprite(Vector3 currentVelocity)
    {
        sprite.flipX = currentVelocity.x < 0;
        facingRight = currentVelocity.x >= 0;
    }

    public bool GetDirection()
    {
        return facingRight;
    }
}
