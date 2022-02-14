using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TextUpdater : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI title, desc;
    private void OnEnable()
    {
        SubSkillUI.OnAdded += UpdateText;
    }

    private void OnDisable()
    {
        SubSkillUI.OnAdded -= UpdateText;
    }

    public void UpdateText(SubSkill s)
    {
        title.text = s.subSkillName;
        desc.text = s.description;
    }
}
