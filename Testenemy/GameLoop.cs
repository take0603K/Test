using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
        private GameState state;
        private AI ai;

        public GameLoop()
        {
            state = new GameState();
            ai = new AI();
        }

        public void Update()
        {
            string action = ai.Evaluate(state);
            ai.PerformAction(action);

            // ゲームの状態を更新するロジック
        }
    }

