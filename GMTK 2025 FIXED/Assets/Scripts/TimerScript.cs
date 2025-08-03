using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public float floodTime;
    public float timer;
    public Image image;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        image.fillAmount = timer / floodTime;

        if (timer >= floodTime)
        {
            //lose
        }
    }
}
