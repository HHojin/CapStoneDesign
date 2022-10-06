using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            defaultAttack();
        }
    }

    void defaultAttack() 
    {
        this.transform.LookAt(AttackLookatPoint());//���콺 �����Ͱ� �ִ°��� ���Ѵ� 
        GetComponent<Move>().agent.isStopped = true; //�̵� ���� 
        //�⺻ ���ݸ�� ���� 
    }
    /*
     * �̷� ������� ����(��ų)���� �Լ� ����
     * ���߿��� �Լ� ������ȭ �Ͽ� ���� 
     */
    Vector3 AttackLookatPoint()
    {
        
        return GetComponent<Move>().MovePointReturn(Camera.main.ScreenPointToRay(Input.mousePosition));
    }
}
