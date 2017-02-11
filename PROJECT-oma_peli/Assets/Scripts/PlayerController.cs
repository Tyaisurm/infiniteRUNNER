using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    public float zMin, zMax, yMax, yMin;
}

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float rolling;
    public float jumpH;
    private Rigidbody rb;
    public Boundary boundary;
    //private AudioSource[];
    private AudioSource audiosource;
    private AudioSource audiosource2;

    // Use this for initialization
    void Start()
    {

        AudioSource[] allMyAudio = GetComponents<AudioSource>();
        audiosource = allMyAudio[0];
        audiosource2 = allMyAudio[1];
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

        transform.Rotate(new Vector3(0.0f, 0.0f, rolling) * Time.deltaTime);
        if (Input.GetKeyDown("space") && rb.transform.position.y <= 0.0f)
        {
            Vector3 jump = new Vector3(0, jumpH, 0);
            rb.AddForce(jump, ForceMode.Impulse);
            audiosource.Play();

        }
        
    }
    // Update is called once per frame
    void FixedUpdate()

    {
        float movementvertical = Input.GetAxis("Horizontal");
        
        Vector3 movement = new Vector3(0.0f, 0.0f, -movementvertical);
        rb.AddForce(movement * speed);

        rb.position = new Vector3
            (
           0.0f,
          Mathf.Clamp(rb.position.y, 0.0f, boundary.yMax),
         Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
        );
        if (rb.transform.position.y <= 0.0f)
        {
            Vector3 ylos = new Vector3(0, 0, -movementvertical);
            rb.velocity = (ylos);
        }

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Treat")
        {
            audiosource2.Play();
        }
    }

}
