using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet: MonoBehaviour
{
    public float DestoryDistance;
    //public float ShootSpeed;
    // Start is called before the first frame update
    [SerializeField] Rigidbody2D Bulletrb;
    Vector3 StartPos;
    void Start()
    {
        StartPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = (this.transform.position - StartPos).sqrMagnitude;
        if (distance > DestoryDistance)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Organ"))
        {
            collision.GetComponent<ConstantForce2D>().force = new Vector2(0, 5);
            Destroy(this.gameObject);
        }
    }
}
