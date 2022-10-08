using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    public Transform Target;

    public RenderTexture[] Minimap_RenderTexture;

    //public static MiniMap instance;

    private void Awake()
    {
        //if(instance == null)
        //{
        //    instance = this;
        //}
        //else
        //{
        //    Destroy(this.gameObject);
        //}
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (UIManager.instance.FullMap_Image.gameObject.activeInHierarchy == false)
            {
                EnableFullMap(true);
            }
            else
            {
                EnableFullMap(false);
            }
        }
    }

    private void LateUpdate()
    {
        this.transform.position = new Vector3(Target.position.x, this.transform.position.y, Target.position.z); 
    }

    public void SetTarget(Transform _target)
    {
        Target = _target;
        UIManager.instance.MiniMap_Image.SetActive(true);
    }

    public void EnableFullMap(bool _status)
    {
        if(_status == true)
        {
            UIManager.instance.FullMap_Image.gameObject.SetActive(true);

            UIManager.instance.MiniMap_Image.gameObject.SetActive(false);

            this.GetComponent<Camera>().targetTexture = Minimap_RenderTexture[0];
            this.GetComponent<Camera>().orthographicSize = 55f;
        }
        else
        {
            UIManager.instance.FullMap_Image.gameObject.SetActive(false);

            UIManager.instance.MiniMap_Image.gameObject.SetActive(true);

            this.GetComponent<Camera>().targetTexture = Minimap_RenderTexture[1];
            this.GetComponent<Camera>().orthographicSize = 20f;

        }
    }
}
