using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cycle : MonoBehaviour
{
    public float hiz;
    public Transform[] hareketNokta;
    Vector3 hedefNokta;
    int indexNo;

    void Start()
    {
        hedefNokta = hareketNokta[indexNo].position;
    }


    void Update()
    {
        if (transform.position != hedefNokta)
        {
            transform.position = Vector3.MoveTowards(transform.position, hedefNokta, Time.deltaTime * hiz);
        }
        else
        {
            indexNo++;
            if (indexNo >= hareketNokta.Length)
            {
                indexNo = 0;
            }
            hedefNokta = hareketNokta[indexNo].position;
        }
    }
}
