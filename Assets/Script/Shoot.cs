using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Camera cam;
    public float ShotSpeed;
    private Vector3 MousePos;
    private Vector2 ShootDir;
    [SerializeField] GameObject bullet;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        MousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        ShootDir = (MousePos - this.transform.position).normalized;
       // print(MousePos);
        //print(ShootDir);
        if (Input.GetMouseButtonDown(0))
        {
            GameObject _bullet = Instantiate(bullet);
            _bullet.transform.position = this.transform.position;
            _bullet.GetComponent<Rigidbody2D>().velocity = MousePos * ShotSpeed;

        }
    }
}
