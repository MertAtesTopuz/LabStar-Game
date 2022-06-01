using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulley : MonoBehaviour
{
    public LineRenderer rope;
    public Transform hook;
    

    // Update is called once per frame
    void Update()
    {
        rope.SetPosition(0, transform.position);
        rope.SetPosition(1, hook.position);
    }
}
