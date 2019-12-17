using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    Dictionary<string, bool> _objects = new Dictionary<string, bool>();

    public Inventory()
    {
        _objects.Add("SilverKey", false);
    }


    //Suponiendo que el objeto existe, lo pone true
    public void Agregar(string item) => _objects[item] = true;

    //Si el objeto existe dará lo pedido, sino existe dará falso
    public bool Tiene(string item)
    {
        try
        {
            return _objects[item];
        }
        catch (KeyNotFoundException e) 
        {
            return false;
        }
    }
}
