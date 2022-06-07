using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
/*public enum EnemyState
{
    idle,
    run
}*/
public class MonsterAi : MonoBehaviour
{
 //   public EnemyState CurrentState = EnemyState.idle;
    public Animator ani;
    private Transform player;
    public NavMeshAgent agent;
 //   AnimatorStateInfo info;
    private float 旋转坐标 = 0;
    private bool isFollowAction = false;
    private bool isPatrolAction = true;
    public Vector3 waitPosition;
    public List<Vector3> patrolPosition = new List<Vector3>(new Vector3[7]);

    float timer = 0;
    int i = 0;

    //   Start is called before the first frame update

    private void OnTriggerStay(Collider other)
    {
        double stopdistance = 1.5;
  //    info = ani.GetCurrentAnimatorStateInfo(0);
        float distance = Vector3.Distance(player.position, transform.position);
        Vector3 v = player.position;

        //触发追逐
        if (other.gameObject.tag == "Player")
        {
            isFollowAction = true;
            agent.isStopped = false;
            this.gameObject.GetComponent<Animator>().SetBool("run", true);
            isPatrolAction = false;
            transform.LookAt(v);
            agent.speed = 2f;
            agent.SetDestination(player.position);

            //追上主角 主角die
            if (distance <= stopdistance)
            {
                this.gameObject.GetComponent<Animator>().SetBool("run", false);
                agent.isStopped = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //回到巡逻点
        if(other.gameObject.tag == "Player")
        {
            this.gameObject.GetComponent<Animator>().SetBool("run", false);
            transform.LookAt(waitPosition);
            agent.SetDestination(waitPosition);
            agent.speed = 0.75f;
            isFollowAction = false;
        }
    }

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        waitPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //巡逻状态
        if (isPatrolAction)
        {
            float dis = Vector3.Distance(transform.position, patrolPosition[i]);
            if(dis <= 1f)
            {
                timer += Time.deltaTime;
                if(timer >= 2f)
                {
                    i++;
                    timer = 0;
                }
                if (i == 7) i = 0;
            }
            else
            {
                //   transform.position = Vector3.Lerp(transform.position, patrolPosition[i],0.01f);
                transform.LookAt(patrolPosition[i]);
                agent.speed = 1f;
                agent.isStopped = false;
                agent.SetDestination(patrolPosition[i]);
            }
                
            
          //  gameObject.GetComponent<Animator>().SetBool("patrol", true);

            /*transform.rotation = Quaternion.Euler(new Vector3(0, 旋转坐标++, 0));
            if (旋转坐标 >= 360) 旋转坐标 -= 360;*/
        }
        else
        {
            if (isFollowAction)
            {

            }
            else if (System.Math.Abs(waitPosition.sqrMagnitude - this.transform.position.sqrMagnitude) <= 1)
            {
                this.gameObject.GetComponent<Animator>().SetBool("run", false);
                agent.isStopped = true;
                isPatrolAction = true;
            }  
        }
        

        /*switch (CurrentState)
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
        }*/
    }
}
