using UnityEngine;
using UnityEngine.UI;
using System.Linq;

namespace I2.Loc
{
	public class DropDownResolutions : MonoBehaviour 
	{
		#if UNITY_5_2 || UNITY_5_3 || UNITY_5_4_OR_NEWER
		void OnEnable()
    {
      var dropdown = GetComponent<Dropdown>();
      if (dropdown==null)
        return;
      // Fill the dropdown elements
      dropdown.ClearOptions();
      dropdown.AddOptions(Screen.resolutions.Select(resolution => resolution.width + "x" + resolution.height).ToList());

      dropdown.value = Screen.resolutions.IndexOf((resol, indx) => resol.Equals(Screen.currentResolution));
      dropdown.onValueChanged.RemoveListener( OnValueChanged );
      dropdown.onValueChanged.AddListener( OnValueChanged );
    }

    
    void OnValueChanged( int index )
    {
      var dropdown = GetComponent<Dropdown>();
      if (index<0)
      {
        index = 0;
        dropdown.value = index;
      }

      Screen.SetResolution(Screen.resolutions[index].width, Screen.resolutions[index].height, Screen.fullScreen);
    }
        #endif
    }
}