using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Move : MonoBehaviour
{



    public NavMeshAgent agent;
    private Vector3 movePoint; // �̵� ��ġ ����
    public Camera mainCamera; // ���� ī�޶�
    public Ray ray;

    public ParticleSystem ps;

    void Start()
    {
        //�⺻���� �ʱ�ȭ
       

        mainCamera = Camera.main;
        agent = this.GetComponent<NavMeshAgent>();
        agent.speed = GetComponent<PlayerStat>().Move_speed;
        agent.angularSpeed = 7600.0f;
        agent.stoppingDistance = 0;
        agent.autoBraking = false;
    }

    void Update()
    {


        ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        //��Ŭ�� �̵� 
        if (Input.GetMouseButton(1))
        {
            Vector3 movePoint = MovePointReturn(ray);
            Move_to(movePoint);
        }
        //�̵� ��ҿ� ����Ʈ �߰�
        if (Input.GetMouseButtonUp(1))//�ִϸ��̼� ���϶��� �������� �����ؾ��� 
        {
            Instantiate(ps, movePoint, Quaternion.identity);
        }

        if(DestinationArrived())
        {
           // Debug.Log("Arrived");
            GetComponent<AnimationControl>().WalkAnim(false);
        }
    }

    // ���� ��ɰ���, �������� ���� �ϵ��� ����
    void Move_to(Vector3 movePoint)
    {
        if (GetComponent<AnimationControl>().animator.GetCurrentAnimatorStateInfo(0).fullPathHash !=
            Animator.StringToHash("Base Layer.DefaultAttack"))
        {
            //Debug.Log("set destination");
            agent.SetDestination(movePoint);
            GetComponent<AnimationControl>().WalkAnim(true);
            agent.isStopped = false;
        }
        else
        {
            agent.isStopped = true; // ���� ����� �̵� ����
        }

    }

    public Vector3 MovePointReturn(Ray ray)
    {
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            movePoint = raycastHit.point;
            //Debug.Log("movePoint : " + movePoint.ToString());
            //Debug.Log("���� ��ü : " + raycastHit.transform.name);

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

}

