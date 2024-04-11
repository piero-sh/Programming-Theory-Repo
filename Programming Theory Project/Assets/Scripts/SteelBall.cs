using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteelBall : Ball
{
    [SerializeField]
    private GameObject cracksMarks;

    public static SteelBall Instance { get; private set; }

    void Awake()
    {
        if(Instance != null){
            Destroy(gameObject);
            return;
        }
        Instance = this;
        if(cracksMarks.activeSelf)
        {
            cracksMarks.SetActive(false);
        }
    }

    void Start()
    {
        UIManager.Instance.UpdateSteelBallText();
    }
    
    protected override void CollisionEvent()
    {
        base.CollisionEvent();
        cracksMarks.SetActive(true);
        UIManager.Instance.UpdateSteelBallText();
    }
}
