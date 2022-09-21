using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    private PlayerCharacter player;

    void Start() {
        player = GameObject.Find("Body").GetComponent<PlayerCharacter>();
    }

    public void ReactToHit() 
    {
        AIPathing behavior = GetComponent<AIPathing>();

        if(behavior != null) {
            behavior.SetAlive(false);
        }

        player.AddScore(1);
        StartCoroutine(Die());
    }

    private IEnumerator Die()
    {
        this.transform.Rotate( -75, 0, 0 );

        yield return new WaitForSeconds(1.5f);

        Destroy(this.gameObject);
    }
}
