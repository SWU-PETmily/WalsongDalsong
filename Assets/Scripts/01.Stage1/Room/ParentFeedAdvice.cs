using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ParentFeedAdvice : MonoBehaviour
{
     public void ClickBtn()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Room1Scene");
    }
}
