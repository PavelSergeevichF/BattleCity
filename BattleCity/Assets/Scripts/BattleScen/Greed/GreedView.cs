using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreedView : MonoBehaviour
{
    [SerializeField] private List<GreedLineView> _lineViews;

    public List<GreedLineView> LineViews => _lineViews;
}