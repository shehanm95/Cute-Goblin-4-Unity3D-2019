using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float bulletSpeed = 20;
    public float bulletSpeed2 = -20;
    public float destroyTime = 0.4f;
    Rigidbody2D rb;

    playerContraller player;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<playerContraller>();
        if (player.transform.localScale.x < 0)
        {
            bulletSpeed = -bulletSpeed;
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(bulletSpeed, rb.velocity.y);
        Destroy(gameObject, destroyTime);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        {
            if (collision.gameObject.tag == "bulletdistroyer")
            {
                Destroy(gameObject, 0.01f);
            }
        }
    }
}
