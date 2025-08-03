using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public float floodTime;
    public float timer;
    public DeathSequence DS;
    public Image image;
    public ResetCheckScript RCS;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        image = GetComponent<Image>();
        DS = GameObject.FindGameObjectWithTag("Death").GetComponent<DeathSequence>();
        RCS = GameObject.FindGameObjectWithTag("Reset").GetComponent<ResetCheckScript>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        image.fillAmount = timer / floodTime;

        if (timer >= floodTime)
        {
         
            DS.Die();
            RCS.checkpointIndex = 2;
            GameObject.Destroy(gameObject);
        }
    }
    
    public void ResetTimer()
    {
        timer = 0;
    }
}
