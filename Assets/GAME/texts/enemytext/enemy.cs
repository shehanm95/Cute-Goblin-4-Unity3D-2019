using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    private SM SM;
    private Animator anim;
    public float DeadDestroyTime = 0.3f;

    private playerContraller player;

    void Start()
    {
        SM = FindObjectOfType<SM>();
        player = FindObjectOfType<playerContraller>();
        anim = GetComponent<Animator>();

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
