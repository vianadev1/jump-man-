using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barril : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] GameObject padre;
    public GameObject[] cantidad = new GameObject [2];
    public int barriles = 0;
    public float tiempo =  0;
    int ramdom;

    // Start is called before the first frame update
    void Start()
    {
        
        //Instantiate(prefab, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        tiempo += Time.deltaTime;

        if (tiempo > 1 && barriles <= 3  ) // instacia barriles cada tres segundos 
        {

            //cantidad[i] = Instantiate(prefab) as GameObject;
            //cantidad[barriles] = Instantiate(prefab, transform.position, transform.rotation);
            //cantidad[barriles].transform.parent = padre.transform;
            //cantidad [barriles].name = "1" ;
            barriles++;
            GameObject tarro = barrilpool.Instance.llamadabarril();
            tarro.transform.position = padre.transform.position;

            tiempo = 0;
        }
        
        if (barriles >= 3)
        {
            barriles = 0;
        }
        //Destroy(cantidad[barriles], 1.1f)   
    }


}
