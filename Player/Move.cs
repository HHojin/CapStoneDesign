using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Move : MonoBehaviour
{


    public float nSpeed;      // ���߿� ĳ���� Status ����ü ���� �����ϵ��� �� �� 
    public NavMeshAgent agent;
    private Vector3 movePoint; // �̵� ��ġ ����
    public Camera mainCamera; // ���� ī�޶�
    public Ray ray;
    void Start()
    {
        //�⺻���� �ʱ�ȭ
        nSpeed = 4.0f;

        mainCamera = Camera.main;
        agent = this.GetComponent<NavMeshAgent>();
        agent.speed = nSpeed;
        agent.angularSpeed = 7600.0f;
        agent.stoppingDistance = 0;
        agent.autoBraking = false;
    }

    void Update()
    {

        mainCamera.transform.position = new Vector3(this.transform.position.x, 25, this.transform.position.z); //test�� ī�޶� ��ġ 
        ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButton(1))
        {
            agent.isStopped = false;
            Move_to(MovePointReturn(ray)); 
            //�̵� ��ҿ� ����Ʈ �߰� 
        }

    }




    // ���� �Ʒ� �Լ��� ���� ��� ��ɰ���, �������� ���� 
    void Move_to(Vector3 movePoint)
    {
        //test ��ɾ� Dodging func�ϼ� ���� ��� 
        agent.SetDestination(movePoint);
        
    }
   public Vector3 MovePointReturn(Ray ray)
    {
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            movePoint = raycastHit.point;
           // Debug.Log("movePoint : " + movePoint.ToString());
           // Debug.Log("���� ��ü : " + raycastHit.transform.name);

        }
        return movePoint;
    }
    public Ray getRay()
    {
        return ray;
    }

}

