using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody rb;
    private Transform playerTransform;
    private bool followPlayer, attackPlayer;
    private EnemyAnimation enemyAnim;
    private float defaultTimeAttack = 2f;
    private float currentAttackTime;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float attackDistance = 1f;




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        playerTransform = GameObject.FindWithTag(Tags.PLAYER_TAG).transform;

        followPlayer = true;

        enemyAnim = GetComponentInChildren<EnemyAnimation>();

        currentAttackTime = defaultTimeAttack;
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    private void FixedUpdate()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        if (!followPlayer) return;

        if (Vector3.Distance(transform.position, playerTransform.position) > attackDistance)
        {
            transform.LookAt(playerTransform);
            rb.velocity = transform.forward * moveSpeed;

            if (rb.velocity.sqrMagnitude != 0)
            {
                enemyAnim.Walk(true);
            }
            
        }
        else
        {
            rb.velocity = Vector3.zero;
            followPlayer = false;
            attackPlayer = true;
            enemyAnim.Walk(false);
        }

    }

    private void Attack()
    {
        if (!attackPlayer) return;

        currentAttackTime += Time.deltaTime;
        if (currentAttackTime > defaultTimeAttack)
        {
            enemyAnim.EnemyAttack(Random.Range(0, 3));
            currentAttackTime = 0f;
        }

        if (Vector3.Distance(transform.position, playerTransform.position) > (attackDistance + 1))
        {
            followPlayer = true;
            attackPlayer = false;
        }
    }
}
