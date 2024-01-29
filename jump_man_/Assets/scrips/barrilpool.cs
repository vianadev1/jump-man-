using System.Collections.Generic;
using UnityEngine;

public class barrilpool : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    private int poolsize =7;
    [SerializeField] private List<GameObject> barriles; // lstas 

    private static barrilpool instance;
    public static barrilpool Instance { get { return instance; }  }  // patron sgleto toon 
    // Start is called  before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        Addbarril(poolsize);
    }

    private void Addbarril( int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject unbarril = Instantiate(prefab, transform.position, transform.rotation);
            unbarril.SetActive(false);
            barriles.Add(unbarril);
            //INSTACIAAR EN UN PADRE 
        }
    }

    public  GameObject llamadabarril()
    {
        for (int i = 0; i < barriles .Count; i++)
        {
            if (!barriles[i].activeSelf) // que no este activo 
            {
                barriles[i].SetActive(true);
                return barriles[i];
            }

        }

        return null;
    }
}
