using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dodge : MonoBehaviour
{
    private bool canDodge = true;
    public GameObject hit_zone;
    private Vector3 dodgeVector;

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
        GetComponent<Move>().agent.ResetPath();
        hit_zone.GetComponent<BoxCollider>().enabled = false; //������ ����

        dodgeVector = GetComponent<Move>().MovePointReturn(Camera.main.ScreenPointToRay(Input.mousePosition));
        this.transform.LookAt(dodgeVector);

        GetComponent<AnimationControl>().DodgeAnim(); //ȸ�� ��� ���

        StartCoroutine(CheckDodgeAnim());
    }


    IEnumerator CheckDodgeAnim()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            if (GetComponent<AnimationControl>().animator.GetCurrentAnimatorStateInfo(0).fullPathHash !=
            Animator.StringToHash("Base Layer.Dodge"))
            {
                //this.transform.position = GetComponent<AnimationControl>().animator.rootPosition;
                hit_zone.GetComponent<BoxCollider>().enabled = true; //������ ����
                GetComponent<Move>().agent.isStopped = false; //�̵� ����
                canDodge = true;
                break;
            }
        }
    }
    
}
