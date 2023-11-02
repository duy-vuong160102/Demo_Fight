using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
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
    public void Punch01()
    {
        anim.SetTrigger(AnimationTags.PUCNH_01);
    }
    public void Punch02()
    {
        anim.SetTrigger(AnimationTags.PUCNH_02);
    }
    public void Punch03()
    {
        anim.SetTrigger(AnimationTags.PUCNH_03);
    }

    public void Kick01()
    {
        anim.SetTrigger(AnimationTags.KICK_01);
    }
    public void Kick02()
    {
        anim.SetTrigger(AnimationTags.KICK_02);
    }
}
