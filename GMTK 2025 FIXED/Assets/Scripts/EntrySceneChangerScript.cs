using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntrySceneChangerScript : MonoBehaviour
{
    [SerializeField] float changeTime;
    [SerializeField] string sceneName;

    private void Update()
    {
        changeTime -=  Time.deltaTime;
        if (changeTime <= 0)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
