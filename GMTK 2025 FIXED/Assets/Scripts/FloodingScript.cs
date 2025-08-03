using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloodingScript : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] Vector3 finalPosition;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, -9, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < finalPosition.y)
        {
            transform.position += new Vector3(0, moveSpeed, 0) * Time.deltaTime;
        }
        
        
    }
}
