using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingfire : MonoBehaviour
{

    
    public float DeadDestroyTime = 0.3f;

   
    public GameObject Fire;

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
           
            //  gameObject.GetComponent<EnemyScriptE1>().enabled = false;
            foreach (Transform child in transform)
            {
                GameObject.Destroy(child.gameObject);
                InvokeRepeating("killcorrector", 0, 3f);
            }

           
            Destroy(gameObject, DeadDestroyTime);

        }

    }
}
