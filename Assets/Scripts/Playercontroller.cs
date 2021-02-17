using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    public static Playercontroller player;
    Rigidbody2D rb;
    float speed = 20f;
    float mx;
    public Transform[] raypoints;
    public bool grounded;
    public float movespeed, jumpamount;
    public Collider2D playercollider;
    public int supressGroundedTicks = 0;
    int coyote = 5;
    float doubleTapTime;
    bool isDashing;
    KeyCode lastKeyCode;
    public CameraShake cameraShake;
    public float dashDistnace = 15f;
    public Ghost ghost;
    public ParticleSystem dashEffect;
    public ParticleSystem dust;
    public GameObject bulletTimeEffect;
    public AudioSource jumpSound;
    public AudioSource dashSound;
    public int target = 30;


    // Start is called before the first frame update
    void Start()
    {
        player = this;
        rb = GetComponent<Rigidbody2D>();
        bulletTimeEffect.SetActive(false);
        QualitySettings.vSyncCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != Application.targetFrameRate)
        {
            Application.targetFrameRate = target;
        }

        SlowMo();

        //Dash Left
        if (Input.GetKeyDown(KeyCode.A))
        {

            if (doubleTapTime > Time.time && lastKeyCode == KeyCode.A)
            {
                StartCoroutine(Dash(-1f));
                DashEffect();
                dashSound.Play();
            }
            else
            {
                doubleTapTime = Time.time + 0.5f;
            }

            lastKeyCode = KeyCode.A;
        }

        //Dash right
        if (Input.GetKeyDown(KeyCode.D))
        {

            if (doubleTapTime > Time.time && lastKeyCode == KeyCode.D)
            {
                StartCoroutine(Dash(1f));
                DashEffect();
                dashSound.Play();
            }
            else
            {
                doubleTapTime = Time.time + 0.5f;
            }
            lastKeyCode = KeyCode.D;
        }

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb.AddForce(Vector2.up * jumpamount, ForceMode2D.Impulse);
            jumpSound.Play();
           
        }
        if (Input.GetKeyUp(KeyCode.Space) && rb.velocity.y > 0)
        {
            rb.AddForce(new Vector2(0, -rb.velocity.y / 2), ForceMode2D.Impulse);

        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            rb.gravityScale = 5;
        }
        if (Input.GetKey(KeyCode.Space) && rb.velocity.y > 0 && grounded)
        {
            rb.AddForce(new Vector2(0, rb.velocity.y / 10), ForceMode2D.Force);
        }
    }
    private void FixedUpdate()
    {
        if (!isDashing)
            rb.velocity = new Vector2(mx * speed, rb.velocity.y);

        GetGrounded();

        float _y = rb.velocity.y;
        if (grounded && Mathf.Abs(rb.velocity.x) < movespeed * 1.1f)
        {
            rb.velocity = Vector2.zero;
            if (Input.GetKey(KeyCode.D))
            {

                rb.velocity = Vector2.right * movespeed;

            }
            if (Input.GetKey(KeyCode.A))
            {


                rb.velocity = Vector2.left * movespeed;
            }

        }
        else
        {
            if (Input.GetKey(KeyCode.D) && rb.velocity.x < movespeed)
            {
                rb.velocity += Vector2.right * movespeed / 2;

            }
            if (Input.GetKey(KeyCode.A) && rb.velocity.x > -1 * movespeed)
            {
                rb.velocity += Vector2.left * movespeed / 2;
            }
            if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            {
                //rb.AddForce(new Vector2(rb.velocity.x, 0f)/3);
            }
        }
        rb.velocity = new Vector2(rb.velocity.x, _y);
    }
    void GetGrounded()
    {
        LayerMask layerMask;
        layerMask = LayerMask.GetMask("Ground");
        coyote--;
        foreach (Transform transforms in raypoints)
        {
            Debug.DrawRay(transforms.position, Vector2.down * 0.3f, Color.red, .03f);
            RaycastHit2D _raycasthit = Physics2D.Raycast(transforms.position, Vector2.down, .2f, layerMask: layerMask);
            if (_raycasthit.collider != playercollider && _raycasthit.collider != null)
            {
                coyote = 5;
                break;
            }
        }
        if (coyote > 0)
        {
            grounded = true;
            rb.gravityScale = 3;
        }
        else
        {
            grounded = false;
        }
        if (supressGroundedTicks > 0)
        {
            supressGroundedTicks--;
            grounded = false;
        }
    }

    public void DashEffect()
    {
        dashEffect.Play();
        StartCoroutine(cameraShake.Shake(0.15f, 0.4f));
    }

    IEnumerator Dash(float direction)  //Dashing Settings
    {
        isDashing = true;
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(new Vector2(dashDistnace * direction, 0f), ForceMode2D.Impulse);
        float gravity = rb.gravityScale;
        rb.gravityScale = 0; //we are closing gravity for the Dash
        yield return new WaitForSeconds(0.4f);//time we stay on Dash (we need to increase this if the Dashing distance is long)
        isDashing = false;
        rb.gravityScale = gravity;//we are turning gravity back
    }

    void CreateDust()
    {
        dust.Play();
    }

    public void SlowMo()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Time.timeScale = 0.1f;
            bulletTimeEffect.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Time.timeScale = 1f;
            bulletTimeEffect.SetActive(false);
        }
    }
}

