using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_MoveState : MoveState
{
    private Enemy1 enemy;
    public E1_MoveState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_MoveState stateData, Enemy1 enemy) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (isPlayerInMinAgroRange)
        {
            stateMachine.ChangeState(enemy.PlayerDetectedState);
        }
        else if (!isDetectingLedge || isDetectingWall)
        {
            enemy.IdleState.SetFlipAfterIdle(true);
            stateMachine.ChangeState(enemy.IdleState);
        }
        
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        /*
        if (!isDetectingLedge || isDetectingWall)
        {
            enemy.IdleState.SetFlipAfterIdle(true);
            stateMachine.ChangeState(enemy.IdleState);
        }
        */
    }
}
