using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIButtonFireView : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private IEnumerator _coroutine;


    public Button FireButton;
    [Range(0.1f, 3.0f)]
    public float seconds = 0.3f;
    public UnityEvent onPressedOverSeconds;

    private void Awake()
    {
        onPressedOverSeconds = new UnityEvent();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _coroutine = TrackTimePressed();
        StartCoroutine(_coroutine);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        StopAllCoroutines();
    }
    private IEnumerator TrackTimePressed()
    {

        //Debug.Log($"onPressedOverSeconds.Invoke");
        float time = 0;
        while (time < this.seconds)
        {
            //Debug.Log($"time {time} deltaTime {Time.deltaTime}");
            time += Time.deltaTime;
            yield return null;
        }
        onPressedOverSeconds.Invoke();
    }
}
