using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Bullet : MonoBehaviour
{
    public GameObject player;
    private double time;

    Rigidbody m_rigidbody;

    void Awake() {
        m_rigidbody = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider collider) {
        HitBox hitBox = collider.GetComponent<HitBox>();
        if (hitBox) {
            hitBox.Hit();
        }
    }

    void OnCollisionEnter(Collision col) {
        Attractor attractor;
        if (col.gameObject.TryGetComponent<Attractor>(out attractor)) {
            gameObject.SetActive(false);
        }
    }

    void FixedUpdate() {
        if (Time.time - time > 2) {
            gameObject.SetActive(false);
        }
    }

    public void setTime(double t) {
        this.time = t;
    }

}
