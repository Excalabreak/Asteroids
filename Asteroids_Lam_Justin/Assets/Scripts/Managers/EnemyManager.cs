using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [02/14/2024]
 * [manages all enemies in scene]
 */

public class EnemyManager : Singleton<EnemyManager>
{
    //all enemies
    [SerializeField] private List<BaseEnemyScript> _currentEnemies;
}
