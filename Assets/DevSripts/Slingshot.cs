using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    public LineRenderer[] lineRenderers;
    public Transform[] stripPositions;
    public Transform center;
    public Transform idlePosition;
    public Vector3 currentPosition;
    public float maxLength;
    bool isMouseDown;

    public GameObject pelletPrefab;
    public float pelletPositionOffset;

    public float force;

    public Rigidbody2D pellet;
    public Collider2D pelletCollider;

    // Start is called before the first frame update
    // Sets the position of the line strips
    void Start()
    {
        lineRenderers[0].positionCount = 2;
        lineRenderers[1].positionCount = 2;
        lineRenderers[0].SetPosition(0, stripPositions[0].position);
        lineRenderers[1].SetPosition(0, stripPositions[1].position);

        CreatePellet();
    }

    void CreatePellet()
    {
        pellet = Instantiate(pelletPrefab).GetComponent<Rigidbody2D>();
        pelletCollider = pellet.GetComponent<Collider2D>();
        pelletCollider.enabled = false;

    }
    // Update is called once per frame
    void Update()
    {
        // Holding mouse on the strip and drag
        if (isMouseDown)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 10;

            currentPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            currentPosition = center.position + Vector3.ClampMagnitude(currentPosition - center.position, maxLength); // This creates a limited distance of how far you can drag the strip
            SetStrips(currentPosition);
        }
        else
        {
            ResetStrips();
        }
    }

    private void OnMouseDown()
    {
        isMouseDown = true;
    }

    private void OnMouseUp()
    {
        isMouseDown = false;
        Shoot();
    }

    // This causes the pellet to be thrown after letting go of slingshot, another pellet respawns at slingshot
    void Shoot()
    {
        Vector3 pelletForce = (currentPosition - center.position) * force * -1;
        pellet.velocity = pelletForce;

        pellet = null;
        pelletCollider = null;
        Invoke("CreatePellet", 2);
    }

    void ResetStrips()
    {
        currentPosition = idlePosition.position;
        SetStrips(currentPosition);
    }

    void SetStrips(Vector3 position)
    {
        lineRenderers[0].SetPosition(1, position);
        lineRenderers[1].SetPosition(1, position);


        if(pellet)
        {
            Vector3 dir = position - center.position;
            pellet.transform.position = position + dir.normalized * pelletPositionOffset;
        }
    }
}
