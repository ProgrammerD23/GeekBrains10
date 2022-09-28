using System.Collections;
using System.Collections.Generic;
using JoostenProductions;
using UnityEngine;

namespace Game.InputLogic
{
    internal class InputArrows : BaseInputView
    {
        private float moveValue;
        private void Start() =>
           UpdateManager.SubscribeToUpdate(Move);

        private void OnDestroy() =>
            UpdateManager.UnsubscribeFromUpdate(Move);

        private void Move()
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                new Vector2(_speed * Time.deltaTime, 0);
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                new Vector2(-_speed * Time.deltaTime, 0);
            }
        }
    }
}
