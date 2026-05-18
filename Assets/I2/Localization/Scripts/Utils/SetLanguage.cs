using UnityEngine;
namespace I2.Loc
{
	[AddComponentMenu("I2/Localization/SetLanguage Button")]
	public class SetLanguage : MonoBehaviour 
	{
		public string _Language;
		int CurrentLanguage = 1;

#if UNITY_EDITOR
		public LanguageSource mSource;
#endif
		
		public void SetLang(string LangName)
		{
			if(LocalizationManager.HasLanguage(LangName))
			{
				LocalizationManager.CurrentLanguage = LangName;
			}
		}

		public void SwitchLanguage(int diff)
		{
			CurrentLanguage += diff;
			if (CurrentLanguage >= LocalizationManager.GetAllLanguages().Count)
				CurrentLanguage = 0;

			if (CurrentLanguage <0)
				CurrentLanguage = LocalizationManager.GetAllLanguages().Count-1;
			SetLang(LocalizationManager.GetAllLanguages()[CurrentLanguage]);
		}
    }
}