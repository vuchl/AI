using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GoneHome
{
    public class GameManager : MonoBehaviour
    {
        // Switches to next level when called
        public void NextLevel()
        {
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.buildIndex + 1);
        }
        public void RestartLevel()
        {
            FollowEnemy[] followEnemies = FindObjectsOfType<FollowEnemy>();
            foreach (var enemy in followEnemies)
            {
                enemy.Reset();
            }

            PatrolEnemy[] patrolEnemies = FindObjectsOfType<PatrolEnemy>();
            foreach (var enemy in patrolEnemies)
            {
                enemy.Reset();
            }
            Player player = FindObjectOfType<Player>();
            {
                player.Reset();
            }
        }
  
            
        
    }
}
