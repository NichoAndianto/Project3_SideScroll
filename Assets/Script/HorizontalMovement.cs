using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{
    float t;
    public float distance ,speed;
    private float originaPos;
    void Start()
    {
        originaPos = transform.position.x;
    }

    
    void Update()
    {
        t+=Time.deltaTime * speed;
        var x = originaPos + Mathf.Sin(t) * distance;
        transform.position = new Vector2(x,transform.position.y);
    }
}
