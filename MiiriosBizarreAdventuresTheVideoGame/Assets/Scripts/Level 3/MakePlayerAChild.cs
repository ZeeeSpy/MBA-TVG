/*
 *  DEPRECIATED IS NOT USED
 *  
 *  Originally in level 3 Boss all objects would move and the road would be spawned ahead
 *  this was undone due to the difficulty of projectile physics on multiple moving platforms
 *  This script originally make the player a child object of the ambulance so that the player would
 *  move with the ambulance
 */

using UnityEngine;

public class MakePlayerAChild : MonoBehaviour
{
    public GameObject player;

    private void Start()
    {
        player.gameObject.transform.SetParent(transform);
    }
}
