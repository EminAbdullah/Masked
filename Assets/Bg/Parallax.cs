using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    private float length, startpos;
    public Transform objectTransform;
    public float parallaxEffect;
    void Start()
    {
        startpos = base.transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void FixedUpdate()
    {
        float temp = objectTransform.position.x * (1 - parallaxEffect);
        float dist = objectTransform.position.x * parallaxEffect;
        base.transform.position = new Vector3(startpos + dist, base.transform.position.y, base.transform.position.z);
        if (temp > startpos + length) startpos += length;
        else if (temp < startpos - length) startpos -= length;
    }
}
