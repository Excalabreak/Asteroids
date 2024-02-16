using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [02/15/2024]
 * [manages all enemies in scene]
 */

public class EnemyManager : Singleton<EnemyManager>
{
    //all enemies
    [SerializeField] private List<BaseEnemyScript> _currentEnemies;

    /*
     * note:
     * when spawning ufo:
     * delay from start of the level
     * spawn off of one side of the screen
     * when destroid, random delay till next saucer (next saucer is random)
     * repeat
     * spawn from one side of the screen
     */
}
