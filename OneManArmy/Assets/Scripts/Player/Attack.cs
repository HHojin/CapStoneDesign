using UnityEngine;

public class Attack : MonoBehaviour
{
    public BoxCollider Hit_zone;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            defaultAttack();

        }
        if (GetComponent<AnimationControl>().animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.DefaultAttack") &&
            GetComponent<AnimationControl>().animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            Hit_zone.enabled = false;
        }

    }

    void defaultAttack() 
    {
        if (GetComponent<AnimationControl>().animator.GetCurrentAnimatorStateInfo(0).fullPathHash != Animator.StringToHash("Base Layer.DefaultAttack") &&
            GetComponent<AnimationControl>().animator.GetCurrentAnimatorStateInfo(0).fullPathHash != Animator.StringToHash("Base Layer.Dodge") &&
            GetComponent<AnimationControl>().animator.GetCurrentAnimatorStateInfo(0).fullPathHash != Animator.StringToHash("Base Layer.Death"))
        {
            this.transform.LookAt(AttackLookatPoint());
            Hit_zone.enabled = true;
            GetComponent<AnimationControl>().DefaultAttackAnim();

            GetComponent<Move>().agent.ResetPath();  
        }

        GetComponent<Move>().agent.isStopped = true;
        GetComponent<Move>().agent.velocity = Vector3.zero; //¹Ì²ô·¯Áü ¹æÁö

    }

    Vector3 AttackLookatPoint()
    {
        
        return GetComponent<Move>().MovePointReturn(Camera.main.ScreenPointToRay(Input.mousePosition));
    }
  
}
