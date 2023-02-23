using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class JoystickController
{
    private Image _joystickBG;
    private Image _joystick;
    private JoysticView _joysticView;
    private Vector2 _inputVector;
    private Ratio _ratio;

    public JoystickController(JoysticView joysticView, Image joystickBG, Image joystick, Ratio ratio)
    {
        _joysticView = joysticView;
        _joystickBG = joystickBG;
        _joystick = joystick;
        _ratio = ratio;
    }

    public virtual void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);
    }

    public virtual void OnPointerUp(PointerEventData ped)
    {
        _inputVector = Vector2.zero;
        _joystick.rectTransform.anchoredPosition = Vector2.zero;
        _joysticView.SetInputVector(_inputVector);
    }

    public virtual void OnDrag(PointerEventData ped)
    {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle
            (_joystickBG.rectTransform, ped.position, ped.pressEventCamera, out pos))
        {
            pos.x = (pos.x / _joystickBG.rectTransform.sizeDelta.x);
            pos.y = (pos.y / _joystickBG.rectTransform.sizeDelta.y);
            float dataX = 0;
            float dataY = 0;
            if (pos.x < -0.2 || pos.x > 0.2) dataX = pos.x;
            if (pos.y < -0.2 || pos.y > 0.2) dataY = pos.y;
            _inputVector = new Vector2(dataX * _ratio.GetRatioPose(), dataY * _ratio.GetRatioPose());
            _inputVector = (_inputVector.magnitude > 1.0f) ? _inputVector.normalized : _inputVector;
            _joystick.rectTransform.anchoredPosition =
                new Vector2(
                    _inputVector.x * (_joystickBG.rectTransform.sizeDelta.x / _ratio.GetRatioJoystickX()),
                    _inputVector.y * (_joystickBG.rectTransform.sizeDelta.y / _ratio.GetRatioJoystickY()));
            _joysticView.SetInputVector(_inputVector);
        }
    }

    public float Horizontal()
    {
        if (_inputVector.x != 0)
        {
            return _inputVector.x;
        }
        else return Input.GetAxis("Horizontal");
    }
    public float Vertical()
    {
        if (_inputVector.y != 0)
        {
            return _inputVector.y;
        }
        else return Input.GetAxis("Vertical");
    }
}
