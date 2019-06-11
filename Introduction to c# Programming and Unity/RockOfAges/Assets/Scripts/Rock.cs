using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour {

    int rockCounter;

    const float MinImpulseForce = 2f;
    const float MaxImpulseForce = 5f;

    Timer lifeTime;
    const float lifeTimeInSeconds = 3f;

    void Start()
    {
        // apply impulse force to get game object moving
        float angle = Random.Range(0, 2 * Mathf.PI);
        Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);
        GetComponent<Rigidbody2D>().AddForce(direction * magnitude,ForceMode2D.Impulse);

        lifeTime = gameObject.AddComponent<Timer>();
        lifeTime.Duration = lifeTimeInSeconds;
        lifeTime.Run();
    }

    private void Update()
    {
        
    }

    private void OnBecameInvisible()
    {
        enabled = false;
        Destroy(this.gameObject);
    }
}
