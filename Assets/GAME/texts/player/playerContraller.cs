using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerContraller : MonoBehaviour
{
    Rigidbody2D rb;
    private SM SM;

    [Header("MAIN CONTRALS")]
    public float topSpeed = 10f;
    public float Jumpforce = 800f;
    bool grounded = false;
    float ground_radius = 0.4f;
    public Transform GroundChecker;
    public LayerMask whatIsground;
    bool doublejump = false;
    bool faceright;

    [Header("ABOUT BULLET")]
    public GameObject bullet;
    public Transform mussel;
    public float fireRate = 0.3F;
    private float nextFire = 0.0F;
    public float FireDelay = 0.1f;


    bool attackbool = false;
    bool jumpbool = false;

    [Header("fire animation")]
    Animator anim;
    public float FireAnimateTime = 0.1f;

    [Header("KILL & COIN COUNT")]
    public float CoinAmount;
    public float KillAmount;
    public Text CoinCounter;
    public Text KillCounter;


    [Header("WIN")]
    public GameObject WinPanal;
    public GameObject WinPanalObject;


    [Header("DISTANCE")]
    public Transform CheckPoint;
    public Text DistanceText;
    private float distance;

    private InterstitialAdsScript ad;
    private levelcontraller lv;


    // Start is called before the first frame update
    void Start()
    {
        SM = FindObjectOfType<SM>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
      ad = FindObjectOfType<InterstitialAdsScript>();
        lv = FindObjectOfType<levelcontraller>();
        WinPanal.SetActive(false);
        WinPanalObject.SetActive(false);

    }

    private void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(GroundChecker.position, ground_radius, whatIsground);

        if (grounded)
        {

            anim.SetBool("isJump", false);
            doublejump = false;
            jumpbool = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

        KillandCoinCounterFunction();



        contrals();
        distancefunction();
        // bellow functions for key board contralls,
        //  fire();
        // jump();
    }



    public void contrals()
    {
       // float move = Input.GetAxis("Horizontal");
       float move = CrossPlatformInputManager.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(topSpeed * move, rb.velocity.y);

        if (!grounded || doublejump)
        {
            float zero = 0f;
            anim.SetFloat("isWalking", Mathf.Abs(zero));
        }

        if (grounded && !attackbool && !jumpbool)
        {
            anim.SetFloat("isWalking", Mathf.Abs(move));
        }




        if (move > 0 && faceright)

            flip();

        else if (move < 0 && !faceright)

            flip();
    }

    public void flip()
    {
        faceright = !faceright;

        Vector3 thescale = transform.localScale;

        thescale.x *= -1;

        transform.localScale = thescale;
    }

    public void jump()
    {
        //jump
      //if ((grounded || !doublejump) && Input.GetKeyDown(KeyCode.Space))  // only for keybord contrall.
        if (grounded || !doublejump)
        { //not on the ground
            SM.jumpsound();
            anim.SetBool("isJump", true);
            jumpbool = true;

            // add jump fprce to the y axis of the rigidbody.
            rb.AddForce(new Vector2(rb.velocity.x, Jumpforce));

            if (!doublejump && !grounded)
            {
                doublejump = true;
            }


        }

    }

    public void fire()
    {
     //  if (Input.GetKeyDown(KeyCode.B) && Time.time > nextFire)     // only for keybord contrall.
       if (Time.time > nextFire)
        {
            SM.firesound();
            attackbool = true;
            anim.SetBool("isAttack", true);
            nextFire = Time.time + fireRate;
            Invoke("delayfire", FireDelay);
            Invoke("stopfire", FireAnimateTime);
            //  CoinAmount += 1;
        }
    }

    public void stopfire()
    {
        anim.SetBool("isAttack", false);
        attackbool = false;
    }

    public void delayfire()
    {
        Instantiate(bullet, mussel.position, Quaternion.identity);
    }


    private void distancefunction()
    {
        distance = CheckPoint.transform.position.x - transform.position.x;
        DistanceText.text = "distance " + distance.ToString("f1") + " M";
    }

    // KILL & COIN COUNTER

    public void KillandCoinCounterFunction()
    {
        CoinCounter.text = CoinAmount.ToString("0");
        KillCounter.text = KillAmount.ToString("0");
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "smallad")
        {
            ad.vedioAD();
        }

        if (collision.gameObject.tag == "win")
        {
            WinPanal.SetActive(true);
            WinPanalObject.SetActive(true);
        }
            if (collision.gameObject.tag == "level1")
        {
            lv.tempnum = 1;
           
            
        }
        if (collision.gameObject.tag == "level3")
        {
           lv.tempnum = 2;
           
           
        }
        if (collision.gameObject.tag == "level4")
        {
            lv.tempnum = 3;
            
          
        }

        if (collision.gameObject.tag == "level5")
        {
           lv.tempnum = 4;
            
           
        }
        if (collision.gameObject.tag == "level6")
        {
           lv.tempnum = 5;
            
            
        }

        if (collision.gameObject.tag == "level7")
        {
            lv.tempnum = 6;
           
            
        }

        if (collision.gameObject.tag == "level8")
        {
            lv.tempnum = 7;
           
           
        }

        if (collision.gameObject.tag == "level9")
        {
           lv.tempnum = 8;
            
            
        }

        if (collision.gameObject.tag == "coin")
        {
            CoinAmount = CoinAmount + 1f;
        }
    }


}

