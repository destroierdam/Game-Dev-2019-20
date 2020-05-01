using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    private Vector3 offset;
    [SerializeField]
    private Material postProcMaterial;

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
       Graphics.Blit(source, destination, postProcMaterial);
    }

    // Start is called before the first frame update
    void Start()
    {
        offset = this.transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        this.transform.position = player.transform.position + offset;
    }
}
