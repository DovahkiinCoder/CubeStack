using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public bool isPlaying;
    public bool canMove;
    public float forwardSpeed;
    public float lerpSpeed;

    public GameObject failure;
    public GameObject finalimage;
    public GameObject finaltext;

    void FixedUpdate()
    {
        Hareket();
    }
    public void Hareket()
    {
        if (isPlaying)
        {
            MoveForward();
            canMove = true;
        }
        MoveSideWays();
    }



    private void MoveSideWays()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100) && canMove == true)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(hit.point.x, transform.position.y, transform.position.z), lerpSpeed * Time.deltaTime);
        }
    }

    private void MoveForward()
    {
        //rb.velocity = Vector3.forward * forwardSpeed;
        this.transform.Translate(0, 0, forwardSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Fail")
        {
            StackCube.instance.eksiltme = false;
            Debug.Log("Geldi");
            isPlaying = false;
            canMove = false;

            failure.SetActive(true);
        }
        if (other.gameObject.tag == "Final")
        {
            StackCube.instance.eksiltme = false;
            isPlaying = false;
            canMove = false;
            finalimage.SetActive(true);
            finaltext.SetActive(true);


        }

    }

}
