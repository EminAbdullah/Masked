using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected SO_WeaponData weaponData;
    protected Animator baseAnimator;

    protected PlayerAttackState state;

    protected Core core;

    protected int attackCounter;
    protected virtual void Awake()
    {
        baseAnimator = transform.Find("Base").GetComponent<Animator>();


        gameObject.SetActive(false);
    }

    public virtual void EnterWeapon()
    {
        gameObject.SetActive(true);
        if (attackCounter>=weaponData.movementSpeed.Length)
        {
            attackCounter = 0;
        }

        baseAnimator.SetBool("attack", true);
        baseAnimator.SetInteger("attackCounter", attackCounter);

    }

    public virtual void ExitWeapon()
    {
        baseAnimator.SetBool("attack", false);

        attackCounter++;
        gameObject.SetActive(false);
    }

    public virtual void AnimationFinishTrigger()
    {
        state.AnimationFinishTrigger();
    }

    public virtual void AnimationStartMovementTrigger()
    {
        state.SetPlayerVelocity(weaponData.movementSpeed[attackCounter]);
    }
    public virtual void AnimationStopMovementTrigger()
    {
        state.SetPlayerVelocity(0f);
    }
    public virtual void AnimationTurnOffFlipTrigger()
    {
        state.SetFlipCheck(false);
    }

    public virtual void AnimationTurnOnFlipTigger()
    {
        state.SetFlipCheck(true);
    }
    public virtual void AnimationActionTrigger() { }

    public void InitializeWeapon(PlayerAttackState state,Core core)
    {
        this.state = state;
        this.core = core;
    }
}