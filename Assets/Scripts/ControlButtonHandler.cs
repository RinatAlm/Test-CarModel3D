using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class ControlButtonHandler : MonoBehaviour, IUpdateSelectedHandler, IPointerDownHandler, IPointerUpHandler
{
    public bool isForward;
    public bool isBack;
    public bool isRight;
    public bool isLeft;
    public bool isPressed;
    public void OnUpdateSelected(BaseEventData data)
    {
        if (isPressed)
        {
            if(isForward)
            {
                CarController.instance.GoForward();
            }
            else if(isBack)
            {
                CarController.instance.GoBack();
            }
            else if(isRight)
            {
                CarController.instance.GoRight();
            }
            else if(isLeft)
            {
                CarController.instance.GoLeft();
            }
        }
        else
        {
            CarController.instance.ReturnForward();
            CarController.instance.ReturnRight();
        }
    }
    public void OnPointerDown(PointerEventData data)
    {
        isPressed = true;
    }
    public void OnPointerUp(PointerEventData data)
    {
        isPressed = false;
    }
}
