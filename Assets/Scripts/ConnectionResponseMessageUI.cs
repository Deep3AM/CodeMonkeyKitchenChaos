using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class ConnectionResponseMessageUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI messageText;
    [SerializeField] private Button closeButton;
    private void Awake()
    {
        closeButton.onClick.AddListener(Hide);
    }
    void Start()
    {
        KitchenGameMultiplayer.Instance.OnFailedToJoinGame += KitchenGameMultiplayer_OnFailedToJoinGame;
    }

    private void KitchenGameMultiplayer_OnFailedToJoinGame(object sender, System.EventArgs e)
    {
        Show();
        messageText.text = NetworkManager.Singleton.DisconnectReason;
        if (messageText.text == "")
        {
            messageText.text = "Failed To Connect";
        }
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
        KitchenGameMultiplayer.Instance.OnFailedToJoinGame -= KitchenGameMultiplayer_OnFailedToJoinGame;
    }
}
