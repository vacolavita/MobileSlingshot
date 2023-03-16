using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    private UIManager _uiManager;
    private int currentAmmo = 10;

    // Start is called before the first frame update
    // Sets the position of the line strips
    void Start()
    {
        lineRenderers[0].positionCount = 2;
        lineRenderers[1].positionCount = 2;
        lineRenderers[0].SetPosition(0, stripPositions[0].position);
        lineRenderers[1].SetPosition(0, stripPositions[1].position);

        CreatePellet();

        center.position = (stripPositions[0].position + stripPositions[1].position) / 2;

        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    // Creates pellet at the slingshot
    void CreatePellet()
    {
        if (currentAmmo <= 0)
        {
            GameOver();
        }
        else
        {
            pellet = Instantiate(pelletPrefab).GetComponent<Rigidbody2D>();
            pelletCollider = pellet.GetComponent<Collider2D>();
            pelletCollider.enabled = true;
        }

    }
    // Update is called once per frame
    void Update()
    {
        SlingshotPull();
    }

    public void SlingshotPull()
    {
        // Holding mouse on the strip and drag
        if (isMouseDown)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 10;

            currentPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            currentPosition = center.position + Vector3.ClampMagnitude(currentPosition - center.position, maxLength); // This creates a limited distance of how far you can drag the strip


            //Added by Alex. Need to get SetLaunch working to make triple pellets work.
            Debug.Log(Vector3.Angle(pellet.position, center.position));
            pellet.gameObject.GetComponent<PelletForward>().setLaunch(Vector3.Angle(pellet.position, center.position));

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
        if (currentAmmo <= 0)
        {

        }
        else
        {
            currentAmmo--;
            _uiManager.UpdateAmmo(currentAmmo);
        }

        Vector3 pelletForce = (currentPosition - center.position) * force * -1;
        pellet.GetComponent<PelletForward>().Launch(pelletForce);
        pellet = null;
        pelletCollider = null;
        Invoke("CreatePellet", 2);
    }
    // Reseting the rubber band from the slingshot to original position
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
    void GameOver()
    {
        Debug.Log("Game Over! Press to Restart.");
    }
}
