using System.Collections.Generic;
using UnityEngine;

public class MenuProtocolSelector : MonoBehaviour
{

    public List<ProtocolUI> protocolList;
    private ProtocolUI selectedProtocol;
    // if one is selected turn the rest to deselected
    // onClick when button is selected turns everything back to normal
    bool clicked = false;

    public void SelectProtocol(int id)
    {
        if (!clicked)
        {

            if (!selectedProtocol)
            {
                foreach (ProtocolUI p in protocolList)
                {
                    if (p.id != id)
                    {
                        p.Deselected();
                        Debug.Log("deselected");
                    }
                    else
                    {
                        selectedProtocol = p;
                        clicked = true;
                        p.Selected();
                    }
                }
            }

        }
        else
        {
            if (selectedProtocol && selectedProtocol.id == id)
            {
                ResetButtons();
                selectedProtocol = null;
                clicked = false;
            }
        }
    }

    public void ResetButtons()
    {

        foreach (ProtocolUI p in protocolList)
        {
            p.ResetUI();
        }

    }

}
