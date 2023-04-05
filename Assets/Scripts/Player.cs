using System.Collections;
using System.Collections.Generic;
using System.Text;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public Death death;


    [SerializeField] float moveSpeed = 10;
    [SerializeField] float jumpSpeed = 3;
    [SerializeField] private TrailRenderer tr;
    [SerializeField] public int points;

    public Animator animator;
    public Transform range;
    public float attackrange = 0.5f;
    public LayerMask enemyLayer;
    public int Degats = 50;
    
    private Rigidbody2D rb;
    private BoxCollider2D jumpControler;
    private float horizontal;
    private bool isJumping;
    private int jumpCount;
    private bool isFacingRight = true;



    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;
    private float originalScale;

    public int HPjoueur = 200;
    

    // Start is called before the first frame update



    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        jumpControler = GetComponent<BoxCollider2D>();

        isJumping = true;
    }




    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Plateform")
        {
            isJumping = false;
        }

        if (collision.gameObject.tag == "Mob")
        {
            HPjoueur -= 20;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Plateform")
        {
            isJumping = true;
        }


    }

    

    private void Update()
    {
        if (isDashing)
        {
            return;
        }

        if (HPjoueur <= 0) 
        
        {
            HPjoueur = 200;
            transform.position= Vector3.zero;
        }

        horizontal = Input.GetAxisRaw("Horizontal");



        if (canDash && Input.GetKey(KeyCode.LeftShift) && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            Debug.Log("shift");


            StartCoroutine(Dash());

            animator.SetTrigger("Dash");


        }

        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        Flip();

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }

        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);









        if (!isJumping && Input.GetKey(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);

            jumpCount = 1;

            if (isJumping == true && jumpCount == 1 && Input.GetKey(KeyCode.Space))
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
                jumpCount = 0;
            }


        }







    }


    private IEnumerator Dash() // enumeration de pseudo-fonctions
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;  // set la gravite a 0
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * dashingPower, 0f); //applique la force
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime); // compte le temps du dash
        tr.emitting = false;
        rb.gravityScale = originalGravity; // remets la gravite
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown); // cooldown
        canDash = true;
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            Vector3 localScale = transform.localScale;
            isFacingRight = !isFacingRight;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }


    void Attack()
    {
        animator.SetTrigger("Attaque");

        Collider2D[] hitEnnemie = Physics2D.OverlapCircleAll(range.position, attackrange, enemyLayer);
        foreach(Collider2D ennemy in hitEnnemie) 
        {
            ennemy.GetComponent<mob>().touche(Degats);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (range == null)
            return;

        Gizmos.DrawWireSphere(range.position, attackrange);   
    }
}




