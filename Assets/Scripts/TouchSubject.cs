using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchSubject : MonoBehaviour
{
    public GameObject dog;
    public GameObject ball;
    private ArrayList observers = new ArrayList();
    // Start is called before the first frame update
    void Start()
    {
        ReticleBehaviour PlacementIndicator = FindObjectOfType<ReticleBehaviour>();
        observers.Add(new DogSpawner(dog, PlacementIndicator));
        observers.Add(new BallSpawner(ball));
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began){
            foreach(TouchObserver observer in observers){
                observer.OnTouch();
            }
        }
    }

    public void Subscribe(TouchObserver observer){

    }
}
