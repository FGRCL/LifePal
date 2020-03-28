using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{

    public GameObject dog;
    private ReticleBehaviour PlacementIndicator;

    // Start is called before the first frame update
    void Start()
    {
        PlacementIndicator = FindObjectOfType<ReticleBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began){
            GameObject obj = Instantiate(dog, PlacementIndicator.transform.position, PlacementIndicator.transform.rotation * Quaternion.Euler(Vector3.up * 180));
        }
    }
}
