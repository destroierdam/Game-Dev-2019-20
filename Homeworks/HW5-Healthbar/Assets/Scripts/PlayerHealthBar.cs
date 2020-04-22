using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    GameObject player;
    /// <summary>
    ///  The offset of the position of the player and the HealthBar
    /// </summary>
    private Vector3 offset;
    private Animator playerAnimator;
    private Slider slider;
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null) {
            Debug.LogError("GameObject Player not found");
            return;
        }
        playerAnimator = player.GetComponent<Animator>();
        slider = GetComponent<Slider>();

        offset = this.transform.position - player.transform.position;
    }

    void Update() {
        int playerHealth = playerAnimator.GetInteger("Health");
        slider.value = playerHealth;

        this.transform.position = player.transform.position + offset;
    }
}
