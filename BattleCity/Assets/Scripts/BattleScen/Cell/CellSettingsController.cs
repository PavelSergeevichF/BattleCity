using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellSettingsController
{
    private ECellType _eCellType;
    private EBlockType _eBlockType;
    private EBlockType _eBlockType2;
    private List<GameObject> _bricks;
    private List<GameObject> _concrete;
    private GameObject _water;
    private GameObject _forest;
    private GameObject _headquarters;
    private GameObject _ice;

    public CellSettingsController(ECellType eCellType, EBlockType eBlockType, EBlockType eBlockType2, List<GameObject> bricks, List<GameObject> concrete, GameObject water, GameObject forest, GameObject headquarters, GameObject ice)
    {
        _eCellType = eCellType;
        _eBlockType = eBlockType;
        _eBlockType2 = eBlockType2;
        _bricks = bricks;
        _concrete = concrete;
        _water = water;
        _forest = forest;
        _ice = ice;
        _headquarters = headquarters;
    }

    public void Apply()
    {
        Clear();
        SetCell();
    }

    private void SetCell()
    {
        switch(_eCellType)
        {
            case ECellType.Empty:
                break;
            case ECellType.Bricks:
                SetBlockType(_bricks, _eBlockType);
                break;
            case ECellType.Concrete:
                SetBlockType(_concrete, _eBlockType);
                break;
            case ECellType.BricksConcrete:
                SetBlockType();
                break;
            case ECellType.Forest:
                _forest.SetActive(true);
                break;
            case ECellType.Water:
                _water.SetActive(true);
                break;
            case ECellType.Ice:
                _ice.SetActive(true);
                break;
            case ECellType.Headquarters:
                _headquarters.SetActive(true);
                break;
        };
    }

    private void SetBlockType(List<GameObject> go, EBlockType BlockType)
    {
        switch(BlockType)
        {
            case EBlockType.Full:
                SetBlockActive(ref go, true, true, true, true);
                break;
            case EBlockType.HorizonUp:
                SetBlockActive(ref go, true, true, false, false);
                break;
            case EBlockType.HorizonDown:
                SetBlockActive(ref go, false, false, true, true);
                break;
            case EBlockType.VerticalLeft:
                SetBlockActive(ref go, true, false, true, false);
                break;
            case EBlockType.VerticalRight:
                SetBlockActive(ref go, false, true, false, true);
                break;
            case EBlockType.Diagonal1:
                SetBlockActive(ref go, true, false, false, true);
                break;
            case EBlockType.Diagonal2:
                SetBlockActive(ref go, false, true, true, false);
                break;
            case EBlockType.Type1:
                SetBlockActive(ref go, true, false, true, true);
                break;
            case EBlockType.Type2:
                SetBlockActive(ref go, true, true, true, false);
                break;
            case EBlockType.Type3:
                SetBlockActive(ref go, true, true, false, true);
                break;
            case EBlockType.Type4:
                SetBlockActive(ref go, false, true, true, true);
                break;
        };
    }
    private void SetBlockType()
    {
        SetBlockType(_bricks, _eBlockType);
        SetBlockType(_concrete, _eBlockType2);
    }
    private void SetBlockActive(ref List<GameObject> go, bool bloc1, bool bloc2, bool bloc3, bool bloc4)
    {
        go[0].SetActive(bloc1);
        go[1].SetActive(bloc2);
        go[2].SetActive(bloc3);
        go[3].SetActive(bloc4);
    }
    private void Clear()
    { 
        foreach(var GO in _bricks)
        {
            GO.SetActive(false);
        }
        foreach (var GO in _concrete)
        {
            GO.SetActive(false);
        }
        _water.SetActive(false);
        _forest.SetActive(false);
        _ice.SetActive(false);
        _headquarters.SetActive(false);
    }
}
