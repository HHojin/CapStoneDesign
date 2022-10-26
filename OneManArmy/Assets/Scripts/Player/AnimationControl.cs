using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{

    public Animator animator;

    public void WalkAnim(bool canWalk)
    {
        animator.SetBool("isWalk", canWalk);
    }

    public void DefaultAttackAnim()
    {
        animator.SetTrigger("defaultAttack");
        WalkAnim(false);
    }
}
