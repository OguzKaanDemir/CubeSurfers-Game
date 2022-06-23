using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Catcher : MonoBehaviour
{
    GameObject mainCube;
    public int height;

    void Start()
    {
        mainCube = GameObject.Find("MainCube");
    }

    void Update()
    {
        //mainCube.transform.position = new Vector3(transform.position.x, height + 1, transform.position.z);
        mainCube.transform.DOMoveY(height + 1, .5f);
        this.transform.localPosition = new Vector3(0, -height, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Catch" && other.gameObject.GetComponent<CatchableCube>().GetIsAdded() == false) 
        {
            print("aldý");
            height += 1;
            other.gameObject.GetComponent<CatchableCube>().MakeAdded();
            other.gameObject.GetComponent<CatchableCube>().SetIndex(height);
            other.gameObject.GetComponent<CatchableCube>().transform.parent = mainCube.transform;
        }
    }
}
