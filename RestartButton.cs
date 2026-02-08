using UnityEngine;

public class RestartButton : MonoBehaviour
{
    public void RestartGame() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
    }
}
