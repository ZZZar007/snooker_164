using System;
using UnityEngine;
using UnityEngine.EventSystems;

public enum BallColor
{
    White,
    Red,
    Yellow,
    Green,
    Brown,
    Blue,
    Pink,
    Black
}

public class Ball : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private int point;

    [SerializeField]
    private BallColor color;

    [SerializeField]
    private MeshRenderer rd;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(point);
        Gamemanager.instance.PlayerScore += point;
        Destroy(gameObject);
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void SetColorAndPoint(BallColor col)
    {
        switch (col)
        {
            case BallColor.White:
                point = 0;
                rd.material.color = Color.white;
                break;
        }
    }
}
