using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class RubberBall : Ball
{
    public static RubberBall Instance { get; private set; }

    void Awake()
    {
        if(Instance != null){
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    void Start()
    {
        UIManager.Instance.UpdateRubberBallText();
    }
    
    // POLYMORPHISM
    protected override void CollisionEvent()
    {
        base.CollisionEvent();
        bouncesCount++;
        UIManager.Instance.UpdateRubberBallText();
    }
}
