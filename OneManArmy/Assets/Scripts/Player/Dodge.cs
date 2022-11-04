using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dodge : MonoBehaviour
{
    private bool canDodge = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canDodge)
        {
            dodging();
        }
    }
    void dodging()
    {
        canDodge = false;
        GetComponent<Move>().agent.isStopped = true; //�̵� ����
        transform.Find("Hit_zone").gameObject.GetComponent<BoxCollider>().enabled = false; //������ ����
        //GetComponent<AnimationControl>().DodgeAnim(); //ȸ�� ��� ���   

        //StartCoroutine(CheckDodgeAnim());
    }

    /*
    IEnumerator CheckDodgeAnim()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            if (GetComponent<AnimationControl>().animator.GetCurrentAnimatorStateInfo(0).fullPathHash !=
            Animator.StringToHash("Base Layer.Dodge"))
            {
                transform.Find("Hit_zone").gameObject.GetComponent<BoxCollider>().enabled = true; //������ ����
                GetComponent<Move>().agent.isStopped = false; //�̵� ����
                canDodge = true;
                break;
            }
        }
    }
    */
}
