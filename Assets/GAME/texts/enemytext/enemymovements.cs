using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymovements : MonoBehaviour
{
    

    private Vector3 startPos;
    public Transform target;
    public float speed = 3f;
    private bool moveUp;

    bool faceright = true;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        moveUp = true;
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        if (transform.position == target.position)
        {
            moveUp = false;
            flip();
        }
        else if (transform.position == startPos)
        {
            moveUp = true;
            flip();
        }
        if (moveUp == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, step);
        }
        else if (moveUp)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
    }

    public void flip()
    {
        faceright = !faceright;

        Vector3 thescale = transform.localScale;

        thescale.x *= -1;

        transform.localScale = thescale;
    }
}
