using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [Header("Positions")]
    [SerializeField] Vector3 OpenPos;
    [SerializeField] Vector3 ClosePos;

    public bool Opening;

    [Header("Movement")]
    [SerializeField] float MoveSpeed;
    [SerializeField] float openDistance;

    [Header("References")]
    public Rigidbody2D RB;
    public GameObject OpenChild; //rmb to drag these
    public GameObject CloseChild;
    public ButtonScript buttonScript;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        buttonScript = GameObject.FindGameObjectWithTag("Button").GetComponent<ButtonScript>();
        OpenPos = OpenChild.transform.position;
        ClosePos = CloseChild.transform.position;
        Opening = false;
        buttonScript.OnButtonPressed += ButtonScript_OnButtonPressed;
    }

    private void ButtonScript_OnButtonPressed(object sender, System.EventArgs e)
    {
        Opening = true;
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Opening)
        {
            Open();
        }
        else
        {
            Close();
        }
    }

    public void Open()
    {
        Vector3 dir = OpenPos - transform.position;
        transform.position += dir * MoveSpeed * Time.deltaTime;

    }

    public void Close()
    {

        Vector3 dir = ClosePos - transform.position;
        transform.position += dir * MoveSpeed * Time.deltaTime;

    }
}
