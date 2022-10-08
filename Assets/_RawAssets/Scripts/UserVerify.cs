using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UserVerify : MonoBehaviour
{

    public TMP_InputField username;
    public TMP_InputField password;

    private string stored_username = "Universiti.net";
    private string stored_Password = "Universiti.net";

    public void Join()
    {
        if(password.text == stored_Password && username.text == stored_username )
        {
            SceneManager.LoadScene(1);
        }
    }

}
