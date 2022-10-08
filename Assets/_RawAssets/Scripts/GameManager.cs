using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject model;
    public int current_gender=0;
    public string[] gender_type;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangePlayerRace(int index)
    {
        current_gender = index;
    }
   
}
