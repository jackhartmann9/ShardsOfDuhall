using UnityEngine;
using System.Collections;

public class FoodSpawn : MonoBehaviour {
    // Food Prefab
    public GameObject foodPrefab;

    // Borders
    public Transform border_top;
    public Transform border_bot;
    public Transform border_left;
    public Transform border_right;

    // Use this for initialization
   void Start () {
        // Spawn food every 4 seconds, starting in 3
        InvokeRepeating("Spawn", 1, 1);
    }

    // Spawn one piece of food
    void Spawn() {
        // x position between left & right border
        int x = (int)Random.Range(border_left.position.x,
                                  border_right.position.x);

        // y position between top & bottom border
        int y = (int)Random.Range(border_bot.position.y,
                                  border_top.position.y);

        // Instantiate the food at (x, y)
        Instantiate(foodPrefab,
                    new Vector2(x, y),
                    Quaternion.identity); // default rotation
    }
}