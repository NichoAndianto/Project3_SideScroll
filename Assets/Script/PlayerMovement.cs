using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed, jumpForce;
    private float horizontalinput;
    private SpriteRenderer sp;

    private Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void PlayerAnimation(string animationTriggerName)
    {
        animator.SetTrigger(animationTriggerName);
    }
    private void PlayerWalk()
    {
        horizontalinput = Input.GetAxis("Horizontal");
        transform.Translate(new Vector2(horizontalinput*speed*Time.deltaTime, 0 ));
        SpriteFlip(horizontalinput);
        if(horizontalinput == 0)
        {
            animator.Play("IdleAnimation");
        }
        

    }

    private void SpriteFlip(float horizontalinput)
    {
        if(horizontalinput > 0)
        {
            sp.flipX = false;
            PlayerAnimation("goWalk");
        }
        else if(horizontalinput < 0) 
        {
            sp.flipX = true;
            PlayerAnimation("goWalk");
        }
    }

    private void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.linearVelocity.y) < 0.01f)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            PlayerAnimation("goJump");  
        }
    }


    void Update()
    {
        PlayerWalk();
        PlayerJump();
    }
}
