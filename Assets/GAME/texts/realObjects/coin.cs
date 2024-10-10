using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    SM SM;
    playerContraller player;
    // Start is called before the first frame update
    void Start()
    {
        SM = FindObjectOfType<SM>();
        player = FindObjectOfType<playerContraller>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            SM.coinsound();
            Destroy(gameObject);
            player.CoinAmount += 1;
        }
    }
}
