using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcreteView : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<ShellView>().Destroy();//Destroy(collision.gameObject);
    }
}
