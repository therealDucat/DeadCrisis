using UnityEngine;
using System.Collections;
using Steamworks;

public class SteamTest : MonoBehaviour
{
    Callback m_GameOverlayActivated;

/*    void Start()
    {
        if (!SteamManager.Initialized) { return; }

        string name = SteamFriends.GetPersonaName();
        Debug.Log(name);
    }
*/
    private void OnEnable() {
        if (SteamManager.Initialized)
            m_GameOverlayActivated = new Callback<GameOverlayActivated_t>(OnGameOverlayActivated);
    }

    private void OnGameOverlayActivated(GameOverlayActivated_t pCallback) {
        if (pCallback.m_bActive != 0)
            Time.timeScale = 0;
        else 
            Time.timeScale = 1;
    }

}
