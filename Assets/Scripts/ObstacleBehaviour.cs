using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehaviour : MonoBehaviour
{
    private Rigidbody rgbd;
    private Vector3 actualPosition;
    private Transform characterPos;

    // Start is called before the first frame update
    void Start()
    {
        rgbd = GetComponent<Rigidbody>();
        characterPos = GetComponent<Transform>();
        if (gameObject.tag == "obstacleBall")
        {
            //rgbd.AddForce(new Vector3(0.05f, 0f, 0.05f));
            rgbd.AddForce((Vector3.forward * 12) + Vector3.right * 20);
            //rgbd.AddForce(new Vector3(0.1f, 0f, 0.1f) * 20);
            //rgbd.MovePosition(actualPosition + new Vector3(0.05f, 0f, 0.05f));
        }
    }

    // Update is called once per frame
    void Update()
    {
        actualPosition = characterPos.transform.position;

        if (gameObject.tag == "obstacleBall")
        {
           
        }
        else
        {
            rgbd.MovePosition(actualPosition + new Vector3(0f, 0f, 0.05f));
        }
        

        if (actualPosition.z >= 10f)
        {
            EndlessRunningGameManangerBehaviour.instance.removeObstacleFromList();
            Destroy(gameObject);
        }
            
    }

    public void OnTriggerExit(Collider other)
    {
        //Debug.Log("Tag: " + other.tag);
        //Debug.Log("me: " + gameObject.tag);
        EndlessRunningGameManangerBehaviour.instance.addScore(50);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("colidiu: " + collision.collider.tag);
        if (collision.collider.tag == "leftWall")
        {
            //Debug.Log("Entrei");
            rgbd.transform.Rotate(Vector3.forward + Vector3.left);
            //rgbd.AddForce(Vector3.forward + Vector3.left * 20);
        }
        else if (collision.collider.tag == "rightWall")
        {
            rgbd.transform.Rotate(Vector3.forward + Vector3.right);
            //rgbd.AddForce(Vector3.forward + Vector3.right * 20);
        }
    }

}
