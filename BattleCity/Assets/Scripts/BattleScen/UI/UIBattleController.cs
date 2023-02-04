using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBattleController : IExecute
{
    private UIBattleView _uIBattleView;
    private SOPlayerData _sOPlayerData;

    public UIBattleController(UIBattleView uIBattleView, SOPlayerData sOPlayerData)
    {
        _uIBattleView = uIBattleView;
        _sOPlayerData = sOPlayerData;
        _uIBattleView.Level.text = _sOPlayerData.Level.ToString();
    }

    public void Execute()
    {
        GetDataLive();
    }
    private void GetDataLive()
    {
        _uIBattleView.Live.text = _sOPlayerData.Live.ToString();
    }
}
