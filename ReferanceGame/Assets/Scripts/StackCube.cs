using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StackCube : MonoBehaviour
{

    public static StackCube instance;


    void Awake()
    {
        instance = this;
    }


    public bool eksiltme = true;
    bool isStacking;
    int index;

    public Stacking stacking;


    void Start()
    {
        isStacking = false;
    }


    void Update()
    {
        if (isStacking == true)
        {
            if (transform.parent != null)
            {
                transform.localPosition = new Vector3(0, -index, 0);

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (eksiltme)
        {
            if (other.gameObject.tag == "Fail")
            {
                stacking.DecreaseHeight();
                transform.parent = null;
                GetComponent<BoxCollider>().enabled = false;
                other.gameObject.GetComponent<BoxCollider>().enabled = false;

                int yukseklik = stacking.score--;
                Debug.Log(yukseklik);
                stacking.showScore.text = "x" + stacking.score;
            }
        }

    }

    public bool GetIsStacking()
    {
        return isStacking;
    }
    public void MakeStack()
    {
        isStacking = true;
    }

    public void CalculateIndex(int index)
    {
        this.index = index;
    }


}
