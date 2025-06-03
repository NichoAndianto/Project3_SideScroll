using UnityEngine;

public class EnemyRunFlip : MonoBehaviour
{
    private float horizontalInput;
    private SpriteRenderer sp;
    private Rigidbody2D rb;
    private Animator animator;

    private string currentTrigger = ""; 

    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        PlayerWalk();
    }

    private void PlayerWalk()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        SpriteFlip(horizontalInput);

        if (Mathf.Abs(horizontalInput) > 0.1f)
        {
            SetAnimationTrigger("goWalk");
        }
        else
        {
            SetAnimationTrigger("goIdle");
        }
    }

    private void SpriteFlip(float horizontalInput)
    {
        if (horizontalInput > 0)
        {
            sp.flipX = false;
        }
        else if (horizontalInput < 0)
        {
            sp.flipX = true;
        }
    }

    private void SetAnimationTrigger(string newTrigger)
    {
        if (animator == null || currentTrigger == newTrigger)
            return;

        
        animator.ResetTrigger(currentTrigger);
        animator.SetTrigger(newTrigger);
        currentTrigger = newTrigger;
    }
}
