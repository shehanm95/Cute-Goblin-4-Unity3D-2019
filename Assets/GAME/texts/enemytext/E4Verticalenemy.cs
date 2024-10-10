using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E4Verticalenemy : MonoBehaviour
{
    private SM SM;
    private Animator anim;
    public float DeadDestroyTime = 0.3f;

    private playerContraller player;
    public GameObject verticalEnemy;

    private Vector3 startPos;
    public Transform target;
    public float speed;
    private bool moveUp;
    void Start()
    {
        SM = FindObjectOfType<SM>();
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
        }
        else if (transform.position == startPos)
        {
            moveUp = true;
        }
        if (moveUp == false)
        {
          
            transform.position = Vector3.Lerp(transform.position, startPos, step);  // can make with Larp
        }
        else if (moveUp)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, step);  // can make with Larp
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "bullet")
        {
            SM.balastEnemysound();
            //  gameObject.GetComponent<EnemyScriptE1>().enabled = false;
            foreach (Transform child in transform)
            {
                GameObject.Destroy(child.gameObject);
                InvokeRepeating("killcorrector", 0, 3f);
            }

            anim.SetBool("dead", true);
            Destroy(transform.parent.gameObject, DeadDestroyTime);

        }

    }

    public void killcorrector()
    {
        player.KillAmount += 1;

    }


}
