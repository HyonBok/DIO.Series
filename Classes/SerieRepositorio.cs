using System;
using System.Collections.Generic;
using DIO.Series.Interfaces;

namespace DIO.Series
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> listaSeries = new List<Serie>();
        public List<Serie> Lista()
        {
            return listaSeries;   
        }

        public Serie RetornaPorId(int id)
        {
            return listaSeries[id];
        }
        
        public void Atualiza(int id, Serie entidade)
        {
            listaSeries[id] = entidade;
        }

        public void Exclui(int id)
        {
            listaSeries[id].Excluir();   
        }

        public void Insere(Serie entidade)
        {
            listaSeries.Add(entidade);
        }

        public int ProximoId()
        {
            return listaSeries.Count;
        }
    }
}