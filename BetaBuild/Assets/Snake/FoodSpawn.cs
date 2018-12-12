using UnityEngine;
using System.Collections;

public class FoodSpawn : MonoBehaviour {
    // Food Prefab
    public GameObject foodPrefab;
    public GameObject avoidPrefab;

    // Borders
    public Transform border_top;
    public Transform border_bot;
    public Transform border_left;
    public Transform border_right;
    private int buffer = 2;

    // Use this for initialization
   void Start () {
        // Spawn food every 1 seconds, starting in 1
        InvokeRepeating("Spawn", 1, 1);
        InvokeRepeating("AvoidSpawn", 3, 5);
    }

    // Spawn one piece of food
    void Spawn() {


        // Instantiate the food at (x, y)
        Instantiate(foodPrefab,
                    new Vector2(XLocation(), YLocation()),
                    Quaternion.identity); // default rotation
    }
    void AvoidSpawn() {
        // x position between left & right border
        // Instantiate the food at (x, y)
        Instantiate(avoidPrefab,
                    new Vector2(XLocation(), YLocation()),
                    Quaternion.identity); // default rotation
    }

    //Generate Random X XLocation
    private int XLocation(){
      return (int)Random.Range(border_left.position.x + buffer,
                                border_right.position.x - buffer);
    }
    //Generate Random y YLocation
    private int YLocation(){
      return (int)Random.Range(border_bot.position.y + buffer,
                                border_top.position.y - buffer);
    }
}
