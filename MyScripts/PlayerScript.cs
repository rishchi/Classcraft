using System.Collections;
using UnityEngine;

public class playerScript : MonoBehaviour
{

    //declare GameObjects and create isShooting boolean.
    private GameObject hand;
    private GameObject spawnPoint;
    private bool isShooting;

    // Use this for initialization
    void Start()
    {

        //create references to gun and bullet spawnPoint objects
        hand = gameObject.transform.GetChild(1).GetChild(1).gameObject;
        spawnPoint = hand.transform.GetChild(4).gameObject;

        //set isShooting bool to default of false
        isShooting = false;
    }

    //Shoot function is IEnumerator so we can delay for seconds
    IEnumerator Shoot()
    {
        //set is shooting to true so we can't shoot continuosly
        isShooting = true;
        //instantiate the bullet
        GameObject bullet = Instantiate(Resources.Load("Power1", typeof(GameObject))) as GameObject;
        //Get the bullet's rigid body component and set its position and rotation equal to that of the spawnPoint
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        bullet.transform.rotation = spawnPoint.transform.rotation;
        bullet.transform.position = spawnPoint.transform.position;
        //add force to the bullet in the direction of the spawnPoint's forward vector
        rb.AddForce(spawnPoint.transform.forward * 500f);
        //play the gun shot sound and gun animation
        hand.GetComponent<Animation>().Play();
        //destroy the bullet after 1 second
       
        //wait for 1 second and set isShooting to false so we can shoot again
        yield return new WaitForSeconds(1f);
        isShooting = false;
    }

    // Update is called once per frame
    void Update()
    {

        //declare a new RayCastHit
        RaycastHit hit;
        //draw the ray for debuging purposes (will only show up in scene view)
        Debug.DrawRay(spawnPoint.transform.position, spawnPoint.transform.forward, Color.green);

        //cast a ray from the spawnpoint in the direction of its forward vector
        if (Physics.Raycast(spawnPoint.transform.position, spawnPoint.transform.forward, out hit, 100))
        {

            //if the raycast hits any game object where its name contains "zombie" and we aren't already shooting we will start the shooting coroutine
            if (hit.collider.name.Contains("Knight1"))
            {
                if (!isShooting)
                {
                    StartCoroutine("Shoot");
                }

            }

        }

    }
}


 
/**namespace VRStandardAssets.ShootingGallery
{
    // This script controls the gun for the shooter
    // scenes, including it's movement and shooting.
    public class ShootingGalleryGun : MonoBehaviour
    {
       
        [SerializeField] private float m_GunContainerSmoothing = 10f;                   // How fast the gun arm follows the reticle.
        [SerializeField] private ShootingGalleryController m_ShootingGalleryController; // Reference to the controller so the gun cannot fire whilst the game isn't playing.
        [SerializeField] private VREyeRaycaster m_EyeRaycaster;                         // Used to detect whether the gun is currently aimed at something.
        [SerializeField] private VRInput m_VRInput;                                     // Used to tell the gun when to fire.
        [SerializeField] private Transform m_CameraTransform;                           // Used as a reference to move this gameobject towards.
        [SerializeField] private Transform m_GunContainer;                              // This contains the gun arm needs to be moved smoothly.
        [SerializeField] private Reticle m_Reticle;                                     // This is what the gun arm should be aiming at.
       

        private const float k_DampingCoef = -20f;                                       // This is the coefficient used to ensure smooth damping of this gameobject.


        private void Awake()
        {
            m_GunFlare.enabled = false;
        }


        private void OnEnable()
        {
            m_VRInput.OnDown += HandleDown;
        }


        private void OnDisable()
        {
            m_VRInput.OnDown -= HandleDown;
        }


        private void Update()
        {
            // Smoothly interpolate this gameobject's rotation towards that of the user/camera.
            //transform.rotation = Quaternion.Slerp(transform.rotation, InputTracking.GetLocalRotation(VRNode.Head),
            //transform.rotation = Quaternion.Slerp(transform.rotation, m_CameraTransform.localRotation,
            //    m_Damping * (1 - Mathf.Exp(k_DampingCoef * Time.deltaTime)));

            // Move this gameobject to the camera.
            transform.position = m_CameraTransform.position;

            // Find a rotation for the gun to be pointed at the reticle.
            Quaternion lookAtRotation = Quaternion.LookRotation(m_Reticle.ReticleTransform.position - m_GunContainer.position);

            // Smoothly interpolate the gun's rotation towards that rotation.
            //m_GunContainer.rotation = Quaternion.Slerp (m_GunContainer.rotation, lookAtRotation,
            transform.rotation = Quaternion.Slerp(m_GunContainer.rotation, lookAtRotation,
        m_GunContainerSmoothing * Time.deltaTime);
        }


        private void HandleDown()
        {
            // If the game isn't playing don't do anything.
            if (!m_ShootingGalleryController.IsPlaying)
                return;

            // Otherwise, if there is an interactible currently being looked at, try to find it's ShootingTarget component.
            ShootingTarget shootingTarget = m_EyeRaycaster.CurrentInteractible ? m_EyeRaycaster.CurrentInteractible.GetComponent<ShootingTarget>() : null;

            // If there is a ShootingTarget component get it's transform as the target for shooting at.
            Transform target = shootingTarget ? shootingTarget.transform : null;

            // Start shooting at the target.
            StartCoroutine(Fire(target));
        }


        private IEnumerator Fire(Transform target)
        {
            // Play the sound of the gun firing.
            m_GunAudio.Play();

            // Set the length of the line renderer to the default.
            float lineLength = m_DefaultLineLength;

            // If there is a target, the line renderer's length is instead the distance from the gun to the target.
            if (target)
                lineLength = Vector3.Distance(m_GunEnd.position, target.position);

            // Chose an index for a random flare mesh.
            int randomFlareIndex = Random.Range(0, m_FlareMeshes.Length);

            // Store the rotation of that random flare and set it randomly rotate around the z axis.
            Vector3 randomEulerRotation = m_FlareMeshes[randomFlareIndex].transform.eulerAngles;
            randomEulerRotation.z = Random.Range(0f, 360f);

            // Set the random rotation that has been stored back to the flare and turn it on.
            m_FlareMeshes[randomFlareIndex].transform.eulerAngles = randomEulerRotation;
            m_FlareMeshes[randomFlareIndex].SetActive(true);

            // Play the particle system for the gun.
            m_FlareParticles.Play();

            // Turn the line renderer on.
            m_GunFlare.enabled = true;

            // Whilst the line renderer is on move it with the gun.
            yield return StartCoroutine(MoveLineRenderer(lineLength));

            // Turn the line renderer off again.
            m_GunFlare.enabled = false;

            // Turn the random flare mesh off.
            m_FlareMeshes[randomFlareIndex].SetActive(false);

        }


       
    }
}*/

