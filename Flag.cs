using UnityEngine;

public class Flag : MonoBehaviour
{
    public GameObject winUI;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            Debug.Log(1);
            Time.timeScale = 0; 
            winUI.SetActive(true);
        }
    }
}
