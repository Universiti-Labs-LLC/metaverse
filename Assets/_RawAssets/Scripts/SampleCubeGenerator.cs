using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleCubeGenerator : MonoBehaviour
{
    public GameObject prefab_SampleCube;

    private void Start()
    {
        generateCube();
    }

    private void generateCube()
    {
        for (int j = 0; j < 100; j++)
        {
            for (int i = 0; i < 100; i++)
            {
           
                GameObject go = Instantiate(prefab_SampleCube, prefab_SampleCube.transform,this.transform);

                go.transform.SetParent(this.transform);
                go.transform.localPosition = new Vector3(i * 60f, 0f, j * 60f);
            }
        }

    }
}
