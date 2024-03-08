using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCreate : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject FinishLine;
    public GameObject[] Gates;
    public GameObject Enemy;
    public GameObject prefap;
    public GameObject prefap1;
    public GameObject prefap2;
    public GameObject prefap3;

    /*
     * Default Vector3
    public Vector3 vec1 = new Vector3(-1.79999995f, 1, 20.5f);
    public Vector3 vec2 = new Vector3(2.20000005f, 1, 39.75f);
    public Vector3 vec3 = new Vector3(3.25999999f, 5.96000004f, 56.9300003f);
    public Vector3 vec4 = new Vector3(2.29999995f, 1, 89);
    */
    //enemy Vector3
    //Vector3(-0.109999999,0.0868704915,115.487305)
    public void Start()
    {
        

        GameObject prefap6 = Instantiate(FinishLine);
        prefap6.transform.position = new Vector3(0.27f, 1f, 158.57f);

        prefap = Instantiate(Gates[0]);
        prefap1 = Instantiate(Gates[1]);
        prefap2 = Instantiate(Gates[2]);
        prefap3 = Instantiate(Gates[0]);

        prefap.transform.position = new Vector3(-1.79999995f, 1, 20.5f);

        prefap1.transform.position = new Vector3(2.20000005f, 1, 39.75f);

        prefap2.transform.position = new Vector3(3.25999999f, 5.96000004f, 56.9300003f);

        prefap3.transform.position = new Vector3(2.29999995f, 1, 89);



    }

    // Update is called once per frame
    void Update()
    {

      

    }
}
