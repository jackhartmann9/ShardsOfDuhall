/*Jack Hartmann
  OSIS Games
*/

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveControl : MonoBehaviour {
    [SerializeField] private InputHandler inputHandler;
    [SerializeField] private Snake snake;

    // Key registration for the different movements of the snake head
		//note: the tail follows the head
    void Start () {
        inputHandler.RegisterKey("w", snake.MoveUp);
        inputHandler.RegisterKey("a", snake.MoveLeft);
        inputHandler.RegisterKey("s", snake.MoveDown);
        inputHandler.RegisterKey("d", snake.MoveRight);
        inputHandler.RegisterKey("up", snake.MoveUp);
        inputHandler.RegisterKey("left", snake.MoveLeft);
        inputHandler.RegisterKey("down", snake.MoveDown);
        inputHandler.RegisterKey("right", snake.MoveRight);
	}
}
