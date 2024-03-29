using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class Cannon : MonoBehaviour
{
    Vector3 currentMousePos;
    Quaternion clampRotationLow, clampRotationHigh;
    [SerializeField] GameObject Bullet;
    [SerializeField] GameObject Cannonball;
    private bool canFire = true;

    public ObjectPooling objectPool1;
    public ObjectPooling objectPool2;

    [SerializeField] float continuousFireRate = 1.0f;

    private Coroutine continuousFireCoroutine;

    void Start()
    {
        clampRotationLow = Quaternion.Euler(0f, 0f, -70f);
        clampRotationHigh = Quaternion.Euler(0f, 0f, +70f);
    }

    // Update is called once per frame
    void Update()
    {
        PointAtMouse();

        // Continuous firing while the left mouse button is held down
        if (Input.GetMouseButtonDown(0) && canFire)
        {
            if (continuousFireCoroutine == null)
            {
                continuousFireCoroutine = StartCoroutine(ContinuousFiring(objectPool1));
            }
        }
        else if (Input.GetMouseButtonDown(1) && canFire)
        {
            if (continuousFireCoroutine == null)
            {
                continuousFireCoroutine = StartCoroutine(ContinuousFiring(objectPool2));
            }
        }
        else if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
        {
            if (continuousFireCoroutine != null)
            {
                StopCoroutine(continuousFireCoroutine);
                continuousFireCoroutine = null;
            }
        }
    }

    

    void PointAtMouse()
    {
        Quaternion newrotation = Quaternion.LookRotation(this.transform.position - GameData.MousePos, Vector3.forward);
        newrotation.z = Mathf.Clamp(newrotation.z, clampRotationLow.z, clampRotationHigh.z);
        newrotation.w = Mathf.Clamp(newrotation.w, clampRotationLow.w, clampRotationHigh.w);
        newrotation.x = 0;
        newrotation.y = 0;
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, newrotation, Time.deltaTime * 3f);
    }

    IEnumerator ContinuousFiring(ObjectPooling myObjectPool)
    {
        while (true)
        {
            if (canFire)
            {
                GameObject Projectile = myObjectPool.GetPooledObject();
                StartCoroutine(FiringSequence(Projectile));
            }

            yield return new WaitForSeconds(continuousFireRate);
        }
    }

    IEnumerator FiringSequence(GameObject Projectile)
    {
        if (Projectile != null)
        {
            canFire = false;

            GameObject cannonTip = GameObject.Find("CannonTip");
            Vector3 newPosition = cannonTip.transform.position;
            Projectile.transform.position = newPosition;
            Projectile.transform.rotation = cannonTip.transform.rotation;
            Projectile.SetActive(true);

            yield return new WaitForSeconds(continuousFireRate);

            canFire = true;
        }
    }
}
