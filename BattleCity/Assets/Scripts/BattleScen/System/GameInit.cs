using Photon.Realtime;
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

internal sealed class GameInit
{
    public GameInit(Controllers controllers, GameControllerView mainController)
    {

        InitSingleton(controllers);
        
        UIBattleController uIBattleController = new UIBattleController(mainController.UIBattleView, mainController.SOPlayerData);
        controllers.Add(uIBattleController);

        PlayerController playerController = new PlayerController(mainController.GreedView, mainController.SpawnPlayerView, mainController.UIBattleView, uIBattleController, mainController.JoysticView);
        controllers.Add(playerController);

        SpavnEnemyController spavnEnemyController = new SpavnEnemyController(mainController.GreedView, mainController.SpawnEnemyView, mainController.UIBattleView);
        controllers.Add(spavnEnemyController);

    }

    private void InitSingleton(Controllers controllers)
    {
        //controllers.Add(SoundManager.Instance);
        //controllers.Add(Singleton<SingletonManager>.Instance);
    }
}
