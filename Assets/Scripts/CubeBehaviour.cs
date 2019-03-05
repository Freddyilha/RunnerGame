using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehaviour : MonoBehaviour
{
    private Rigidbody rgbd;
    private Animator anim;
    private Transform characterPos;
    private Vector3 actualPosition;
    private Vector3 newPos;
    private bool grounded;
    [Range(0, 5)][SerializeField] private int jumpForce;
    [SerializeField] private ParticleSystem deathParticles;
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
            rgbd.MovePosition(actualPosition + new Vector3(0.1f,0f,0f));
        }
        else if (Input.GetAxis("Horizontal") > 0.1)
        {
            rgbd.MovePosition(actualPosition - new Vector3(0.1f, 0f, 0f));
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //Debug.Log("cliquei");
            //anim.Play("Jump");
            if (grounded == true)
            {
                rgbd.AddForce(Vector3.up * 100 * jumpForce);
                anim.SetTrigger("Jumped");
                grounded = false;
                
            }
        }

    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    Debug.Log("Tag: " + other.tag);
    //    //if (other.tag == "endGameTrigger")
    //    //{
    //    //    EndlessRunningGameManangerBehaviour.instance.onPlayerFall();
    //    //}
    //}

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Tag: " + collision.collider.tag);
        if (collision.collider.tag == "floor")
        {
            grounded = true;
        }
        if (collision.collider.tag == "obstacleBigWall" ||
            collision.collider.tag == "obstacleBall" ||
            collision.collider.tag == "obstacleHorizontalCylinder"
            )
        {
            deathParticles.Play();
            EndlessRunningGameManangerBehaviour.instance.onPlayerDeath();
            characterPos.transform.position = new Vector3(-2.439f, 1.402f, 8.152f);
        }

        
        //Debug.Log("name: " + collision.collider.tag);
    }
}
