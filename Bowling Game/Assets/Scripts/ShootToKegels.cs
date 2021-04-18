using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootToKegels : MonoBehaviour
{
    [SerializeField] private Vector3 mousePosition;
    [SerializeField] public Camera toLookAt;

    [SerializeField] private float maxDistance;

    [SerializeField] private GameObject crossFire;
    [SerializeField] private int offsetCrossfire;

    [SerializeField] float explosionForce;
    [SerializeField] int amountPinesExplode;

    [SerializeField] public GameObject explosionEffectPrefab;
    [SerializeField] public Ray ray;
    [SerializeField] public Vector3 vecUp;
    [SerializeField] public RaycastHit my_Hit;

    [SerializeField] public KegelClass prefabKegel;
    [SerializeField] List<KegelClass> miniKegels;
    private void Awake()
    {
        miniKegels.Clear();
    }
    void Update()
    {
        mousePosition = Input.mousePosition;

        ray = toLookAt.ScreenPointToRay(mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * maxDistance, Color.green);
        crossFire.transform.position = ray.origin + (ray.direction * (maxDistance - offsetCrossfire));    //Corssfire (Scope)

        if(Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out my_Hit, maxDistance))
            {
                if(my_Hit.collider.tag == "Kegel")
                {
                    Rigidbody my_RigidHit = my_Hit.collider.gameObject.GetComponent<Rigidbody>();
                    my_RigidHit.AddExplosionForce(explosionForce, my_Hit.point, 2, 2, ForceMode.Impulse);
                    GameObject explodeEffect = Instantiate(explosionEffectPrefab, my_Hit.transform.position, Quaternion.identity, my_Hit.transform);
                    explodeEffect.GetComponent<ParticleSystem>().Play();
                    for (int i = 0; i < amountPinesExplode; i++)
                    {
                        miniKegels.Add(Instantiate(prefabKegel, my_Hit.transform.position, Quaternion.identity, my_Hit.transform));
                    }

                    for (int i = 0; i < miniKegels.Count; i++)
                    {
                        if(miniKegels[i] != null)
                        {
                            miniKegels[i].GetComponent<Rigidbody>().AddExplosionForce(explosionForce, my_Hit.point, 2, 2, ForceMode.Impulse);
                        }
                    }
                }
                else
                {
                    GameManager.Get().PlayerState(GameManager.EndState.Lose);
                    GameManager.Get().EndMatch(true);
                }
            }
        }

    }
}
