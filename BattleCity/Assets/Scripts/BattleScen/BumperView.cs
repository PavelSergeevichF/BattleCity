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

    private void OnTriggerEnter2D()//private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"{_eVectorMove} Enter");
        //if (collision.gameObject.layer==6 || collision.gameObject.layer==7) 
        //{
        //    _obstacle=true;
        //}
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log($"{_eVectorMove} Exit");
        if (collision.gameObject.layer == 6 || collision.gameObject.layer == 7)
        {
            _obstacle = false;
        }
    }
}
