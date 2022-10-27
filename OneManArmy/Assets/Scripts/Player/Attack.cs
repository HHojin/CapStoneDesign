using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public BoxCollider Hit_zone;
   
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
        if (GetComponent<AnimationControl>().animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.DefaultAttack") &&
GetComponent<AnimationControl>().animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            Hit_zone.enabled = false;//�ִϸ��̼� ������ �������� ����
        }

    }

    void defaultAttack() 
    {
        if (GetComponent<AnimationControl>().animator.GetCurrentAnimatorStateInfo(0).fullPathHash !=
            Animator.StringToHash("Base Layer.DefaultAttack"))
        {
            this.transform.LookAt(AttackLookatPoint());//���콺 �����Ͱ� �ִ°��� ���Ѵ�
            Hit_zone.enabled = true;//�������� on 
            GetComponent<AnimationControl>().DefaultAttackAnim(); //���� �ִϸ��̼� ���

            GetComponent<Move>().agent.ResetPath();  
        }

        GetComponent<Move>().agent.isStopped = true; //�̵� ����
        GetComponent<Move>().agent.velocity = Vector3.zero; //�̲����� ����

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
