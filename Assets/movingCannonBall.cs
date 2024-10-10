using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingCannonBall : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(speed*Time.deltaTime, rb.velocity.y);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "destryer")
        {
            Destroy(gameObject);
        }
    }
}
