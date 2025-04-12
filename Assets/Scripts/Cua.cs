using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cua : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform touchCheck;
    public GameObject cua;
    public float touchPoin;
    private bool isTouching;
    public LayerMask whatPlayer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isTouching = Physics.CheckSphere(touchCheck.position, touchPoin, whatPlayer);
        DestroyCua();
    }
    public void DestroyCua()
    {
        if (isTouching)
        {
            cua.gameObject.SetActive(false);
        }
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(touchCheck.position, touchPoin);
    }
}
