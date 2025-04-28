using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void OnClickStart()
    {
        SceneManager.LoadScene("InGame"); 
    }

    public void OnClickLobby()
    {
        SceneManager.LoadScene("Lobby");
    }
}