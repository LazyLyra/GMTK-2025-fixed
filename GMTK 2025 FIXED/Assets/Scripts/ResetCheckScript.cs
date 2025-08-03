using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetCheckScript : MonoBehaviour
{
    public int checkpointIndex;
    public int lifeCounter;

    public TimerScript timerScript;
    // Start is called before the first frame update
    void Awake()
    {  
        checkpointIndex = 2;
        DontDestroyOnLoad(gameObject);

        timerScript = GameObject.FindGameObjectWithTag("Timer").GetComponent<TimerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        

        if (SceneManager.GetActiveScene().buildIndex >= 5)
        {
            checkpointIndex = 5;
        }

        if (Input.GetKeyDown(KeyCode.R))

        {
            SceneManager.LoadScene(checkpointIndex);
            timerScript.ResetTimer();
            LoseLife();
        }
    }

    public void LoseLife()
    {
        lifeCounter -= 1;

        if (lifeCounter == 0)
        {
            SceneManager.LoadScene(8);
        }
    }
}
