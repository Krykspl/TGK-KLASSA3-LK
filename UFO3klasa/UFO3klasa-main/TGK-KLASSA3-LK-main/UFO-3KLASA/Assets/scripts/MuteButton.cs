using UnityEngine;

public class MuteButton : MonoBehaviour
{
    public void OnMuteButtonClicked()
    {
        AudioListener.volume = 0;
    }
}
