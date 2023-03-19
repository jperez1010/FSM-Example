using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public Vector3 playerSpeed;
    public Animator animator;
    public float epsilon = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerSpeed = GetComponent<Rigidbody>().velocity;
        playerSpeed.y = 0;

        Update_Direction();
        Update_Walking();
    }

    void Update_Direction()
    {
        if (playerSpeed.magnitude > epsilon) 
        {
            animator.SetBool("Facing Left", playerSpeed.x < 0);
        }

    }

    void Update_Walking()
    {
        animator.SetFloat("Speed", playerSpeed.magnitude);
    }

    public void Trigger_Punch()
    {
        animator.SetTrigger("Punch");
    }

    public void SetCombo(int i)
    {
        animator.SetInteger("Combo", i);
    }

}
