using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    

    public ResetCheckScript RCS;
    // Start is called before the first frame update
    void Start()
    {
        RCS = GameObject.FindGameObjectWithTag("Reset").GetComponent<ResetCheckScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(RCS.checkpointIndex);
        }
    }
}
