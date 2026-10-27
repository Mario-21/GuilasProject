
[System.Serializable]
public class ListaTodosObjetos
{
    
    public string nombreObjeto;
    public string idObjeto;
    public bool objetoObtenido;
    public int ubiPosButton;
    public int vecesUsadoObjeto;

    //Idiomas Objeto
    public string nombreObjetoEspañol;
    public string nombreObjetoIngles;

    


    public void ListaObjetos(string nombreObjeto, bool objetoObtenido, int UbiPos, int VecesUsado)
    {
        this.nombreObjeto = nombreObjeto;
        this.objetoObtenido = objetoObtenido;
        this.ubiPosButton = UbiPos;
        this.vecesUsadoObjeto = VecesUsado;
    }
}
