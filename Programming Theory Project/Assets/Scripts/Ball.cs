using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public int bouncesCount { get; protected set; }

    void OnCollisionEnter(Collision other)
    {
        CollisionEvent();
    }

    protected virtual void CollisionEvent()
    {
        #if UNITY_EDITOR
        Debug.Log("A GameObject having a " + this.GetType() + " component collided");
        #endif
    }
}
