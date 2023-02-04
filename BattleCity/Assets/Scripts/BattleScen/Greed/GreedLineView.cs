using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreedLineView : MonoBehaviour
{
    [SerializeField] private List<CellView> _cellViews;

    public List<CellView> CellViews => _cellViews;
}
