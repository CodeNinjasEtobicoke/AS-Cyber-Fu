using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControls : MonoBehaviour
{
    public float speed = 5;
    public float attackDistance = 1;
    public Vector3 direction;

    private Animator animatorEnemy;
    private Rigidbody rigidbodyEnemy;
    private Transform target;
    public bool isFollowingTarget;
    public bool isAttackingTarget;
    private float chasingPlayer = 0.01f;
    public float currentAttackingTime;
    public float maxAttackingTime = 2f;


    // Start is called before the first frame update
    void Start()
    {
        isFollowingTarget = true;
        currentAttackingTime = maxAttackingTime;
        rigidbodyEnemy = GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FollowTarget();
    }

    void FollowTarget()
    {
        if (!isFollowingTarget)
        {
            return;
        }

        if (Vector3.Distance(transform.position, target.position) >= attackDistance)
        {
            direction = target.position - transform.position;
            direction.y = 0;

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 20);

            if (rigidbodyEnemy.velocity.sqrMagnitude != 0)
            {
                rigidbodyEnemy.velocity = transform.forward * speed;
                animatorEnemy.SetBool("Walk", true);
            }
        }
        else if (Vector3.Distance(transform.position, target.position) <= attackDistance)
        {
            rigidbodyEnemy.velocity = Vector3.zero;
            animatorEnemy.SetBool("Walk", false);
            isFollowingTarget = false;
            isAttackingTarget = true;
        }

        void Attack()
        {
            if (!isAttackingTarget)
            {
                return;
            }


        }
    }
}   
