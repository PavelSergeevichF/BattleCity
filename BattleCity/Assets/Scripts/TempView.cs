using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempView : MonoBehaviour
{

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("OnCollisionEnter2D");
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter2D");
    }
}
