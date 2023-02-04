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
        //SceneLoadingHandler sceneLoader = new SceneLoadingHandler(Singleton<ScenesManager>.Instance.SceneLoaderData, SceneLoaderCommunicatorKeeper.GetContext());
        //sceneLoader.LoadNextScene();

        //Data.Data data = sceneLoader.SceneData.Data;
        //MapView mapView = sceneLoader.CurrentMapView.GetComponent<MapView>();

        //InitDataDrivenSingleton(data, mainController, sceneLoader, controllers);
        //SoundManager.Instance.SetSoundsSystemData(data.SoundsSystemData);


        //mapView.GridController.SetUp(data.FlowfieldPathfindingData);

        PlayerController playerController = new PlayerController(mainController.GreedView, mainController.SpawnPlayerView);
        controllers.Add(playerController);

        EnemyController enemyController = new EnemyController(mainController.GreedView, mainController.SpawnEnemyView);
        controllers.Add(enemyController);

        UIBattleController uIBattleController = new UIBattleController(mainController.UIBattleView, mainController.SOPlayerData);
        controllers.Add(uIBattleController);

        //UIController uiController = new UIController(data.UiData);
        //uiController.Spawn();
        //controllers.Add(uiController);

        //Player.Player player =
        //    new Player.Player(data.PlayerData, uiController,
        //        playerExpObservable, data.StatusSystemSettingsData, deathScreenController); //clean

        //player.Spawn(mapView.PlayerSpawnPos, uiController.UseButtonView);

        //if (!Singleton<PlayerSaveMachine>.Instance.PlayerStatsMultipliersUsed && !Singleton<PlayerSaveMachine>.Instance.PlayerStatsMultipliersEmpty)
        //    player.PlayerStatsManager.SetMultipliers(Singleton<PlayerSaveMachine>.Instance.GetPlayerStatsMultipliers());

        //EnemySpawnController spawnController =
        //    new EnemySpawnController(data.EnemiesData, mapView.EnemySpawnPoses, data.FogOfWarData, uiController);
        //controllers.Add(spawnController);

        //SoundManager.Instance.SetMusicController(new MusicController(), EMixerGroupType.Music);
        //SoundManager.Instance.MusicController.SetSounds(data.SoundsSystemData.Musics);
        //AudioSourseHandler handler = new AudioSourseHandler(new GameObject(MusicController.SoundPlayerName));
        //controllers.Add(handler);
        //SoundManager.Instance.MusicController.SetAudioSource(handler.AudioSourse);

        //spawnController.OnEnemiesSpawned += () =>
        //{
        //    aiManager.Add(spawnController.GetEnemyList());
        //    spawnController.SetPlayer(player);
        //};

        //spawnController.OnEnemySpawned += enemy =>
        //{
        //    enemy.OnGiveExp += (_, count) => player.PlayerExpControl.AddExp(count);
        //    playerExpObservable.Add—aller(enemy);
        //    trophyObservable.Add—aller(enemy);
        //};

        //spawnController.SpawnEnemies();
    }

    private void InitSingleton(Controllers controllers)
    {
        //controllers.Add(SoundManager.Instance);
        //controllers.Add(Singleton<SingletonManager>.Instance);
    }
}
