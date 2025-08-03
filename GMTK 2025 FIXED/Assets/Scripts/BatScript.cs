using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatScript : MonoBehaviour
{
    [Header("variables")]
    [SerializeField] private float chaseDistance = 5f;
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float moveDuration = 3f;
    [SerializeField] private float cooldownDuration = 2f;
    [SerializeField] bool IsFacingRight;

    [Header("References")]
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject breakEffectPrefab;
    [SerializeField] private Rigidbody2D rb;

    private float moveTimer = 0f;
    private float cooldownTimer = 0f;
    private bool isChasing = false;
    private Vector2 chaseDirection;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (rb == null) rb = GetComponent<Rigidbody2D>();
        IsFacingRight = true;
    }

    private void Update()
    {
        if (player == null) return;

        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

        if (isChasing)
        {
            moveTimer -= Time.deltaTime;

            if (moveTimer <= 0f)
            {
                isChasing = false;
                cooldownTimer = cooldownDuration;
                rb.velocity = Vector2.zero;

                
            }
        }
        else
        {
            if (cooldownTimer > 0f)
            {
                cooldownTimer -= Time.deltaTime;
            }
            else if (distanceToPlayer <= chaseDistance)
            {
                isChasing = true;
                moveTimer = moveDuration;
                chaseDirection = (player.transform.position - transform.position).normalized;
                rb.velocity = chaseDirection * moveSpeed;

                CheckFlip();
            }
        }
    }

    private void FixedUpdate()
    {
        if (isChasing)
        {
            rb.velocity = chaseDirection * moveSpeed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Door"))
        {
            if (breakEffectPrefab != null)
            {
                Instantiate(breakEffectPrefab, collision.transform.position, Quaternion.identity);
            }

            Destroy(collision.gameObject);
        }
    }

    void CheckFlip()
    {
        if (IsFacingRight && rb.velocity.x < 0)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            IsFacingRight = !IsFacingRight;
        }
        else if (!IsFacingRight && rb.velocity.x > 0)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            IsFacingRight = !IsFacingRight;
        }
    }
}
