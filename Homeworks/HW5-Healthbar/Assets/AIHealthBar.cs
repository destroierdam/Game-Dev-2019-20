using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIHealthBar : MonoBehaviour
{
    private GameObject AI;
    private Animator AIAnimator;
    private Vector3 offset;
    private Slider slider;
    void Start() {
        AI = GameObject.FindGameObjectWithTag("AI");
        if (AI == null)
        {
            Debug.LogError("GameObject AI not found");
            return;
        }
        AIAnimator = AI.GetComponent<Animator>();
        slider = GetComponent<Slider>();

        offset = this.transform.position - AI.transform.position;
    }

    void Update() {
        int AIHealth = AIAnimator.GetInteger("Health");
        slider.value = AIHealth;

        this.transform.position = AI.transform.position + offset;
    }
}
