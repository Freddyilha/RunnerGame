using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementBehaviour : MonoBehaviour
{
    private Rigidbody rgbd;
    private Animator anim;
    private Transform characterPos;
    private Vector3 actualPosition;
    private Vector3 newPos;
    [SerializeField] private PlayerData testData;
    private PlayerPrefs playerInfo;

    // Start is called before the first frame update
    void Start()
    {
        rgbd = GetComponent<Rigidbody>();
        characterPos = GetComponent<Transform>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("axis: " + Input.GetAxis("Horizontal"));
        actualPosition = characterPos.transform.position;
        //Debug.Log("ActualPosition" + actualPosition);
        if (Input.GetAxis("Horizontal") < -0.1)
        {
            anim.SetBool("Moving", true);
            rgbd.MovePosition(actualPosition + new Vector3(0.1f,0f,0f));
        }
        else if (Input.GetAxis("Horizontal") > 0.1)
        {
            anim.SetBool("Moving", true);
            characterPos.rotation.Set(characterPos.rotation.x, -87f, characterPos.rotation.z, characterPos.rotation.w);
            rgbd.MovePosition(actualPosition - new Vector3(0.1f, 0f, 0f));
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            //rgbd.AddForce(Vector3.up*25);
            rgbd.MovePosition(actualPosition + new Vector3(0f, 0.1f, 0f));
        }
        else if (rgbd.velocity.magnitude <= 0.7f)
        {
            anim.SetBool("Moving", false);
        }
        //anim.SetBool("Moving", false);

    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    Debug.Log("Tag: " + other.tag);
    //    if (other.tag == "endGameTrigger")
    //    {
    //        EndlessRunningGameManangerBehaviour.instance.onPlayerFall();
    //    }
        
    //}


}
