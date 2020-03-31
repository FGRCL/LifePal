using UnityEngine;

public class DogSpawner: TouchObserver{
    private GameObject dog;
    private ReticleBehaviour PlacementIndicator;
    private bool DogSpawned = false;
    public DogSpawner(GameObject dog, ReticleBehaviour PlacementIndicator){
        this.dog = dog;
        this.PlacementIndicator = PlacementIndicator;
    }

    public void OnTouch(){
        if(!DogSpawned){
            GameObject obj = GameObject.Instantiate(dog, PlacementIndicator.transform.position, PlacementIndicator.transform.rotation * Quaternion.Euler(Vector3.up * 180));
            obj.tag = "dog";
            DogSpawned = true;
        }
    }
}