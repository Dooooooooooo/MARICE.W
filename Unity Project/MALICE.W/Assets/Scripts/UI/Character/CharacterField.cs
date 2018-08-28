using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using MW.UI;

public class CharacterField : FormattedField<Character> {}

/*

var nameField = name.AddComponent<CharacterField>();
nameField.Bind(_ => chara)
         .WithFormat(c => c.GetNAME());

nameField.NotifyUpdate();

 */