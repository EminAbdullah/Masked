using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy1 : Entity
{
    public E1_IdleState IdleState { get; private set; }
    public E1_MoveState MoveState { get; private set; }
    public E1_PlayerDetectedState PlayerDetectedState { get; private set; }
    public E1_ChargeState ChargeState { get; private set; }
    public E1_LookForPlayerState LookForPlayerState { get; private set; }
    public E1_MeleeAttackState MeleeAttackState { get; private set; }
    public E1_StunState StunState { get; private set; }
    public E1_DeadState DeadState { get; private set; }

    [SerializeField]
    private D_IdleState idleStateData;
    [SerializeField]
    private D_MoveState moveStateData;
    [SerializeField]
    private D_PlayerDetectedState playerDetectedStateData;
    [SerializeField]
    private D_ChargeState chargeStateData;
    [SerializeField]
    private D_LookForPlayer lookForPlayerStateData;
    [SerializeField]
    private D_MeleeAttack meleeAttackStateData;
    [SerializeField]
    private D_StunState stunStateData;
    [SerializeField]
    private D_DeadState deadStateData;

    [SerializeField]
    private Transform meleeAttackPosition;


    public override void Awake()
    {
        base.Awake();

        MoveState = new E1_MoveState(this, stateMachine, "move", moveStateData, this);
        IdleState = new E1_IdleState(this, stateMachine, "idle", idleStateData, this);
        PlayerDetectedState = new E1_PlayerDetectedState(this, stateMachine,"playerDetected",playerDetectedStateData, this);
        ChargeState = new E1_ChargeState(this, stateMachine,"charge", chargeStateData, this);
        LookForPlayerState = new E1_LookForPlayerState(this, stateMachine, "lookForPlayer",lookForPlayerStateData,this);
        MeleeAttackState = new E1_MeleeAttackState(this, stateMachine, "meleeAttack",meleeAttackPosition,meleeAttackStateData, this);
        StunState = new E1_StunState(this, stateMachine, "stun", stunStateData, this);
        DeadState = new E1_DeadState(this, stateMachine,"dead",deadStateData, this);


    }
    private void Start()
    {
        stateMachine.Initialize(MoveState);
    }

    public override void OnDrawGizmos()
    {

        base.OnDrawGizmos();
        Gizmos.DrawWireSphere(meleeAttackPosition.position, meleeAttackStateData.attackRadius);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Thorn")
        {
            this.gameObject.GetComponentInChildren<Stats>().DecreaseHealth(gameObject.GetComponentInChildren<Stats>().maxHealth);

        }
    

    }

}
