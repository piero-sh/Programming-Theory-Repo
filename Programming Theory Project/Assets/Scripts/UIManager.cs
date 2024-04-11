using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField]
    private TextMeshPro glassText;
    [SerializeField]
    private TextMeshPro rubberText;
    [SerializeField]
    private TextMeshPro steelText;

    void Awake()
    {
        if(Instance != null){
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    
    public void UpdateGlassBallText()
    {
        glassText.text = (GlassBall.Instance != null) ? GlassBall.Instance.bouncesCount.ToString() : "-";
    }

    public void UpdateRubberBallText()
    {
        rubberText.text = (RubberBall.Instance != null) ? RubberBall.Instance.bouncesCount.ToString() : "-";
    }

    public void UpdateSteelBallText()
    {
        steelText.text = (SteelBall.Instance != null) ? SteelBall.Instance.bouncesCount.ToString() : "-";
    }
}
