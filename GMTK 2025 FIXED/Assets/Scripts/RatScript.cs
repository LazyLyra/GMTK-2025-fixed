using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class RatScript : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject target;
    [SerializeField] float moveSpeed = 6f;
    [SerializeField] float RadiusOfVision = 4f;
    [SerializeField] bool PlayerNear =false;
    [SerializeField] bool ReachPos = false;
    private const string reached = "ReachedPos";
    private const string near = "PlayerNear";
    private Rigidbody2D rb;
    private Animator animator;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        target = GameObject.FindGameObjectWithTag("Target");
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        Vector3 direction = player.transform.position - transform.position;
        Vector3 targetDir = target.transform.position - transform.position;
        if (direction.magnitude <= RadiusOfVision)
        {
            RaycastHit2D Hit = Physics2D.Raycast(transform.position, player.transform.position - transform.position);
            if (Hit.collider == null)
            {
                Debug.Log("collider is null");
                return;
            }
            if(Hit.collider.gameObject == player || direction.magnitude < RadiusOfVision)
            {
                PlayerNear = true;
            }
        }
        if (PlayerNear && !ReachPos)
        {
            animator.SetBool(near, PlayerNear);
            animator.SetBool(reached, ReachPos);
            moveToTarget();
            if(targetDir.magnitude <= 0.05f)
            {
                ReachPos = true;
            }
        }
    }

    void moveToTarget()
    {
        Vector3 moveDirection = target.transform.position - transform.position;
        rb.velocity = moveDirection.normalized * moveSpeed;
    }
}
