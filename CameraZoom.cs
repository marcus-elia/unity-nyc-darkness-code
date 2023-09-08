using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public Light playerLight;
    public Light directionalLight;
    public Light lamp;

    private bool bridgeFound = false;
    private bool chryslerFound = false;
    private bool found111 = false;

    public GameObject messageText;
    private int messageTextTime = 0;
    private int MESSAGE_TIME = 500;

    // Start is called before the first frame update
    void Start()
    {
        directionalLight.intensity = 0;
        messageText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Camera.main.fieldOfView = 4;
        } else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Camera.main.fieldOfView = 2;
        } else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Camera.main.fieldOfView = 1;
        }
        else if (Input.GetKeyUp(KeyCode.Alpha1) || Input.GetKeyUp(KeyCode.Alpha2) || Input.GetKeyUp(KeyCode.Alpha3))
        {
            Camera.main.fieldOfView = 60;
        }

        RaycastRobot();
        if (!bridgeFound)
        {
            RaycastBridge();
        }
        if (!chryslerFound)
        {
            RaycastChrysler();
        }
        if (!found111)
        {
            Raycast111();
        }

        if (playerLight.intensity < 1)
        {
            playerLight.intensity += 0.0003f;
        }
        if (lamp.intensity < 1)
        {
            lamp.intensity += 0.0003f;
        }

        if (messageTextTime > 0)
        {
            messageTextTime--;
        }
        if (messageTextTime == 0)
        {
            messageText.SetActive(false);
        }
    }


    public void RaycastRobot()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        string[] collidableLayers = { "Robots" };

        LayerMask mask = LayerMask.GetMask(collidableLayers);

        if (Physics.Raycast(ray, out hit, 25000f, mask))
        {
            Transform objectHit = hit.transform;
            playerLight.intensity = 0f;
            lamp.intensity = 0f;
        }
    }
    public void RaycastBridge()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        string[] collidableLayers = { "Bridge" };

        LayerMask mask = LayerMask.GetMask(collidableLayers);

        if ((Input.GetKey(KeyCode.Alpha1) || Input.GetKey(KeyCode.Alpha2) || Input.GetKey(KeyCode.Alpha3))
            && Physics.Raycast(ray, out hit, 25000f, mask))
        {
            Transform objectHit = hit.transform;
            //RenderSettings.ambientMode = UnityEngine.Rendering.AmbientMode.Skybox;
            directionalLight.intensity += 0.1f;
            bridgeFound = true;
            messageText.GetComponent<TMPro.TextMeshProUGUI>().text = "Found Queensboro Bridge";
            messageTextTime = MESSAGE_TIME;
            messageText.SetActive(true);
            if (found111 && bridgeFound && chryslerFound)
            {
                directionalLight.intensity = 1;
            }
        }
    }
    public void RaycastChrysler()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        string[] collidableLayers = { "Chrysler" };

        LayerMask mask = LayerMask.GetMask(collidableLayers);

        if ((Input.GetKey(KeyCode.Alpha1) || Input.GetKey(KeyCode.Alpha2) || Input.GetKey(KeyCode.Alpha3))
            && Physics.Raycast(ray, out hit, 25000f, mask))
        {
            Transform objectHit = hit.transform;
            directionalLight.intensity += 0.1f;
            chryslerFound = true;
            messageText.GetComponent<TMPro.TextMeshProUGUI>().text = "Found Chrysler Building";
            messageTextTime = MESSAGE_TIME;
            messageText.SetActive(true);
            if (found111 && bridgeFound && chryslerFound)
            {
                directionalLight.intensity = 1;
            }
        }
    }
    public void Raycast111()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        string[] collidableLayers = { "111" };

        LayerMask mask = LayerMask.GetMask(collidableLayers);

        if ((Input.GetKey(KeyCode.Alpha1) || Input.GetKey(KeyCode.Alpha2) || Input.GetKey(KeyCode.Alpha3))
            && Physics.Raycast(ray, out hit, 25000f, mask))
        {
            Transform objectHit = hit.transform;
            directionalLight.intensity += 0.1f;
            found111 = true;
            messageText.GetComponent<TMPro.TextMeshProUGUI>().text = "Found 111 W 57th Street";
            messageTextTime = MESSAGE_TIME;
            messageText.SetActive(true);
            if (found111 && bridgeFound && chryslerFound)
            {
                directionalLight.intensity = 1;
            }
        }
    }
}
