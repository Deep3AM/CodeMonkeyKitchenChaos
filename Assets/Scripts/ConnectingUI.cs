using UnityEngine;

public class ConnectingUI : MonoBehaviour
{ 
    void Start()
    {
        KitchenGameMultiplayer.Instance.OnTryingJoinGame += KitchenGameMultiplayer_OnTryingJoinGame;
        KitchenGameMultiplayer.Instance.OnFailedToJoinGame += KitchenGameMultiplayer_OnFailedToJoinGame;
    }

    private void KitchenGameMultiplayer_OnFailedToJoinGame(object sender, System.EventArgs e)
    {
        Hide();
    }

    private void KitchenGameMultiplayer_OnTryingJoinGame(object sender, System.EventArgs e)
    {
        Show();
    }
    private void Show()
    {
        gameObject.SetActive(true);
    }
    private void Hide()
    {
        gameObject.SetActive(false);
    }
    private void OnDestroy()
    {
        KitchenGameMultiplayer.Instance.OnTryingJoinGame -= KitchenGameMultiplayer_OnTryingJoinGame;
        KitchenGameMultiplayer.Instance.OnFailedToJoinGame -= KitchenGameMultiplayer_OnFailedToJoinGame;
    }
}
