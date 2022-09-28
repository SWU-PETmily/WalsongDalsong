using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NamingStart : MonoBehaviour
{
    public void Change()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("NamingScene");
    }
}