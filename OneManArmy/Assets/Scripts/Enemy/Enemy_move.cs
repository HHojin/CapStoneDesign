using UnityEngine;
using UnityEngine.AI;

public class Enemy_move : MonoBehaviour
{

    public NavMeshAgent NVagent;
    EnemyStat stat;
    public GameObject GOplayer = null;
    public bool trace = false;

    private void Awake()
    {
        stat = GetComponent<EnemyStat>();
        GOplayer = GameObject.FindWithTag("Player");   
    }

    void Start()
    {
        NVagent = this.GetComponent<NavMeshAgent>();
        NVagent.speed = stat.Move_speed;
    }

    void Update()
    {
        if (trace)
        {
            NVagent.SetDestination(GOplayer.transform.position);
            GetComponent<EnemyAnimationControl>().WalkAnim(true);

            if (GetComponent<EnemyAnimationControl>().animator.GetCurrentAnimatorStateInfo(0).fullPathHash ==
                Animator.StringToHash("Base Layer.Walk Aggro"))
            {
                NVagent.isStopped = false;
            }
            else
            {
                NVagent.isStopped = true;
            }
        }

        if(GameManager.instance.isGameOver == true)
        {
            NVagent.ResetPath();
            this.GetComponent<EnemyAnimationControl>().ReStart();
        }
    }
}