using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed;
    public Transform[] point;

    private int i;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = point[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, point[i].position) < 0.01f)
        {
            i++;
            if (i == point.Length)
            {
                i = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, point[i].position,speed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}
