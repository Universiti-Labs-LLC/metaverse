using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public InputField Name_Inputfield;
    [Header("RadioButton")]
    public GameObject toggle_Panel;
    public Toggle toggle_Male;
    public Toggle toggle_Female;
    public Toggle toggle_Neutral;
    [Header("PlayerModel")]
    [Header("Panels")]
    public GameObject Home_Panel;
    public GameObject WarningPanel;
    public GameObject Selection_Panel;
    public GameObject Character_Panel;
    public GameObject Clothes_Panel;
    public GameObject Items_Panel;
    public GameObject LoadingPanel;
    public GameObject Menu_HomePanel;
    [Header("Item_Panels")]
    public GameObject Beard_Panel;
    public GameObject Hair_Panel;
    public GameObject Shirt_Panel;
    public GameObject Pants_Panel;
    public GameObject Hat_Panel;
    public GameObject Glasses_Panel;
    [Header("Text")]
    public Text Loading_Text;
    [Header("Images")]
    public Image LoadingBar;
    public GameObject MiniMap_Image;
    public GameObject FullMap_Image;
    [Header("Canvases")]
    public GameObject Menu_UI;
    public GameObject Level_UI;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        StartCoroutine(Animation_LoadingText());
        StartCoroutine(Animation_LoadingBar());
    }

    void Update()
    {
       
    }
    public void onClickMenu_CharacterButton()
    {
        Selection_Panel.SetActive(false);
        Character_Panel.SetActive(true);
    }
    public void onClick_Submit_Button()
    {
        if(Name_Inputfield.text!="" && toggle_Panel.GetComponent<ToggleGroup>().AnyTogglesOn())
        {

            PlayerPrefs.SetString("localPlayer_Name", Name_Inputfield.text);
            ServerManager.instance.join();
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            WarningPanel.SetActive(true);
        }
    }
  
    public void onClick_WarningPanel_OnCloseButton()
    {
        WarningPanel.SetActive(false);
    }
    public IEnumerator Animation_LoadingText()
    {
        Loading_Text.text = "Loading";
        int temp = 0;
        while(temp<4)
        {
            Loading_Text.text = Loading_Text.text + ".";
            temp++;
            yield return new WaitForSeconds(0.5f);
        }
        StartCoroutine(Animation_LoadingText());
    }
    public IEnumerator Animation_LoadingBar()
    {
        LoadingBar.fillAmount += 0.002f;
        yield return new WaitForSeconds(0.01f);
        if (LoadingBar.fillAmount == 1f)
        {
            LoadingPanel.SetActive(false);
            Home_Panel.SetActive(true);
            ServerManager.instance.join();
        }
        else
        {
            StartCoroutine(Animation_LoadingBar());
        }
    }
    public void onClick_genderToggle()
    {
        TurnOnMenuButtons();
        Toggle[] toggles = toggle_Panel.GetComponentsInChildren<Toggle>();
        //GameManager.instance.model.SetActive(true);
        for(int i =0;i< toggles.Length;i++)
        {
            if (toggles[i].isOn)
            {
                ServerManager.instance.localPlayer.ChangeGender(i);
                ServerManager.instance.gender = i;
                //ServerManager.instance.localPlayer.ChangeGender(i);
            }
        }
    }
    private void TurnOnMenuButtons()
    {
        Button[] buttons = Menu_HomePanel.GetComponentsInChildren<Button>();
        foreach (Button button in buttons)
        {
            button.interactable = true;
        }
    }
    public void ChangeCanvas(string name)
    {
        switch (name)
        {
            case "Menu": Menu_UI.gameObject.SetActive(true);
                        Level_UI.gameObject.SetActive(false);break;
            case "Level": Level_UI.gameObject.SetActive(true);
                Menu_UI.gameObject.SetActive(false);break;
            default:
                break;
        }
    }
}
