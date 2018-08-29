using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System;

using MW.UI;

//初期宣言

public class CreateData : MonoBehaviour
{
    //各種宣言
    public ToggleGroup toggleGroup;
    public InputField NameField;
    public DataCheck dataCheck;
    public CharaName charaName;
    public CharaSex charaSex;

    public CreateButton createButton;
    public CanselButton canselButton;

    [SerializeField] GameObject m_characterNameField;
    [SerializeField] GameObject m_characterSexField;

    private CharacterField _name;
    //Character chara = new Character();

    //さすがに複数扱うことはないでしょう...
    public static UpdateObservant<Character> character
        = new UpdateObservant<Character>(new Character());

    void Start()
    {
        //名前受けとる
        NameField = GetComponent<InputField>();

        m_characterNameField.GetComponent<CharacterField>()
                            .Bind(character)
                            .WithFormat(c => c.getNAME());
        
        m_characterSexField.GetComponent<CharacterField>()
                           .Bind(character)
                           .WithFormat(c => c.getSEX());
    }

    IEnumerable<int> AvailableJSONFile() {
        for (int i = 1; i <= CharaPager.CHARACTER_FILE_NUMBER; i++){
            Character json_read_box = Character.ReadFrom(i);

            if(json_read_box.getNAME() == "") //m_NAMEが空っぽなら
                yield return i; //渡す
        }
        //for文内で完結しない場合は、例外を飛ばす
        throw new FileNotFoundException("No empty JSON file available.");
    }

    //int flag = 0;//JSONの作成用フラグ
    int score = 0;//スコア初期値
    int time = 0;//タイム初期値
    int id_box = 0;

    public void onClick()
    {
        string selectedLabel = "";

        //フィールド内のデータを検査
        Text tex = GameObject.Find("Text")
                             .GetComponent<Text>(); //InputFieldのデータを受け取る
        if (tex.text == "")
        {
            Debug.Log("Please write user name");
            return;
        }

        if(toggleGroup.AnyTogglesOn()) { //Toggleに値が入っているなら
            selectedLabel = toggleGroup.ActiveToggles() //Toggleのデータを読み出す
                                       .First().GetComponentsInChildren<Text>()
                                       .First(t => t.name == "Label").text;
        } else {
            Debug.Log("Please choose user sex");
            return;
        }


        //Characterを規定値で初期化
        Character chara = new Character();
        chara.setNAME(tex.text);
        chara.setSEX(selectedLabel);
        chara.setHIGHSCORE(score);
        chara.setPLAYTIME(time);
        
        
        //空きのファイルがあったら、そこに書き込む
        foreach(int i in AvailableJSONFile()) {
            chara.setID(i); //キャラクターとIDを紐付け

            //JSONでシリアライズしたのち、書き込む
            try {
                chara.WriteToJson();
            } catch(Exception) {
                continue; //別のファイルで保存を試みる
            }

            break; //ファイルが書き込めたら終了
        }

        character.SetValue(chara); //作製したキャラクターを外から見えるようにする
        
        createButton.GetComponent<CreateButton>().num = chara.getID();
        canselButton.GetComponent<CanselButton>().num = chara.getID();

        dataCheck.GetComponent<DataCheck>().flag_get  = 3;            //成功フラグ
    }

}
