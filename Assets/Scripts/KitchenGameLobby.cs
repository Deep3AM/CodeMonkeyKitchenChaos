using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Lobbies;
using Unity.Services.Lobbies.Models;
using UnityEngine;

public class KitchenGameLobby : MonoBehaviour
{
    public static KitchenGameLobby Instance{ get; private set; }
    private Lobby joinedLobby;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private async void InitializeUnityAuthentication()
    {
        if(UnityServices.State != ServicesInitializationState.Initialized)
        {
            InitializationOptions initializationOptions = new InitializationOptions();
            initializationOptions.SetProfile(Random.Range(0, 10000).ToString());

            await UnityServices.InitializeAsync();
            await AuthenticationService.Instance.SignInAnonymouslyAsync();
        }
    }
    public async void CreateLobby(string lobbyName, bool isPrivate)
    {
        try
        {
            joinedLobby = await LobbyService.Instance.CreateLobbyAsync(lobbyName, KitchenGameMultiplayer.MAX_PLAYER_COUNT, new CreateLobbyOptions
            {
                IsPrivate = isPrivate,
            });
            KitchenGameMultiplayer.Instance.StartHost();
            Loader.LoadNetwork(Loader.Scene.CharacterSelectScene);
        }
        catch(LobbyServiceException e)
        {
            Debug.Log(e);
        }

    }
    public async void QuickJoin()
    {
        try
        {
            joinedLobby = await LobbyService.Instance.QuickJoinLobbyAsync();
            KitchenGameMultiplayer.Instance.StartClient();
        }
        catch(LobbyServiceException e)
        {
            Debug.Log(e);
        }
        
    }
}
