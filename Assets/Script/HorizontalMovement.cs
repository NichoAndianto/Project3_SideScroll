using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{
    private float t;
    private float originalPosX;
    private float lastX;

    public float distance = 2f;
    public float speed = 1f;

    private SpriteRenderer spriteRenderer;
    private Animator animator;

    void Start()
    {
        originalPosX = transform.position.x;
        lastX = transform.position.x;

        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        
        t += Time.deltaTime * speed;
        float newX = originalPosX + Mathf.Sin(t) * distance;
        transform.position = new Vector2(newX, transform.position.y);

        
        float deltaX = newX - lastX;

        
        if (deltaX > 0.01f)
        {
            spriteRenderer.flipX = false; 
        }
        else if (deltaX < -0.01f)
        {
            spriteRenderer.flipX = true; 
        }

        
        if (Mathf.Abs(deltaX) > 0.01f)
        {
            animator.SetTrigger("goWalk");
        }
        else
        {
            animator.SetTrigger("goIdle");
        }

        
        lastX = newX;
    }
}
