using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskControler : MonoBehaviour
{
    SpriteMask mask;
    public GameObject player;
    CapsuleCollider2D capsuleCollider;
    static Environment env;
    private LayerMask playerGroundLayer;

    void Start()
    {
        playerGroundLayer = player.GetComponentInChildren<CollisionSenses>().GroundLayer;
        mask = GetComponent<SpriteMask>();
        capsuleCollider = player.GetComponent<CapsuleCollider2D>();
        env = Environment.DefaultEnvironment;
        capsuleCollider.excludeLayers = LayerMask.GetMask("GreenEnv", "RedEnv","Enemy");
       
    }
    void Update()
    {
        changeMaskEnviorment();
    }

    /// <summary>
    /// Maskenin yeþil ve kýrmýzý olmasýný ayarlar
    /// </summary>
    void changeMaskEnviorment()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (env != Environment.GreenEnvironment)
            {
                mask.frontSortingLayerID = SortingLayer.NameToID("GreenEnv");
                capsuleCollider.excludeLayers = LayerMask.GetMask("RedEnv", "DefaultEnv","Enemy");
                env = Environment.GreenEnvironment;
            }
            else
            {
                mask.frontSortingLayerID = SortingLayer.NameToID("DefaultEnv");
                capsuleCollider.excludeLayers = LayerMask.GetMask("GreenEnv", "RedEnv","Enemy");
                env = Environment.DefaultEnvironment;
            
            }
           
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {

            if (env != Environment.RedEnvironment)
            {
                mask.frontSortingLayerID = SortingLayer.NameToID("RedEnv");
                capsuleCollider.excludeLayers = LayerMask.GetMask("GreenEnv", "DefaultEnv", "Enemy");
                env = Environment.RedEnvironment;
              
            }
            else
            {
                mask.frontSortingLayerID = SortingLayer.NameToID("DefaultEnv");
                capsuleCollider.excludeLayers = LayerMask.GetMask("GreenEnv", "RedEnv", "Enemy");
                env = Environment.DefaultEnvironment;
               
            }

        }
    }
}
