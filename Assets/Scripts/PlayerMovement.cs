using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;
    private Animator animator;
    [SerializeField] private LayerMask groundLayer;
    private bool grounded;
    private BoxCollider2D boxCollider;

    private void Respawn()
    {
        body.position = new Vector2(0, 1);
    }

    public void Die()
    {
        Respawn();
    }

    public void Win()
    {
        SceneManager.LoadSceneAsync(0);
    }
    
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private bool HitWall(float vx)
    {
        if (vx < 0)
        {
            RaycastHit2D raycastHitL = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.left, 0.01f, groundLayer);
            return raycastHitL.collider != null;
        }
        if (vx > 0)
        {
            RaycastHit2D raycastHitR = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.right, 0.01f, groundLayer);
            return raycastHitR.collider != null;
        }
        return false;
    }
    
    private void Update()
    {
        float vx = Input.GetAxis("Horizontal");
        if (!HitWall(vx)) {
            body.linearVelocity = new Vector2(speed * vx, body.linearVelocity.y);
            
            if (vx > 0.01f)
            {
                transform.localScale = new Vector3(Math.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else if (vx < -0.01f)
            {
                transform.localScale = new Vector3(-Math.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
        } else {
            body.linearVelocity = Vector2.zero;
            vx = 0;
        }
        animator.SetBool("walk", vx != 0);
        
        if (Input.GetKey(KeyCode.Space))
        {
            Jump();
        }
    }
    
    private void Jump()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.01f, groundLayer);
        grounded = raycastHit.collider != null;
        if (grounded)
        {
            body.linearVelocity = new Vector2(body.linearVelocity.x, 3 * speed);
            grounded = false;
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
    }
}
