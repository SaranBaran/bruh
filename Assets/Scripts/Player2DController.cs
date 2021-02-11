using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2DController : MonoBehaviour
{
    public float speed = 10f;
    public float jumpPower = 15f;
    public int extraJump = 1;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Transform feet;
    int jumpCount = 0;
    bool isGrounded;
    float mx;
    float jumpCoolDown;
    bool facingRight = false;
    public float dashDistnace = 15f;
    bool isDashing;
    float doubleTapTime;
    KeyCode lastKeyCode;
    public CameraShake cameraShake;
    public Ghost ghost;
    public ParticleSystem dashEffect;
    public ParticleSystem dust;
    public GameObject bulletTimeEffect;


    void Start()
    {
        bulletTimeEffect.SetActive(false);
    }


    private void Update()
    {
        mx = Input.GetAxis("Horizontal");
        float move = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
            ghost.makeGhost = true;
        }
        //Dash Left
        if (Input.GetKeyDown(KeyCode.A))
        {


            ghost.makeGhost = true;
            if (doubleTapTime > Time.time && lastKeyCode == KeyCode.A)
            {
                StartCoroutine(Dash(-1f));
                DashEffect();
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

            ghost.makeGhost = true;

            if (doubleTapTime > Time.time && lastKeyCode == KeyCode.D)
            {
                StartCoroutine(Dash(1f));
                DashEffect();
            }
            else
            {
                doubleTapTime = Time.time + 0.5f;
            }
            lastKeyCode = KeyCode.D;
        }

        if (move<0 && facingRight)  //if you press left, you will face left
        {
            flip();
        }
        else if (move>0 && !facingRight) //if you press right,you will face right
        {
            flip();
        }

        CheckGrounded();
        SlowMo();
    }

    private void FixedUpdate()
    {
        if (!isDashing)
            rb.velocity = new Vector2(mx * speed, rb.velocity.y);
    }

    void Jump()
    {
        if (isGrounded || jumpCount < extraJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            jumpCount++;
            CreateDust();
        }

    }

    public void CheckGrounded()
    {
        if (Physics2D.OverlapCircle(feet.position, 0.5f, groundLayer))
        {
            isGrounded = true;
            jumpCount = 0;
            jumpCoolDown = Time.time + 0.2f;
        }
        else if (Time.time < jumpCoolDown)
        {
            isGrounded = true;
            jumpCount = 0;
        }
        else
        {
            isGrounded = false;
        }
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

    void flip(){
        facingRight = !facingRight; //if its false it will be ture and if its true it will be false
        transform.Rotate(0f, 180f, 0f);
    }

    public void DashEffect()
    {
        dashEffect.Play();
        StartCoroutine(cameraShake.Shake(0.15f, 0.4f));
    }

    void CreateDust()
    {
        dust.Play();
    }


    IEnumerator Dash (float direction)  //Dashing Settings
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
}
