using UnityEngine;
using UnityEngine.AI;

public class Move : MonoBehaviour
{

    public NavMeshAgent agent;
    private Vector3 movePoint;
    public Camera mainCamera;
    public Ray ray;

    public ParticleSystem ps;

    void Start()
    {
        mainCamera = Camera.main;
        agent = this.GetComponent<NavMeshAgent>();
        agent.speed = this.transform.parent.GetComponent<PlayerStat>().Move_speed;
        agent.angularSpeed = 7600.0f;
        agent.stoppingDistance = 0;
        agent.autoBraking = false;
    }

    void Update()
    {
        if (!GameManager.instance.isGameOver)
        {
            ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Input.GetMouseButton(1))
            {
                Vector3 movePoint = MovePointReturn(ray);
                Move_to(movePoint);
            }
            if (Input.GetMouseButtonUp(1) && Time.timeScale != 0)
            {
                Instantiate(ps, movePoint, Quaternion.identity);
            }

            if (DestinationArrived())
            {
                GetComponent<AnimationControl>().WalkAnim(false);
            }
        }
    }

    // 추후 기능관리, 유지보수 용이 하도록 변경
    void Move_to(Vector3 movePoint)
    {
        if (GetComponent<AnimationControl>().animator.GetCurrentAnimatorStateInfo(0).fullPathHash != Animator.StringToHash("Base Layer.DefaultAttack") &&
            GetComponent<AnimationControl>().animator.GetCurrentAnimatorStateInfo(0).fullPathHash != Animator.StringToHash("Base Layer.Dodge"))
        {
            agent.SetDestination(movePoint);
            GetComponent<AnimationControl>().WalkAnim(true);
            MoveGo();
        }
        else
        {
           MoveStop();
        }

    }

    public Vector3 MovePointReturn(Ray ray)
    {
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            movePoint = raycastHit.point;
            //Debug.Log("movePoint : " + movePoint.ToString());
            //Debug.Log("맞은 객체 : " + raycastHit.transform.name);

        }
        return movePoint;
    }

    public Ray getRay()
    {
        return ray;
    }

    private bool DestinationArrived()
    {
        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0)
                {
                    return true;
                }
            }
        }
        return false;
    }
    public void MoveStop()
    {
        agent.isStopped = true;
        GetComponent<AnimationControl>().WalkAnim(false);
       
    }
    public void MoveGo() 
    {
        agent.isStopped = false;
    }
}