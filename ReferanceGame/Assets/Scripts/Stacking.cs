using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stacking : MonoBehaviour
{
    public int score = 0;
    public Text showScore;

    GameObject basecube;
    public int height;

    // Start is called before the first frame update
    void Start()
    {
        basecube = GameObject.Find("BaseCube");
    }

    // Update is called once per frame
    void Update()
    {
        basecube.transform.position = new Vector3(transform.position.x, height + 1, transform.position.z);
        this.transform.localPosition = new Vector3(0, -height, 0);
    }


    public void DecreaseHeight()
    {
        height--;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Topla" && other.gameObject.GetComponent<StackCube>().GetIsStacking() == false)
        {
            height += 1;
            other.gameObject.GetComponent<StackCube>().MakeStack();
            other.gameObject.GetComponent<StackCube>().CalculateIndex(height);
            other.gameObject.transform.parent = basecube.transform;

            score++;
            showScore.text = "x" + score;



        }
    }

}
