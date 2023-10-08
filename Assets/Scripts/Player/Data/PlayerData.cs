using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="newPlayerData",menuName ="Data/Player Data/Base Data")]
public class PlayerData : ScriptableObject
{
    [Header("Move State")]
    public float movementVelocity=10f;

    [Header("Jump State")]
    public float jumpVelocity = 15f;
    public int amountOfJumps = 1;

    [Header("In Air State")]
    public float coyoteTime = 0.2f;

    [Header("In Air State")]
    public float dashCooldown = 0.5f;
    public float maxHoldTime = 1;
    public float holdTimeScale = 0.25f;
    public float dashTime = 0.2f;
    public float dashVelocity = 20f;
    public float drag = 10f;
    public float dashEndYMultiplier= 0.2f;
    public float distBetweenAfterImages= 0.5f;
    /*
    [Header("Check Veriables")]
    public Vector2 boxSize;
    public LayerMask groundLayer;
    public float castDistance;
    */
    
}
