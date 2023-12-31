using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GestorDeRede : MonoBehaviourPunCallbacks
{
    public dadosPersonagem dados = null; 
    public TextMeshProUGUI compTexto;
    public GameObject playerdavez;
    
    private void Awake()
    {
        Debug.Log("Conectando ao servidor.");
        dados = GameObject.Find("coletadados").GetComponent<dadosPersonagem>();
        PhotonNetwork.NickName = dados.nomejogador;
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster(){
        Debug.Log("Conexao bem sucedida.");

        if(PhotonNetwork.InLobby == false){
            Debug.Log("Entrando no Lobby.");
            PhotonNetwork.JoinLobby();
        }
    }

    public override void OnJoinedLobby() {
        Debug.Log("Entrei no Lobby.");
        Debug.Log("Entrando na sala.");
        PhotonNetwork.JoinRoom("GameTeste");
    }

    public override void OnJoinRoomFailed(short returnCode, string message){
        Debug.Log("Erro ao entrar na sala: " + message + " código: " + returnCode);

        if(returnCode == ErrorCode.GameDoesNotExist){
            Debug.Log("Criando sala.");
            RoomOptions roomOptions = new RoomOptions{ MaxPlayers = 20 };
            PhotonNetwork.CreateRoom("GameTeste", roomOptions, null);
        }
    }

    public override void OnLeftRoom(){
        Debug.Log("Você saiu da sala.");
    }

    public override void OnJoinedRoom() {
        Debug.Log("Entrou na sala GameTeste. User: " + PhotonNetwork.LocalPlayer.NickName);
        Vector2 pos = new Vector2(5,10);
        Debug.Log("Personagem: "+ dados.personagem);
        if (dados.personagem == "capi"){
            Debug.Log("Personagem: capicapi");
            GameObject _player = PhotonNetwork.Instantiate("capybara", pos, Quaternion.Euler(Vector2.up));
            _player.GetComponent<PhotonView>().RPC("SetNickname", RpcTarget.All, PhotonNetwork.LocalPlayer.NickName);
            playerdavez = _player;
        }else{
            Debug.Log("Personagem: dinossauroteste");
            GameObject _player = PhotonNetwork.Instantiate("velociraptor", pos, Quaternion.Euler(Vector2.up));
            _player.GetComponent<PhotonView>().RPC("SetNickname", RpcTarget.All, PhotonNetwork.LocalPlayer.NickName);
            playerdavez = _player;
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer){
        Debug.Log("Um jogador entrou na sala GameTeste. User: " + newPlayer.NickName);
        playerdavez.GetComponent<PhotonView>().RPC("SetNickname", RpcTarget.All, PhotonNetwork.LocalPlayer.NickName);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer){
        Debug.Log("Um jogador saiu da sala GameTeste. User: " + otherPlayer.NickName);
    }
}
