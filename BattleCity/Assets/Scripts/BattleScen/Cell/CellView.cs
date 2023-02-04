using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellView : MonoBehaviour
{
    [SerializeField] private ECellType _eCellType;
    [SerializeField] private EBlockType _eBlockType;
    [SerializeField] private EBlockType _eBlockType2;

    [SerializeField] private List<GameObject> _bricks = new List<GameObject>();
    [SerializeField] private List<GameObject> _concrete = new List<GameObject>();
    [SerializeField] private GameObject _water;
    [SerializeField] private GameObject _forest;
    [SerializeField] private GameObject _ice;
    [SerializeField] private GameObject _headquarters;

    private CellController _cellController;
    private CellSettingsController _cellSettingsController;

    private void Awake()
    {
        
    }

    public void Apply()
    {
        _cellSettingsController = new CellSettingsController(_eCellType, _eBlockType, _eBlockType2, _bricks, _concrete, _water, _forest, _headquarters, _ice);
        _cellSettingsController.Apply();
    }
}
