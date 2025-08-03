using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionScript : MonoBehaviour
{
    [SerializeField] int index;
    public TimerScript timerScript;

    private void Start()
    {
        timerScript = GameObject.FindGameObjectWithTag("Timer").GetComponent<TimerScript>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            timerScript.ResetTimer();
        }
    }
}
