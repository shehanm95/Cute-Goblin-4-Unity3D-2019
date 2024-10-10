using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M2AOneSidePlatform : MonoBehaviour
{
    bool sit = false;
    private Vector3 startPos;
    public Transform target;
    public float speed;
    private bool moveUp;
    void Start()
    {
        startPos = transform.position;
        moveUp = true;
    }
    void Update()
    { movingFunction(); }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.parent = transform;
        sit = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
        sit = false;
    }

    public void movingFunction()
    {
        if (sit)
        {
            float step = speed * Time.deltaTime;
            if (transform.position == target.position)
            {
                moveUp = false;
            }
            else if (transform.position == startPos)
            {
                moveUp = true;
            }
            if (moveUp == false)
            {
              //  transform.position = Vector3.MoveTowards(transform.position, startPos, step);  // can make with Larp
            }
            else if (moveUp)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, step);  // can make with Larp
            }
        }

    }
}
