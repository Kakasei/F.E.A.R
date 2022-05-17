using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public enum EnemyState
{
    idle,
    run
}
public class MonsterAi : MonoBehaviour
{
    public EnemyState CurrentState = EnemyState.idle;
    public Animator ani;
    private Transform player;
    public NavMeshAgent agent;
    AnimatorStateInfo info;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v = player.position;
        double stopdistance = 1.5;
        info = ani.GetCurrentAnimatorStateInfo(0);
        float distance = Vector3.Distance(player.position, transform.position);
        switch (CurrentState)
        {
            case EnemyState.idle:
                if (distance > stopdistance)
                {
                    CurrentState = EnemyState.run;
                }
                ani.Play("idle");
                transform.LookAt(v);
                agent.isStopped = true;
                break;
            case EnemyState.run:
                if (distance <= stopdistance)
                {
                    CurrentState = EnemyState.idle;
                }
                transform.LookAt(v);
                agent.speed = 1.5f;
                ani.Play("run");
                agent.isStopped = false;
                agent.SetDestination(player.position);
                break;
        }
    }
}
