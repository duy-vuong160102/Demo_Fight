using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationDelegate : MonoBehaviour
{
    [SerializeField] private GameObject leftArmAttackPoint, rightArmAttackPoint,
        leftLegAttackPoint, rightLegAttackPoint;
 
    void LeftArmAttackOn()
    {
        leftArmAttackPoint.SetActive(true);
    }
    void LeftArmAttackOff()
    {
        if (leftArmAttackPoint.activeInHierarchy)
        {
            leftArmAttackPoint.SetActive(false);
        }
    }
}
