using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPathing : MonoBehaviour
{
    [SerializeField] GameObject fireballPrefab;
    private GameObject fireball;
    private GameObject enemyObj;

    public float speed = 3.0f;
    public float obstacleDetectionRange = 5.0f;

    private bool isAlive;

    void Start() {
        isAlive = true;

    }

    void Update()
    {
        if (isAlive) {

            transform.Translate(0, 0, speed * Time.deltaTime);

            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.SphereCast( ray, 0.75f, out hit )) {

                GameObject hitObject = hit.transform.gameObject;
                if (hitObject.GetComponent<PlayerCharacter>()) {
                    if (fireball == null) {

                        fireball = Instantiate(fireballPrefab) as GameObject;
                        fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                        fireball.transform.rotation = transform.rotation;
                        
                    }

                //if the raycast return distance is less than the detection range, rotate
                //by angle.
                } else if (hit.distance < obstacleDetectionRange) {

                    float angle = Random.Range(-110, 110);

                    transform.Rotate(0, angle, 0);

                }
            }
        }
    }

    public void SetAlive(bool alive) {
        isAlive = alive;
    }
}
