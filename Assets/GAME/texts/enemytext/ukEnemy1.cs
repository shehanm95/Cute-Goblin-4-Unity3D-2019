using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ukEnemy1 : MonoBehaviour
{
    GameObject HorizontalEnemy;

    private Vector3 startPos;
    public Transform target;
    public float speed = 3f;
    private bool moveUp;

    bool faceright = true;


    private Animator anim;
    public float DeadDestroyTime = 0.3f;

    private playerContraller player;

    void Start()
    {
        player = FindObjectOfType<playerContraller>();
        anim = GetComponent<Animator>();
        startPos = transform.position;
        moveUp = true;
    }
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.tag == "bullet")
        {
            
            gameObject.GetComponent<ukEnemy1>().enabled = false;
            foreach (Transform child in transform)
            {
                GameObject.Destroy(child.gameObject);
                InvokeRepeating("killcorrector", 0, 3f);
            }

            anim.SetBool("dead", true);
            Destroy(gameObject, DeadDestroyTime);
           
        }
       
    }

    public void killcorrector()
    {
        player.KillAmount += 1;

    }
}

//==================this is the horizontal enemy====================

// 1 . enemy should be designed as faced right.
// 2 . fill the target and target should be left to the player
// 3 . csript should attached to the enemy

