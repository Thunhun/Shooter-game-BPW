using UnityEngine;

public class Gun : MonoBehaviour
{
    public float range = 1000f;
    public float fireRate = 15f;
    public Camera fpsCam;
    public ParticleSystem flash;
    public ParticleSystem flashSuck;
    public GameObject impactEffect;
    public GameObject succEffect;
    public float impactForce = 30f;
    public float impactSuck = -30f;

    private float nextTimeToFire = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Pausemenu.GameIsPaused == false)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
            if (Input.GetButton("Fire2") && Time.time >= nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1f / fireRate;
                Suck();
            }
        }
    }
    void Shoot()
    {
        flash.Play();
        FindObjectOfType<AudioManager>().Play("Shoot Push");
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {



            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, .5f);
        }
    }
    void Suck()
    {
        flashSuck.Play();
        FindObjectOfType<AudioManager>().Play("Shoot Pull");
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {

           

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactSuck);
            }

            GameObject impactGO = Instantiate(succEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, .5f);
        }

    }
}
