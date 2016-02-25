using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de AutoComplete
/// </summary>
public class AutoComplete
{
    public AutoComplete()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
    public int id;
    public string ID;
    public string label;
    public string nombre;
    public string aux;
    public string app;
    public string apm;

    public void setLabel(string label)
    {
        this.label = label;
    }
    public string getLabel()
    {
        return this.label;
    }
    //mi codigo
    public void setaux(string aux)
    {
        this.aux = aux;
    }
    public string getaux()
    {
        return this.aux;
    }
    //fin de mi codigo
    public void setID(string ID)
    {
        this.ID = ID;
    }

    public string getID()
    {
        return ID;
    }


    public void setId(int id)
    {
        this.id = id;
    }
    public void setNombre(string nombre)
    {
        this.nombre = nombre;
    }
    public int getId()
    {
        return id;
    }
    public string getNombre()
    {
        return this.nombre;
    }

    public string getapp()
    {
        return this.app;
    }
    public void setApp(string app)
    {
        this.app = app;
    }
    public string getapm()
    {
        return this.apm;
    }
    public void setApm(string apm)
    {
        this.apm = apm;
    }
}