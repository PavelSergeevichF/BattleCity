using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadquartersView : MonoBehaviour
{
    [SerializeField] private SOPlayerData _sOPlayerData;
    [SerializeField] private GameObject _headquarters1;
    [SerializeField] private GameObject _headquarters2;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<ShellView>().Destroy();
        _headquarters1.SetActive(false);
        _headquarters2.SetActive(true);
        _sOPlayerData.EStatusLevel = EStatusLevel.GameOver;
    }
}
