using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperView : MonoBehaviour
{
    [SerializeField] private EVectorMove _eVectorMove;
    [SerializeField] private bool _obstacle=false;

    public EVectorMove EVectorMove => _eVectorMove;
    public bool Obstacle => _obstacle;

    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.layer == 4 || collision.gameObject.layer == 6 || collision.gameObject.layer == 7 || collision.gameObject.layer == 11 || collision.gameObject.layer == 12)
        {
            _obstacle = true;
        }
        else 
        {
            _obstacle = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 4 || collision.gameObject.layer == 6 || collision.gameObject.layer == 7 || collision.gameObject.layer == 11 || collision.gameObject.layer == 12)
        {
            _obstacle = true;
        }
        else
        {
            _obstacle = false;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
        if (collision.gameObject.layer == 4 || collision.gameObject.layer == 6 || collision.gameObject.layer == 7 || collision.gameObject.layer == 11 || collision.gameObject.layer == 12)
        {
            _obstacle = false;
        }
    }
}
