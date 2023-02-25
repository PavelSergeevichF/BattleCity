using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using static UnityEngine.Networking.UnityWebRequest;

public class Login : MonoBehaviourPunCallbacks
{
    [SerializeField] private SOPlayerData _sOPlayerData;
    [SerializeField] private SOGameData _sOGameData;

    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        _sOGameData.gameVersion = PhotonNetwork.AppVersion;
    }
    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.GameVersion = PhotonNetwork.AppVersion;
    }
    public void PhotonSetup()
    {
        PhotonNetwork.AuthValues = new AuthenticationValues(_sOGameData.PlayFabId);
        PhotonNetwork.NickName = _sOPlayerData.name;
    }

    public void Connect()
    {

        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.JoinRandomOrCreateRoom(roomName: $"Room N{Random.Range(0, 999)}");
        }
        else
        {
            PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.GameVersion = PhotonNetwork.AppVersion;
            PhotonNetwork.JoinRandomOrCreateRoom(roomName: $"Room N{Random.Range(0, 999)}");
        }
    }
    public override void OnConnected()
    {
        Debug.Log("OnConnected");
    }
    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        Debug.Log("OnConnectedToMaster() was called by PUN");
    }
    public override void OnCustomAuthenticationResponse(Dictionary<string, object> data)
    {
        foreach (KeyValuePair<string, object> kvp in data)
            Debug.Log($"key: {kvp.Key}/value: {kvp.Value}");
    }
    public override void OnCustomAuthenticationFailed(string debugMessage)
    {
        Debug.Log(debugMessage);
    }
    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(null, new Photon.Realtime.RoomOptions { MaxPlayers  =2 });
    }
    public override void OnCreatedRoom()
    {
        base.OnCreatedRoom();
    }
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        PhotonNetwork.LoadLevel(3);
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
    }
}
