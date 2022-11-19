using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitTest : MonoBehaviour
{
    public Text txtHome;
    public Text txtEscape;
    public Text txtMenu;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        txtHome.text = PlayerPrefs.GetString("quitTest");
        /*
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Home))
            {
                // home button
                txtHome.text = "home";
            }
            else if (Input.GetKey(KeyCode.Escape))
            {
                // back button
                txtEscape.text = "back";
            }
            else if (Input.GetKey(KeyCode.Menu))
            {
                // menu button
                txtMenu.text = "menu";
            }
        }
        */
    }


    void OnApplicationQuit()

    {
        PlayerPrefs.SetString("quitTest", "quitSuccess");
        Application.CancelQuit();

#if !UNITY_EDITOR

        System.Diagnostics.Process.GetCurrentProcess().Kill();

#endif

    }
}