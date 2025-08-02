using UnityEngine;

public class TrashEjectionScript : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private BoxCollider2D bc;
    [SerializeField] private GameObject valve;
    public GameObject box;
    [SerializeField] ValveScript valveScript; //drag in scene not prefab
    public AudioSource AS;
    public AudioClip fall;

    [Header("Variables")]
    [SerializeField] float velocity; 
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        AS = GetComponent<AudioSource>(); 
        valveScript.OnOpenValve += ValveScript_OnOpenValve;
    }

    private void ValveScript_OnOpenValve(object sender, System.EventArgs e)
    {
        AS.PlayOneShot(fall);

        Vector2 dir = new Vector2(0, 0);
        if (valve.transform.rotation.eulerAngles.z == 180)
        {
            dir = transform.position - valve.transform.position;
        }
        else
        {
            dir = valve.transform.position - transform.position;
        }
        rb.velocity = dir.normalized * velocity;
        bc.enabled = false;

       
    }
    private void FixedUpdate()
    {
        
    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Box")
        {
            AS.PlayOneShot(fall);
            GameObject.Destroy(gameObject);
        }
    
    }
}
