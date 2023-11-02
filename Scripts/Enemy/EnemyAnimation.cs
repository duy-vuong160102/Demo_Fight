using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>(); 
    }

    public void Walk(bool move)
    {
        anim.SetBool(AnimationTags.MOVEMENT, move);
    }

    public void EnemyAttack(int attack)
    {
        if (attack == 0)
        {
            anim.SetTrigger(AnimationTags.PUCNH_01);
        }
        if (attack == 1)
        {
            anim.SetTrigger(AnimationTags.PUCNH_02);
        }
        if (attack == 2)
        {
            anim.SetTrigger(AnimationTags.PUCNH_02);
        }
    }
}
