using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class GlassBall : Ball
{
    public static GlassBall Instance { get; private set; }

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
        UIManager.Instance.UpdateGlassBallText();
        GlassPartsManager.Instance.Generate(transform);
    }

    // POLYMORPHISM
    protected override void CollisionEvent()
    {
        base.CollisionEvent();
        GlassPartsManager.Instance.Activate(transform);
        //dirty but successfully indicate that the gameObject is destroyed
        Instance = null;
        UIManager.Instance.UpdateGlassBallText();
        Destroy(gameObject);
    }
}
