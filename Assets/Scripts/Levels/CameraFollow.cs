using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public Transform player;

	[Range (0,1)]
	public float smoothSpeed = 0.06f;

	public	Vector3 offset;

	bool moveVertical = false;
	bool moveHorizontal = false;

	// Set this to the in-world distance between the left & right edges of your scene.
	[Range (0,100)]
	public float sceneWidth = 25;
	public Camera cam;
	public GameObject cameraQuad;
	Vector2 start;
	Vector2 end;

	void Start()
    {
		offset.z = -1;
		MeshFilter quadMesh = cameraQuad.GetComponent<MeshFilter>();
		Transform quadTransform = cameraQuad.GetComponent<Transform>();
		start = quadTransform.TransformPoint(quadMesh.mesh.vertices[0]);
		end = quadTransform.TransformPoint(quadMesh.mesh.vertices[3]);
	}

    void Update()
    {
        float unitsPerPixel = sceneWidth / Screen.width;

        float desiredHalfHeight = 0.5f * unitsPerPixel * Screen.height;

        cam.orthographicSize = desiredHalfHeight;
    }
    void FixedUpdate()
	{
		Vector3 desiredPosition;

        // Horizontal & vertical range of Camera
        if (player.position.x - sceneWidth/2 > start.x && player.position.x + sceneWidth/2 < end.x)
			moveHorizontal = true;
		else
			moveHorizontal = false; 
		
		if (player.position.y > start.y && player.position.y < end.y)
			moveVertical = true;
		else
			moveVertical = false;

		
		if (moveHorizontal && !moveVertical)
			desiredPosition = new Vector3(player.position.x, transform.position.y, player.position.z);
		else if (moveVertical && !moveHorizontal)
			desiredPosition = new Vector3(transform.position.x, player.position.y, player.position.z);
		else if (moveVertical && moveHorizontal)
			desiredPosition = new Vector3(player.position.x, player.position.y, player.position.z);
		else
			desiredPosition = new Vector3(transform.position.x, transform.position.y, player.position.z);

		desiredPosition = desiredPosition + offset;
		Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
		transform.position = smoothedPosition;
		
	}
}