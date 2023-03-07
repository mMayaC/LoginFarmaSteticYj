using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Path = System.IO.Path;

namespace LoginFarmaSteticYj
{
    #region Uso de datos de un usuario
    public class Login
    {
        public Login() { }

        [PrimaryKey, AutoIncrement]
        [MaxLength(10)]
        public int Id { set; get; }

        [MaxLength(20)]
        public string User { get; set; }

        [MaxLength(20)]
        public string Password { get; set; }
    }
    #endregion

    #region Manejo de datos y conexion a BD
    public class Auxiliar
    {
        static object locker = new object();
        SQLiteConnection Connection;
        public Auxiliar() //Esto es un constructor
        {
            Connection = ConectarBD();
            Connection.CreateTable<Login>();
        }

        public SQLite.SQLiteConnection ConectarBD()
        {
            SQLiteConnection conexionBaseDatos;
            string nombreArchivo = "asesoria.db3";
            string ruta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string completaRuta = Path.Combine(ruta, nombreArchivo);
            conexionBaseDatos = new SQLiteConnection(completaRuta);
            return conexionBaseDatos;
        }

        //Selecionar 1 registro
        public Login SelecionarUno(string NombreUsuario, string ClaveUsuario)
        {
            lock (locker)
            {
                return Connection.Table<Login>().FirstOrDefault(x => x.User == NombreUsuario && x.Password == ClaveUsuario);
            }
        }

        //Selecionar Muchos
        public IEnumerable<Login> SeleccionarTodo()
        {
            lock (locker)
            {
                return (from i in Connection.Table<Login>() select i).ToList();
            }
        }

        //Guardar
        //Actualizar o insertar
        public int Guardar(Login registro)
        {
            lock (locker)
            {
                if (registro.Id == 0)
                {
                    return Connection.Insert(registro);
                }
                else
                {
                    return Connection.Update(registro);
                }
            }
        }
        //Eliminar
        public int Eliminar(int ID)
        {
            lock (locker)
            {
                return Connection.Delete<Login>(ID);
            }
        }

    }
    #endregion
}