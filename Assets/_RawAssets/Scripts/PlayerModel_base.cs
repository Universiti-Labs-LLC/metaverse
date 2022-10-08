using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel_base : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    public PlayerModel getPlayerModelByGender(int index)
    {
        return this.transform.GetChild(index).GetComponent<PlayerModel>();
    }
    public void ChangeGender(int index)
    {
        for (int i = 0; i<this.transform.childCount;i++)
        {
            if(i==index)
            {
                this.transform.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                this.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}
