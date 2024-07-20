[System.Serializable]
public class guardado 
{
    public float[] positionn = new float[3]; // se guada la posicon tranform 

    // constructor  inicializa una instacia de clase 

    public guardado(autoguardado guardar ) // este es el constructor ?? interesante 
    {
        positionn[0] = guardar.posicionplayer.x;
        positionn[1] = guardar.posicionplayer.y;
        positionn[2] = guardar.posicionplayer.z;
      

    }


}
