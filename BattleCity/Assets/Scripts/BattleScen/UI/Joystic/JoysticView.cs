using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JoysticView : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField] private Image _joystickBG;
    [SerializeField] private Image _joystick;
    [SerializeField] private Ratio _ratio;
    [SerializeField] private float _ratioJoystickX = 6;
    [SerializeField] private float _ratioJoystickY = 4;
    [SerializeField] private float _ratioPose = 4;

    public Vector2 InputVector;

    private JoystickController _joystickController;
    public JoystickController JoystickController => _joystickController;

    private void Awake()
    {
        _ratio.SetRatio(_ratioJoystickX, _ratioJoystickY, _ratioPose);
        _joystickController = new JoystickController(this, _joystickBG, _joystick, _ratio);
    }
    public void SetInputVector(Vector2 vector2)
    {
        InputVector = vector2;
    }
    public void OnDrag(PointerEventData eventData) => _joystickController.OnDrag(eventData);

    public void OnPointerUp(PointerEventData eventData) => _joystickController.OnPointerUp(eventData);

    public void OnPointerDown(PointerEventData eventData) => _joystickController.OnPointerDown(eventData);

}

public struct Ratio
{
    private float _ratioJoystickX;
    private float _ratioJoystickY;
    private float _ratioPose;

    public void SetRatio(float JoystickX, float JoystickY, float Pose)
    {
        _ratioJoystickX = JoystickX;
        _ratioJoystickY = JoystickY;
        _ratioPose = Pose;
    }
    public float GetRatioJoystickX() => _ratioJoystickX;
    public float GetRatioJoystickY() => _ratioJoystickY;
    public float GetRatioPose() => _ratioPose;
}