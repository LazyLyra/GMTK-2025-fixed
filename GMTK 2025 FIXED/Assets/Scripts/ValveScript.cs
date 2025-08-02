using System;
using UnityEngine;

public class ValveScript : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject glowingValve;
    [SerializeField] private GameObject nonGlowingValve;
    [SerializeField] private GameObject Rubbish;
    public AudioSource AS;
    public AudioClip valveOpen;
    public AudioClip air;

    [Header("Variables")]
    [SerializeField] private float InteractionDist;
    [SerializeField] private bool isOpened = false;
    private Vector3 Direction;

    public event EventHandler OnOpenValve;
    
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Rubbish = GameObject.FindGameObjectWithTag("Rubbish");
        AS = GetComponent<AudioSource>();
        var interactionManager = InteractionManager.instance;
        interactionManager.OnInteract += InteractionManager_OnInteract;
        Transform Child1 = transform.Find("SR");
        if (Child1 != null)
        {
            nonGlowingValve = Child1.gameObject;
        }
        Transform Child2 = transform.Find("GlowSR");
        if (Child2 != null)
        {
            glowingValve = Child2.gameObject;
        }

    }

    private void InteractionManager_OnInteract(object sender, System.EventArgs e)
    {
        if (!isOpened)
        {
            OpenValve();
        }
        else
        {
            return;
        }
    }

    private void Update()
    {
        Direction = player.transform.position - transform.position;
        if (Direction.magnitude <= InteractionDist)
        {
            nonGlowingValve.SetActive(false);
            glowingValve.SetActive(true);
        }
        else
        {
            nonGlowingValve.SetActive(true);
            glowingValve.SetActive(false);
        }
    }
    private void OpenValve()
    {
        
        Direction = player.transform.position - transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Direction, InteractionDist);
        if(hit.collider == null) 
        {
            return; 
        }
        if (hit.collider.CompareTag("Player"))
        {
            AS.PlayOneShot(valveOpen);
            
            Vector3 PressureDir = Rubbish.transform.position - transform.position;
            RaycastHit2D RubbishHit = Physics2D.Raycast(transform.position, PressureDir);
            if(RubbishHit.collider == null)
            {
                return;
            }
            if(RubbishHit.collider.name == "Rubbish")
            {
                OnOpenValve?.Invoke(this, EventArgs.Empty);
                isOpened = true;
            }
            else
            {
                //add UI text
                Debug.Log("BLOCKED!");
            }

            AS.PlayOneShot(air);
        }
    }
}
