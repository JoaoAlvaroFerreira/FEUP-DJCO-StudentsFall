using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using System.Xml;
using System.IO;
using System;

public class ParseEnemy
{
    private UnityEngine.Object prefab;
    private ArrayList wave;
    private Vector2 position1;
    private Vector2 position2;
    private string name;
    private string prefab_name;
    private int boss;
    private float fire_interval;
    private int hp;

    public ParseEnemy(string name,XmlNode enemy)
    {
        this.name = name;
        try
        {
            this.boss = int.Parse(enemy.Attributes["boss"].Value);
            this.prefab_name = enemy.Attributes["prefab"].Value;
        }
        catch (Exception)
        {
            throw new ParsingError("boss atributte should be a number");
        }
        this.prefab = Resources.Load("Prefabs/enemies/" + prefab_name);
        if(this.prefab == null)
            throw new ParsingError("the prefab doesn't exist");
        XmlNodeList childs = enemy.ChildNodes;
        wave = new ArrayList();
        if (childs[0].Name == "pattern")
        {
            foreach(XmlNode node_value in childs[0])
            {
                if (node_value.Name == "value")
                {
                    float value = float.Parse(node_value.FirstChild.Value, CultureInfo.InvariantCulture);
                    wave.Add(value);
                }
                else
                    throw new ParsingError("pattern should have values");
            }
        }
        else throw new ParsingError("enemy should have a pattern");
        if(childs[1].Name == "position1" && ((XmlElement)childs[1]).HasAttribute("x") && ((XmlElement)childs[1]).HasAttribute("y"))
        {
            try
            {
                float x = float.Parse(((XmlElement)childs[1]).GetAttribute("x"), CultureInfo.InvariantCulture);
                float y = float.Parse(((XmlElement)childs[1]).GetAttribute("y"), CultureInfo.InvariantCulture);
                position1 = new Vector2(x, y);
            }
            catch (Exception)
            {
                throw new ParsingError("position1 x and y should be float values");
            }
        }
        else throw new ParsingError("enemy should have a position1 with x and y");
        if (childs[2].Name == "position2" && ((XmlElement)childs[2]).HasAttribute("x") && ((XmlElement)childs[2]).HasAttribute("y"))
        {
            try
            {
                float x = float.Parse(((XmlElement)childs[2]).GetAttribute("x"), CultureInfo.InvariantCulture);
                float y = float.Parse(((XmlElement)childs[2]).GetAttribute("y"), CultureInfo.InvariantCulture);
                position2 = new Vector2(x, y);
            }
            catch (Exception)
            {
                throw new ParsingError("position2 x and y should be float values");
            }
        }
        else throw new ParsingError("enemy should have a position2 with x and y");
        if (childs[3].Name == "fire" && ((XmlElement)childs[3]).HasAttribute("interval"))
        {
            try
            {
                float interval = float.Parse(((XmlElement)childs[3]).GetAttribute("interval"), CultureInfo.InvariantCulture);
                this.fire_interval = interval;
            }
            catch (Exception)
            {
                throw new ParsingError("fire should have attribute interval");
            }
        }
        else throw new ParsingError("enemy should have a fire with interval");
        if (childs[4].Name == "hp")
        {
            try
            {
                this.hp = int.Parse(childs[4].FirstChild.Value);
            }
            catch (Exception)
            {
                throw new ParsingError("hp should have a number");
            }
        }
        else throw new ParsingError("enemy should have hp");
    }

    public void Spawn()
    {
        //Debug.Log(prefab);
        GameObject go = Controller.ints(prefab, new Vector2(UnityEngine.Random.Range(-4f,5f), -6), Quaternion.identity);
        go.GetComponent<Enemy>().setToPosition1(position1);
        go.GetComponent<Enemy>().setToPosition2(position2);
        go.GetComponent<Enemy>().setWave(wave);
        go.GetComponent<Enemy>().setHp(hp);
        go.GetComponent<Enemy>().setFireInterval(fire_interval);
        go.GetComponent<Enemy>().setIsBoss(boss);
    }

    public string getName()
    {
        return this.name;
    }

}
