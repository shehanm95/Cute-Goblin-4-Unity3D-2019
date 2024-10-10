using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannongunsc : MonoBehaviour
{
    public int life = 10;
    Animator anim;

    public Transform CannonMuzzel;
    public GameObject cannonBall;
    public float DelayTimer = 1f;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = DelayTimer;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        cannondestroyfunc();
        cannnonshootF();


    }


    public void cannondestroyfunc()
    {
        if(life <= 0)
        {
            Destroy(transform.parent.gameObject);
        }

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "bullet")
        {
            SM SM = FindObjectOfType<SM>();
            SM.balastEnemysound();
            anim.SetBool("hit", true);
            life -= 1;
            Invoke("stopanimation",0.4f);
        }
    }

    private void stopanimation()
    {
        anim.SetBool("hit", false);
    }
   
    private void cannnonshootF()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Instantiate(cannonBall, CannonMuzzel.position, Quaternion.identity);
            timer = DelayTimer;
        }
    }

}
