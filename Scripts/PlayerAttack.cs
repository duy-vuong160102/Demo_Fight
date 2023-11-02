using UnityEngine;

public enum AttackState
{
    NONE,
    PUCNH_1,
    PUCNH_2,
    PUCNH_3,
    KICK_1,
    KICK_2,
}

public class PlayerAttack : MonoBehaviour
{
    private PlayerAnimation playerAnim;

    private AttackState attackState;
    private bool attackTimerReset;
    private float defaultTimeAttack = 0.4f;
    private float currentAttackTime;
    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponentInChildren<PlayerAnimation>();
        attackState = AttackState.NONE;
        currentAttackTime = defaultTimeAttack;
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
        ResetAttack();
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            attackState++;
            attackTimerReset = true;
            currentAttackTime = defaultTimeAttack;
            if (attackState == AttackState.PUCNH_1)
            {
                playerAnim.Punch01();
            }
            if (attackState == AttackState.PUCNH_2)
            {
                playerAnim.Punch02();
            }
            if (attackState == AttackState.PUCNH_3)
            {
                playerAnim.Punch03();
            }
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            if (attackState == AttackState.KICK_2 || attackState == AttackState.PUCNH_3)
            {
                return;
            }

            if (attackState == AttackState.NONE ||
                attackState == AttackState.PUCNH_1 ||
                attackState == AttackState.PUCNH_2)
            {
                attackState = AttackState.KICK_1;
            }
            else if (attackState == AttackState.KICK_1)
            {
                attackState++;
            }

            attackTimerReset = true;
            currentAttackTime = defaultTimeAttack;

            if (attackState == AttackState.KICK_1)
            {
                playerAnim.Kick01();
            }
            if (attackState == AttackState.KICK_2)
            {
                playerAnim.Kick02();
            }
        }
    }

    void ResetAttack()
    {
        if (attackTimerReset)
        {
            currentAttackTime -= Time.deltaTime;
            if (currentAttackTime <= 0)
            {
                attackState = AttackState.NONE;
                attackTimerReset = false;
            }
        }
    }
}
