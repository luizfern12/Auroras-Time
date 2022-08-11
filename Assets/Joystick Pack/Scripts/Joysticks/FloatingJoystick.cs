using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FloatingJoystick : Joystick
{
    private float posX;
    private float posY; 

    protected override void Start()
    {
        base.Start();
        posX = background.anchoredPosition.x;
        posY = background.anchoredPosition.y;
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        background.anchoredPosition = ScreenPointToAnchoredPosition(eventData.position);
        background.gameObject.SetActive(true);
        base.OnPointerDown(eventData);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        background.anchoredPosition = new Vector2(posX, posY);
        base.OnPointerUp(eventData);
    }
}