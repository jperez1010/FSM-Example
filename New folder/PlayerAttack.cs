using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float punchDistance = 1f;
    public int punchCount = 100;
    public int punch2Count = 100;
    public int toAdd = 0;
    int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (counter >= 0)
        {
            counter -= 1;
            if (counter == 0)
            {
                SpawnPunch();
                counter += toAdd;
                toAdd = 0;
            }
        }
    }

    public void Punch()
    {
        GetComponent<PlayerAnimator>().Trigger_Punch();
        counter = punchCount;
    }

    public void Punch2()
    {
        GetComponent<PlayerAnimator>().SetCombo(2);
        toAdd = punch2Count;
    }

    void SpawnPunch()
    {
        float direction = 1f;
        bool facingRight = GetComponent<PlayerMovement>().GetDirection();
        if (!facingRight)
        {
            direction *= -1;
        }

        RaycastHit hit;
        bool punchDetect = Physics.Raycast(transform.position, direction * transform.TransformDirection(Vector3.right), out hit, punchDistance);


        if (punchDetect)
        {
            hit.collider.gameObject.GetComponent<Rigidbody>().AddForce(300f * direction * transform.TransformDirection(Vector3.right));
        }
    }
}
