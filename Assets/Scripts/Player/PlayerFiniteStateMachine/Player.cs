using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Player : MonoBehaviour
{
    #region State Veriables
    public PlayerStateMachine StateMachine {  get; private set; }

    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerJumpState JumpState { get; private set; }
    public PlayerLandState LandState { get; private set; }
    public PlayerInAirState InAirState { get; private set; }

    public PlayerDashState DashState { get; private set; }

    public PlayerAttackState PrimaryAttackState { get; private set; }
   // public PlayerAttackState SecondaryAttackState { get; private set; }

    [SerializeField]
    private PlayerData playerData;
    #endregion

    #region Components
    public Core Core { get; private set; }
    public Animator Anim {  get; private set; }
    public PlayerInputHandler InputHandler { get; private set; }
    public Rigidbody2D RB { get; private set; }
    public Transform DashDirectionIndicator { get; private set; }
    public PlayerInventory Inventory { get; private set; }
    #endregion
    private Stats Stats { get => stats ?? Core.GetCoreComponent(ref stats); }
    private Stats stats;


    #region Other Veriables
    //private Vector2 workspace;
    #endregion

    #region Unity Callback Functions
    private void Awake()
    {
        Core = GetComponentInChildren<Core>();
        StateMachine = new PlayerStateMachine();

        IdleState = new PlayerIdleState(this,StateMachine,playerData,"idle");
        MoveState = new PlayerMoveState(this, StateMachine, playerData, "move");
        JumpState = new PlayerJumpState(this, StateMachine, playerData, "inAir");
        InAirState = new PlayerInAirState(this, StateMachine, playerData, "inAir");
        LandState = new PlayerLandState(this, StateMachine, playerData, "land");
        DashState = new PlayerDashState(this, StateMachine, playerData, "inAir");
        PrimaryAttackState = new PlayerAttackState(this, StateMachine, playerData, "attack");
        //SecondaryAttackState = new PlayerAttackState(this, StateMachine, playerData, "attack");
    }

    private void Start()
    {
        Anim = GetComponent<Animator>();
        InputHandler= GetComponent<PlayerInputHandler>();
        RB = GetComponent<Rigidbody2D>();
        DashDirectionIndicator = transform.Find("DashDirectionIndicator");
        Inventory= GetComponent<PlayerInventory>();


       PrimaryAttackState.SetWeapon(Inventory.weapons[(int)CombatInputs.primary]);
       // SecondaryAttackState.SetWeapon(Inventory.weapons[(int)CombatInputs.secondary]);
       // FacingDirection = 1;
        StateMachine.Initialize(IdleState);
    }

    private void Update()
    {
        Core.LogicUpdate();
        //CurrentVelocity = RB.velocity;
        StateMachine.CurrentState.LogicUpdate();

        if (gameObject.activeInHierarchy==false)
        {
            Debug.Log("Can 0");
            SavePlayerPos.instance.PlayerDeath();
            Stats?.IncreaseHealth(Stats.maxHealth);
        }
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }
    #endregion


    #region Other Functions

    private void AnimationTrigger() => StateMachine.CurrentState.AnimationTrigger();
    private void AnimationFinishTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();

 

    private void OnDrawGizmos()
    {
       // Gizmos.DrawWireCube(transform.position - transform.up *Core.CollisionSenses.CastDistance,Core.CollisionSenses.BoxSize);
    }
    #endregion

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.tag=="Thorn")
        {
            Stats?.DecreaseHealth(Stats.maxHealth);
            SavePlayerPos.instance.PlayerDeath();
            Stats?.IncreaseHealth(Stats.maxHealth);

        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "CheckPoint")
        {

            SavePlayerPos.instance.respawnPoint = transform.position;

        }
    }


}
