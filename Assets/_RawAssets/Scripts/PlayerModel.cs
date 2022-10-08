using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Cameras;
using Photon.Pun;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityEngine.AI;

public class PlayerModel : MonoBehaviour
{
    // Start is called before the first frame update
    public PhotonView view;
    public TextMesh PlayerName;
    public static PlayerModel instance;
    public ThirdPersonCharacter controller;
    public ThirdPersonUserControl user_control;
    public NavMeshAgent _navAgent;
    [Header("Components")]
    public Rigidbody rb;
    private void Awake()
    {
        instance = this;
        //PhotonView
        view = this.GetComponent<PhotonView>();
        user_control= this.GetComponent<ThirdPersonUserControl>();
        controller = this.GetComponent<ThirdPersonCharacter>();
        rb = this.GetComponent<Rigidbody>();
        _navAgent = this.GetComponent<NavMeshAgent>();
    }

    [PunRPC]
    public void TurnOnAnimation()
    {
        // Changing the name.
        this.gameObject.SetActive(true);
        SetName();
        // Changing the layer from Local to Default.
        this.gameObject.layer = 0;
        // Changing the position.
        this.transform.parent.position = new Vector3(-24f, 50f, -35f);
        // Turning on the controllers and gravity. 
        //user_control.enabled = true;
        //controller.enabled = true;
        rb.useGravity = true;
        rb.isKinematic = true;
        // Changing the parent of the current gameObject.
        //this.transform.SetParent(GameObject.FindGameObjectWithTag("Respawn").transform);
        this.transform.SetParent(null);
        DontDestroyOnLoad(this.gameObject);
       
        SetCamera();
        //Invoke("SetCamera", 2f);
        //camera.enabled = true;

        Coroutine _resetNavmesh = StartCoroutine(resetNavMesh());
    }
        
    
    public void SetName()
    {
        // Setting the name of the player from UIManager.
        PlayerName.text = view.Owner.NickName;
        this.name = view.Owner.NickName;
    }
    private void SetCamera()
    {

        if(view.IsMine)
        {
            Transform Controller = GameObject.FindGameObjectWithTag("Controller").transform;

            this.transform.SetParent(Controller);
            this.transform.localPosition = new Vector3(0f,-1f,-0.5f);
            this.transform.localEulerAngles = Vector3.zero;
            //GameObject.FindGameObjectWithTag("Player_Camera").GetComponent<FreeLookCam>().SetTarget(this.transform);
            //GameObject.FindGameObjectWithTag("MiniMap").GetComponent<MiniMap>().SetTarget(this.transform);
        }

    }
    public void SetItem(string type)
    {
       

    }

    private IEnumerator resetNavMesh()
    {
        yield return new WaitForSeconds(1f);
        _navAgent.enabled = false;
        yield return new WaitForSeconds(3f);
        _navAgent.enabled = true;
    }
}
