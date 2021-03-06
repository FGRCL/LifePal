using UnityEngine;

public class BallSpawner: TouchObserver{
    private GameObject ball;
    private Camera mainCamera;

    public BallSpawner(GameObject ball){
        this.ball = ball;
        mainCamera = Camera.main;
    }

    public void OnTouch(){
        GameObject[] dogs = GameObject.FindGameObjectsWithTag("dog");
        if(dogs.Length > 0){
            GameObject ballClone = GameObject.Instantiate(ball, mainCamera.transform.position, mainCamera.transform.rotation);
            ballClone.GetComponent<Rigidbody>().AddForce(mainCamera.transform.forward * 100);
        }
    }
}