using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box : MonoBehaviour
{
    public Transform[] backgrounds;
    public float[] parallaxScales;
    public float smoothing = 1f;

    private Transform cam;
    private Vector3 previousCamPos;

    private void Start()
    {
        cam = Camera.main.transform;
        previousCamPos = cam.position;

        parallaxScales = new float[backgrounds.Length];

        for (int i = 0; i < backgrounds.Length; i++)
        {
            parallaxScales[i] = backgrounds[i].position.z * -1;
        }
    }

    private void Update()
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            float parallax = (previousCamPos.x - cam.position.x) * parallaxScales[i];
            float backgroundTargetPosX = backgrounds[i].position.x + parallax;
            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
        }

        previousCamPos = cam.position;

        if (cam.position.x < backgrounds[0].position.x - 10f)
        {
            backgrounds[0].position = new Vector3(backgrounds[3].position.x + 20f, backgrounds[0].position.y, backgrounds[0].position.z);

            Transform temp = backgrounds[0];
            backgrounds[0] = backgrounds[1];
            backgrounds[1] = backgrounds[2];
            backgrounds[2] = backgrounds[3];
            backgrounds[3] = temp;
        }
    }
}
