using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchSubject : MonoBehaviour
{
    private ArrayList<TouchObserver> observers;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began){
            foreach(TouchObserver observer in observers){
                observer.notify();
            }
        }
    }

    public void Subscribe(TouchObserver observer){

    }
}
