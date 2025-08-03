using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FloodingScript : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] Vector3 finalPosition;

    public ResetCheckScript RCS;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, -9, transform.position.z);

        RCS = GameObject.FindGameObjectWithTag("Reset").GetComponent<ResetCheckScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < finalPosition.y)
        {
            transform.position += new Vector3(0, moveSpeed, 0) * Time.deltaTime;
        }
        else
        {
            SceneManager.LoadScene(RCS.checkpointIndex);
        }
        
        
    }
}
