using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class PlayerOtherAnimations : MonoBehaviour
{
    public Animator anim;

    public Rigidbody2D RB;

    [SerializeField] float timer;
    [SerializeField] float waitTime;
    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (RB.velocity.magnitude == 0)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
        }
        
        if (timer > waitTime)
        {
            timer = 0;
            int value = Random.Range(0, 3);

            if (value == 0)
            {
                anim.SetBool("Laying", true);
            }
            else if (value == 1)
            {
                anim.SetBool("Licking", true);
            }
            else
            {
                anim.SetBool("Scratching", true);
            }
        }
    }

    

   
   
}
