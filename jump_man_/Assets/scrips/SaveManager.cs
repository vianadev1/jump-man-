
using UnityEngine;
using System.IO; // ttrabajr con archivos 
using System.Runtime.Serialization.Formatters.Binary; // usar el conversosr binario 
public static class SaveManager 
{
 
    public static void savepositiondata(autoguardado player) //metodo de guardado no se puede intaciar 
    {

        guardado Guardado = new guardado(player);  //instacia de payer data o en mi caso de guardado
        string datapath = Application.persistentDataPath + "jump.save"; //ruta depl archivo de guardado una ruta persistente 
        FileStream fileStream = new FileStream(datapath, FileMode.Create);  //creacion del archivo se le pasa la ruta 
        BinaryFormatter binaryFormatter = new BinaryFormatter(); //formato del archivo  para convertirlos datos a binario 
        binaryFormatter.Serialize(fileStream, Guardado); ///incializar el convertidor binarion 
        fileStream.Close(); //cerrar el archivo 


    }

    //public static   cargar datos 

    public static  guardado loadposition()
    {
        


            string datapath = Application.persistentDataPath + "jump.save"; // misma ruta 
            if (File.Exists(datapath))  // saber swi existe el archivo de guardado 
            {
                FileStream fileStream = new FileStream(datapath, FileMode.Open);  //abriir el archivo 
                BinaryFormatter binaryFormatter = new BinaryFormatter(); //formato del archivo  para convertirlos datos a binario 
                guardado Player = (guardado)binaryFormatter.Deserialize(fileStream); //desarilizar el archivo  los guardo en la varible guardado  y hacer un casteo ??
                fileStream.Close();
                return Player;
            }
            else
            {

                Debug.Log("no se encontro ningun archivo ");
                FileStream fileStream = new FileStream(datapath, FileMode.Create);
                fileStream.Close();
                return null;

            }
        
      

    }
}
