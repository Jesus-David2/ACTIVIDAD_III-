using System;

namespace ACTIVIDAD_10
{

    usando el  sistema ;
utilizando  System . Colecciones . Genérico ;
utilizando  System . Linq ;
utilizando  System . IO ;
utilizando  System . Windows . Formularios ;

espacio de nombres  c_sahrp
{
     clase  pública BaseDeDatos
    {
        privada  const  string  DEL  =  " (% $ # ·· # · $$ @) " ;
        private  string  _ruta  =  Aplicación . StartupPath  +  " \\ db \\ " ;
         cadena  pública Tabla { get ; establecer ; }
         BaseDeDatos públicos ( cadena  t ) { Tabla  =  t ; carpeta (); if ( ! Existe ( " Usuarios " )) CrearTabla ( " Usuarios " , nueva  cadena [] { " ID " , " Nombre de usuario " , " Contraseña " }); }
        / * ********************************** * /
        public  static  void  CrearTabla ( string  n , string [] col )
        {
            string  ruta  =  Aplicación . Ruta de inicio  +  " \\ db \\ "  +  n  +  " .gdb " ;
            Archivo . WriteAllText ( ruta , cadena . Join ( DEL , col ));
        }

        public  static  void  EliminarTabla ( string  n )
        {
            string  ruta  =  Aplicación . Ruta de inicio  +  " \\ db \\ "  +  n  +  " .gdb " ;
            if ( Archivo . Existe ( ruta )) Archivo . Eliminar ( ruta );
        }

        public  static  bool  Existe ( nombre de la cadena  ) { Archivo de retorno . Existe ( Aplicación . StartupPath + " \\ db \\ " + nombre + " .gdb " );}       
        / * **************************************** * /
        public  void  Insertar ( Lista < cadena > valores )
        {
            excepcion ();
            Archivo . AppendAllText ( Ruta (), " \ r \ n "  +  cadena . Unir ( DEL , valores ));
        }
         cadena  privada actualizar  =  " \ r \ n " ;
        public  void  Actualizar ( Func < string , bool > b , int  index , List < string > valores )
        {
            excepcion ();
            string [] lineas  =  SplitLINEAS ( Archivo . ReadAllText ( Ruta ()));
            string  txt_nuevo  =  lineas [ 0 ];
            para ( int  i  =  1 ; i  <  lineas . Longitud ; i ++ )
                txt_nuevo  + =  b ( SplitDEL ( lineas [ i ]) [ índice ]) ?  actualizar  +  cadena . Unir ( DEL , valores ) :  " \ r \ n "  +  lineas [ i ];
            Archivo . WriteAllText ( Ruta (), txt_nuevo );
        }
        public  void  Eliminar ( Func < string , bool > b , int  index )
        {
            actualizar  =  " " ;
            Actualizar ( b , índice , nueva  lista < cadena > ());
            actualizar  =  " \ r \ n " ;
        }

        / * ***************************************** * /
        public  List < List < string >> Buscar ( Func < string , bool > b , int  index , bool  col )
        {
            excepcion ();

            string  txt  =  Archivo . ReadAllText ( Ruta ());
            Lista < Lista < cadena >> r  =  nueva  Lista < Lista < cadena >> ();
            si ( col ) r . Agregar ( SplitDEL ( SplitLINEAS ( txt ) [ 0 ]). ToList ());

            para ( int  i  =  1 ; i  <  SplitLINEAS ( txt ). Longitud ; i ++ )
            {
                cadena  celda  =  SplitDEL ( SplitLINEAS ( txt ) [ i ]) [ índice ];
                si ( b ( celda )) r . Agregar ( SplitDEL ( SplitLINEAS ( txt ) [ i ]). ToList ());
            }
            return  r ;
        }

        Public  List < List < string >> Abrir () { return  Buscar ( x  =>  x . Length  > =  0 , 0 , true ); }

        public  void  VerEnDGV ( DataGridView  d , List < List < string >> t )
        {
            d . Filas . Borrar (); d . Columnas . Borrar ();
            para ( int  i  =  0 ; i  <  t [ 0 ]. Count ; i ++ ) d . Columnas . Sumar ( t [ 0 ] [ i ], t [ 0 ] [ i ]);

            para ( int  i  =  1 ; i  <  t . Count ; i ++ )
            {
                 Fila de  DataGridViewRow =  nuevo  DataGridViewRow ();
                fila . CreateCells ( d );
                para ( int  x  =  0 ; x  <  t [ i ]. Count ; x ++ ) fila . Celdas [ x ]. Valor  =  t [ i ] [ x ];
                d . Filas . Agregar ( fila );
            }
        }
        / * **************************************** * /
         Lista pública < Lista < cadena >> DGVaLista ( DataGridView  d )
        {
            Lista < Lista < cadena >> r  =  nueva  Lista < Lista < cadena >> ();

            Lista < cadena > columnas  =  nueva  Lista < cadena > ();
            for ( int  i  =  0 ; i  <  d . Columns . Count ; i ++ )
                columnas . Agregar ( d . Columnas [ i ]. EncabezadoTexto );

            r . Agregar ( columnas );

            para ( int  i  =  0 ; i  <  d . Filas . Count  -  1 ; i ++ )
            {
                Lista < cadena > celdas  =  nueva  Lista < cadena > ();
                foreach ( celda DataGridViewCell  en d . Filas [ i ]. Celdas )  
                    celdas . Agregar ( Convertir . ToString ( celda . Valor ));
                r . Agregar ( celdas );
            }

            return  r ;
        }

        public  void  Guardar ( List < List < string >> t )
        {
            Lista < cadena > filas  =  nueva  Lista < cadena > ();
            para ( int  i  =  0 ; i  <  t . Count ; i ++ ) filas . Agregar ( cadena . Unir ( DEL , t [ i ]));
            Archivo . WriteAllText ( Ruta (), string . Join ( " \ r \ n " , filas ));
        }

        / * **************************************** * /
         cadena  privada Ruta () { return  _ruta  +  Tabla  +  " .gdb " ; }
        private  void  excepcion () { if ( Tabla  ==  " "  ||  ! Archivo . Existe ( Ruta ())) lanzar  nueva  Excepción ( " Tabla no encontrada. " ); }
        private  void  carpeta () { if ( ! Directory . Exists ( _ruta )) Directory . CreateDirectory ( _ruta ); }
         cadena privada [] SplitDEL ( cadena  txt ) { return  txt . Split ( nueva  cadena [] { DEL }, StringSplitOptions . Ninguna ); }
         cadena privada [] SplitLINEAS ( cadena  txt ) { return  txt . Dividir ( nueva  cadena [] { " \ r \ n " }, StringSplitOptions . Ninguna ); }
    }
}

}