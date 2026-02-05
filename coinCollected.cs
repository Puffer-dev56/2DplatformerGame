using UnityEngine;

public class coinCollected : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player.coin += 1;
            Destroy(gameObject);
        }
    }
}
