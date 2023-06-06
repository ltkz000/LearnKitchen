using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    private Player player;
    private float footStepTimer;
    private float footStepTimerMax = .1f;
    private float volume = 1.0f;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    private void Update()
    {
        footStepTimer -= Time.deltaTime;

        if (footStepTimer < 0.0f)
        {
            footStepTimer = footStepTimerMax;

            if (player.IsWalking())
            {
                SoundManager.Instance.PlayFootStepSound(player.transform.position, volume);
            } 
        }
    }
}
