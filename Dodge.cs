using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dodge : MonoBehaviour
{
  

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            dodging();
        }
    }
    void dodging() 
    {
        //�̵� ����
        GetComponent<Move>().agent.isStopped = true;
        //������ ����
        GetComponentInChildren<BoxCollider>().enabled = false;
        //ȸ�� ��Ʈ��� ���    

        //������ ����
        GetComponentInChildren<BoxCollider>().enabled = true;

        /*ȸ�� �ִϸ��̼� ���� ���� �̵� ����
            if(isAnimationPlaying == flase)
            GetComponent<Move>().agent.isStopped = false;
        */
    }
}
