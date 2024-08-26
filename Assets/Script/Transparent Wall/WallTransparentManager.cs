using System.Collections.Generic;
using UnityEngine;

public class WallTransparentManager : MonoBehaviour
{
    [SerializeField] private LayerMask wallMask;
    [SerializeField] private float sphereCastRadius;
    [SerializeField] private float distanceLower;
    [SerializeField] private float behindCameraCastDistance; // New variable for the backside cast distance
    [SerializeField] private float behindCameraCastRadius; // New variable for the backside cast radius
    private List<WallTransparent> previousWalls = new List<WallTransparent>();

    void Start()
    {

    }

    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player!= null)
        {
            Vector3 dir = player.transform.position - transform.position;
            Ray ray = new Ray(transform.position, dir);
            RaycastHit[] hits = Physics.SphereCastAll(ray, sphereCastRadius, Vector3.Distance(transform.position, player.transform.position) - distanceLower, wallMask);
            List<WallTransparent> currentWalls = new List<WallTransparent>();

            // Cast a sphere cast from the camera to detect the wall behind the camera
            RaycastHit[] behindCameraHits = Physics.SphereCastAll(transform.position, behindCameraCastRadius, -transform.forward, behindCameraCastDistance, wallMask);
            foreach (RaycastHit behindCameraHit in behindCameraHits)
            {
                WallTransparent behindCameraWall = behindCameraHit.collider.GetComponent<WallTransparent>();
                if (behindCameraWall!= null)
                {
                    behindCameraWall.doFade = true;
                    currentWalls.Add(behindCameraWall);
                }
            }

            for (int i = 0; i < hits.Length; i++)
            {
                WallTransparent wall = hits[i].collider.GetComponent<WallTransparent>();
                if (wall!= null)
                {
                    wall.doFade = true;
                    currentWalls.Add(wall);
                }
            }

            foreach (WallTransparent wall in previousWalls)
            {
                if (!currentWalls.Contains(wall))
                {
                    wall.doFade = false;
                }
            }

            previousWalls = currentWalls;
        }
    }
}