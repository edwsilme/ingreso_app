using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace controlApp.Logica
{
    class lusuarios
    {
        private int idusuario;
        private string usuario;
        private string pass;
        private byte[] icono;
        private string estado;

        public int Idusuario
        {
            get { return idusuario; }
            set { idusuario = value; }
        }

        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        public string Pass
        {
            get { return pass; }
            set { pass = value; }
        }

        public byte[] Icono
        {
            get { return icono; }
            set { icono = value; }
        }

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }


        public lusuarios()
        {

        }

        public lusuarios(int idusuario, string usuario, string pass, byte[] icono, string estado)
        {
            Idusuario = idusuario;
            Usuario = usuario;
            Pass = pass;
            Icono = icono;
            Estado = estado;
        }
    }
}
