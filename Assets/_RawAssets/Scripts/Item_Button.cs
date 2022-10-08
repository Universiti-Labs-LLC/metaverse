using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item_Button : MonoBehaviour
{
    public string item_type;
    private void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(onClickButton);
        SetIcon();
        //avatar.ClearSlots();
    }
    private void OnEnable()
    {
        SetIcon();
    }
    private void SetIcon()
    {
        int gender = ServerManager.instance.gender;
        for (int i = 0; i < this.transform.childCount; i++)
        {
            if (i == gender)
            {
                this.transform.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                this.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
    public void onClickButton()
    {
        //PlayerModel.instance.SetItem(item_type, recipe[GameManager.instance.current_gender]);
    }
}
