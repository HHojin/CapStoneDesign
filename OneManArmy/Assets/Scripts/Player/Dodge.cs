using System.Collections;
using UnityEngine;

public class Dodge : MonoBehaviour
{
    private bool canDodge = true;
    public CapsuleCollider hit_zone;
    private Vector3 dodgeVector;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canDodge && !GameManager.instance.isGameOver)
        {
            dodging();
        }
    }
    void dodging()
    {
        canDodge = false;
        GetComponent<Move>().agent.isStopped = true;
        GetComponent<Move>().agent.ResetPath();
        hit_zone.enabled = false;

        dodgeVector = GetComponent<Move>().MovePointReturn(Camera.main.ScreenPointToRay(Input.mousePosition));
        this.transform.LookAt(dodgeVector);

        GetComponent<AnimationControl>().DodgeAnim();

        StartCoroutine(CheckDodgeAnim());
    }


    IEnumerator CheckDodgeAnim()
    {
        while (true)
        {
            yield return null;
            if (GetComponent<AnimationControl>().animator.GetCurrentAnimatorStateInfo(0).fullPathHash !=
            Animator.StringToHash("Base Layer.Dodge"))
            {
                //this.transform.position = GetComponent<AnimationControl>().animator.rootPosition;
                hit_zone.GetComponent<CapsuleCollider>().enabled = true;
                GetComponent<Move>().agent.isStopped = false;
                canDodge = true;
                break;
            }
        }
    }
}