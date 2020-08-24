using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using System.Xml;
using System.IO;
using System;

public class ParseLevels
{
    private int level_number;
    private ArrayList waves;
    private int wave_number=0;
    public ParseLevels(int number, XmlNode level)
    {
        this.waves = new ArrayList();
        this.level_number = number;
        XmlNodeList waves = level.ChildNodes;
        foreach (XmlNode wave in waves)
        {
            if(wave.Name == "wave")
            {
                float wave_interval = float.Parse(wave.Attributes["interval"].Value, CultureInfo.InvariantCulture);
                ParsingWave parsing_wave = new ParsingWave(wave_interval, wave);
                this.waves.Add(parsing_wave);

            }
            else
                throw new ParsingError("a level should have waves");
        }
    }

    public Boolean PlayLevel(float deltaTime, ArrayList enemies_objects)
    {
        if(((ParsingWave)waves[wave_number]).PlayWave(deltaTime, enemies_objects))
        {
            wave_number++;
            if (wave_number >= waves.Count)
                return true;
        }
        return false;
    }

    public void resetLevel()
    {
        wave_number = 0;
    }
}
