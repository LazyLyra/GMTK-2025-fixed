using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirParticleScript : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float timer;
    [SerializeField] float killTime;

    public ValveScript VS;
    // Start is called before the first frame update
    void Start()
    {
        VS = GameObject.FindGameObjectWithTag("Valve").GetComponent<ValveScript>();

        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        transform.position += new Vector3(moveSpeed, 0, 0) * Mathf.Sign(VS.transform.localScale.x) * Time.deltaTime;
    }
}
