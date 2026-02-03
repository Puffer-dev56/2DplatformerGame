using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int speed;
    public Transform[] point;
    private int i;
    SpriteRenderer spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, point[i].position) < 0.25f) 
        {
            i++;
            if (i == point.Length)
            {
                i = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, point[i].position, speed * Time.deltaTime);
        spriteRenderer.flipX = (transform.position.x - point[i].position.x) < 0f;
    }

}
