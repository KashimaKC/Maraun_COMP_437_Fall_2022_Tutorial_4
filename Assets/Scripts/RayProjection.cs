using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayProjection : MonoBehaviour
{
    private Camera cam;

    void Start()
    {

        cam = GetComponent<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0)) {

            Vector3 point = new Vector3(cam.pixelWidth/2, cam.pixelHeight/2, 0);
            Ray ray = cam.ScreenPointToRay(point);
            RaycastHit hit;
            
            if (Physics.Raycast (ray, out hit)) {

                GameObject hitObject = hit.transform.gameObject;
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();

                if (target != null) {

                    target.ReactToHit();

                } else {

                    StartCoroutine(SphereIndicator ( hit.point ) );

                }
                
            } 

        }

    }

    private IEnumerator SphereIndicator(Vector3 pos) {

        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        //scales the sphere that is spawned to 20% of original size. 
        sphere.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        sphere.transform.position = pos;

        yield return new WaitForSeconds(1);

        Destroy(sphere);
    }

    void OnGUI() {
        int size = 14;
        float posX = cam.pixelWidth/2 - size/4;
        float posY = cam.pixelHeight/2 - size/2;
        GUI.Label(new Rect(posX, posY, size, size), "*");
    }
}
