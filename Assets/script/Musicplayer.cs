using UnityEngine;

public class Musicplayer : MonoBehaviour
{
    private void Start()
    {
        int numofMusicPlayers = FindObjectsByType<Musicplayer>(FindObjectsSortMode.None).Length;

        if(numofMusicPlayers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
