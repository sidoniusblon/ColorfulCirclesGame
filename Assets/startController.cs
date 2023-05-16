using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class startController : MonoBehaviour
{
    [SerializeField] LayerMask layer;
    GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    EventSystem m_EventSystem;

    [SerializeField] GraphicRaycaster canvas;
    [SerializeField] EventSystem eventsystem;
    private void Start()
    {
        Time.timeScale = 0;
        m_Raycaster = canvas;
        m_EventSystem = eventsystem;
    }
    void Update()
    {
        
        
        if (Input.GetMouseButtonDown(0))
        {
            m_PointerEventData = new PointerEventData(m_EventSystem);
            m_PointerEventData.position = Input.mousePosition;
            List<RaycastResult> results = new List<RaycastResult>();
            m_Raycaster.Raycast(m_PointerEventData, results);

                if(results[0].gameObject.layer == 6)
                {
                    Time.timeScale = 1;
                    Destroy(this.gameObject);
                    UIControllerSc.Instance.InfoPanelController(false);
                UIControllerSc.Instance.bestScoreClose();
                }
            

        }
    }
}
