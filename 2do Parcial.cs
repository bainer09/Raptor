using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Resuelto_01
{
    public partial class formPrincipal : Form
    {
        List<Proveedor> proveedores = new List<Proveedor>();
        List<Factura> facturas = new List<Factura>();

        public formPrincipal()
        {
            InitializeComponent();
        }

        //CARGA DE FORMS
        //Automoviles
        
        private void formPrincipal_Load(object sender, EventsArg e)
        {
            CargarAutomoviles();
        }

        private void CargarAutomoviles()
        {
            string path = "C:\\Automovil.txt";
            FileInfo fi = new FileInfo(path);

            if(!fi.Exists)
            {
                MessageBox.Show("No existe el archivo en la ruta definida.");
            }
            else
            {
                StreamReader sr = fi.OpenText();

                while(!sr.EndOfStream)
                {
                    string linea = sr.ReadLine();
                    string [] vector = linea.Split(';');

                    Automovil a = new Automovil();
                    a.Dominio = vector[0];
                    a.Kilometraje = vector[1];
                    a.Marca = vector[2];
                    a.Modelo = vector[3];
                    a.AñoDeFabricacion = vector[4];
                    a.Tipo = vector[5];
                    a.Alquilado = vector[6];
                    automoviles.Add(a);
                }

                sr.Close();
                MessageBox.Show("Se cargó correctamente el archivo.");

                cmbTipo.Items.Add("Grande");
                cmbTipo.Items.Add("Mediano ");
                cmbTipo.Items.Add("Chico");
                cmbTipo.Items.Add("Lujoso");
                txtDominio.Focus();
            }
        }


        //Bodegas
        private void form_Load(object sender, EventArgs e)
        {
            CargarReservas();
            CargarBodegas();
        }
        
        private void CargarReservas()
        {
            string path = "C:\\Reservas.txt";
            FileInfo fi = new FileInfo(path);

            if(!fi.Exists)
            {
                MessageBox.Show("No existe el archivo en la ruta especificada.")
            }
            else
            {
                StreamReader sr = fi.OpenText();;

                while(!sr.EndOfStream)
                {
                    string linea = sr.ReadLine();
                    string[] vector = linea.Split(';');

                    Reserva r = new Reserva();
                    r.NombreBodega = vector[0];
                    r.Fecha = vector[1];
                    r.Tipo = vector [2];
                    r.Personas = vector [3];
                    reservas.Add(r)
                }

                sr.Close();
                MessageBox.Show("Se cargo correctamente el archivo.");

                cmbTipoReserva.Items.Add("Degustacion");
                cmbTipoReserva.Items.Add("Almuerzo");
                cmbTipoReserva.Items.Add("Visita Guiada");
            }
        }

        private void CargarBodegas()
        {
            string path = "C:\\Bodegas.Txt";
            FileInfo fi = new FileInfo(path);

            if(!fi.Exists)
            {
                MessageBox.Show("No existe el archivo en la ruta especificada.");
            }
            else
            {
                StreamReader sr = fi.OpenText();

                while(!sr.EndOfStream)
                {
                    string linea = sr.ReadLine();
                    string [] vector = linea.Split(';');

                    Bodega b = new Bodega();            
                    b.Nombre = vector[0];
                    b.Ubicacion = vector[1];
                    b.Puntaje = vector[2];
                    bodegas.Add(b);
                    lstBodegas.Items.Add(b.Nombre);
                }

                sr.Close();
                MessageBox.Show("Se cargó correctamente el archivo.");
            }
        }

        
        //Estudio Contable

        private void formPrincipal_Load(object sender, EventArgs e)
        {
            CargarProveedores();
            CargarFacturas();
        }

        private void CargarProveedores()
        {
            string path = "C:\\Proveedor.txt";
            FileInfo fi = new FileInfo(path);

            if(!fi.Exists)
            {
                MessageBox.Show("El archivo no existe en la ruta especificada.");
            }
            else
            {
                StreamReader sr = fi.OpenText();

                while(!sr.EndOfStream)
                {
                    string linea = sr.ReadLine();
                    string [] vector = linea.Split(';');

                    Proveedor p = new Proveedor();
                    p.Cuit = vector[0];
                    p.RazonSocial = vector[1];
                    p.Direccion = vector[2];
                    p.Telefono = vector[3];

                    proveedores.Add(p);
                    lstProveedor.Items.Add(p.Cuit);
                }

                sr.Close();
                MessageBox.Show("Se cargo correctamente el archivo.");
            }
        }

        private void CargarFacturas()
        {
            string path = "C:\\Factura.txt";
            FileInfo fi = new FileInfo(path);

            if(!fi.Exists)
            {
                MessageBox.Show("El archivo no existe en la ruta especificada.");
            }
            else
            {
                StreamReader sr = fi.OpenText();

                while(!sr.EndOfStream)
                {
                    string linea = sr.ReadLine();
                    string[] vector = linea.Split(';');

                    Factura f = new Factura();
                    f.Codigo = vector[0];
                    f.CuitProveedor = vector[1];
                    f.Monto = vector[2];
                    f.Fecha = vector[3];

                    facturas.Add(f);
                }
            }
        }


        //Tienda Ropa
        private void FormPrincipal_Load (object sender, EventArgs e)
        {
            CargarProductos();
            CargarFacturas();
            CargarStock();
        }

        private void CargarProductos()
        {
            string path = "C:\\Producto.txt";
            FileInfo fi = new FileInfo(path);

            if(!fi.Exists)
            {
                MessageBox.Show("No existe el archivo en la ruta especificada.")
            }
            else
            {
                StreamReader sr = fi.OpenText();

                while(!sr.EndOfStream)
                {
                    string linea = sr.ReadLine();
                    string[] vector = linea.Split(';');

                    Producto p = new Producto();
                    p.Codigo = vector[0];
                    p.Descripcion = vector[1];
                    p.Precio = vector[2];

                    productos.Add(p);
                    lstProductos.Items.Add(p.Codigo + ";" + p.Descripcion);
                }

                sr.Close();
                MessageBox.Show("El archivo se cargo correctamente.");
                cboTalles.Items.Add("XS");
                cboTalles.Items.Add("S");
                cboTalles.Items.Add("M");
                cboTalles.Items.Add("L");
                cboTalles.Items.Add("XL");
            }
        }

        private void CargarFacturas()
        {
            string path = "C://Factura.txt";
            FileInfo fi = new FileInfo(path);

            if(!fi.Exists)
            {
                MessageBox.Show("El archivo no existe en la ruta.");
            }
            else
            {
                StreamReader sr = fi.OpenText();

                while(!sr.EndOfStream)
                {
                    string linea = sr.ReadLine();
                    string[] vector = linea.Split(';');

                    Factura f = new Factura();
                    f.Codigo = vector[0];
                    f.Total = vector[1];
                    f.Fecha = vector[2];
                    facturas.Add(f);
                }

                sr.Close();
                MessageBox.Show("Se cargo correctamente el archivo.");
            }
        }

        private void CargarStock()
        {
            string path = "C://Stock.txt";
            FileInfo fi = new FileInfo(path);

            if(!fi.Exists)
            {
                MessageBox.Show("El archivo no existe en la ruta.");
            }
            else
            {
                StreamReader sr = fi.OpenText();

                while(!sr.EndOfStream)
                {
                    string linea = sr.ReadLine();
                    string[] vector = linea.Split(';');

                    Stock s = new Stock();
                    s.Codigo = vector[0];
                    s.Talle = vector [1];
                    s.Cantidad = vector[2];

                    stocks.Add(s);
                }

                sr.Close();
                MessageBox.Show("Se cargo correctamente el archivo.");
            }
        }


        //Parcial Profes
        private void form_Load(object sender, EventArgs e)
        {
            CargarProfesores();
            CargarReservas();
        }

        private void CargarProfesores()
        {
            string path = "C://Profesores.txt";
            FileInfo fi = new FileInfo(path);

            if(!fi.Exists)
            {
               MessageBox.Show("El archivo no existe en la ruta."); 
            }
            else
            {
                StreamReader sr = fi.OpenText();

                while(!sr.EndOfStream)
                {
                    string linea = sr.ReadLine();
                    string[] vector = linea.Split(';');

                    Profesor p = new Profesor();
                    p.Dni = vector[0];
                    p.Nombre = vector[1];
                    p.Apellido = vector[2];
                    p.Valoracion = vector[3];
                    profesores.Add(p);

                    lstProfesores.Items.Add(p.Dni);
                }

                sr.Close();
                MessageBox.Show("Se cargo correctamente el archivo.");
            }
        }

        private void CargarReservas()
        {
            string path = "C://Reservas.txt";
            FileInfo fi = new FileInfo(path);

            if(!fi.Exists)
            {
                MessageBox.Show("El archivo no existe en la ruta.")
            }
            else
            {
                StreamReader sr = fi.OpenText();

                while(!sr.EndOfStream)
                {
                    string linea = sr.ReadLine();
                    string[] vector = linea.Split(';');

                    Reserva r = new Reserva();
                    r.Fecha = vector[0];
                    r.Turno = vector[1];
                    r.DniProfesor = vector[2];
                    r.Personas = vector[3];

                    reservas.Add(r);
                }

                sr.Close();
                MessageBox.Show("Se cargo correctamente el archivo.");
                cmbTurnoReserva.Items.Add("Mañana");
                cmbTurnoReserva.Items.Add("Tarde");
            }
        }


        //FINALIZACION DE JORNADA
        //Automoviles
        private void formPrincipal_FormClosed(object sender, EventsArg e)
        {
            GuardarAutomoviles();
        }

        private void GuardarAutomoviles()
        {
            path = "C://Automoviles.txt";
            StreamWriter sw = new StreamWriter(path);

            foreach(Automovil a in automoviles)
            {
                sw.WriteLine(a.Dominio + ";" + a.Kilometraje + ";" + a.Marca + ";" + a.Modelo + ";" + a.AñoFabricacion + ";" + a.Tipo + ";" + a.Alquilado);
            }

            sw.Close();
            MessageBox.Show("Se guardo correctamente el archivo.");
        }

        //Delivery
        private void FormPrincipal_FormClosed (object sender, EventArgs e)
        {
            GuardarPedido();
        }

        private void GuardarPedido()
        {
            string path = "C://Pedidos.txt";
            StreamWriter sw = new StreamWriter(path);

            foreach(Pedido p in pedidos)
            {
                sw.WriteLine(p.NroPedido + ";" + p.Fecha + ";" + p.Telefono + ";" + p.Direccion + ";" + p.DniCadete + ";" + p.Estado + ";" + p.Descripcion + ";" + p.Total);
            }

            sw.Close();
            MessageBox.Show("Se guardo correctamente el archivo.");
        }

        //Estudio Contable
        private void formPrincipal_FormClosed(object sender, EventArgs e)
        {
            GuardarFacturas();
        }

        private void GuardarFacturas()
        {
            string path = "C://Facturas.txt";
            StreamWriter sw = new StreamWriter(path);

            foreach(Factura f in facturas)
            {
                sw.WriteLine(f.Codigo + ";" + f.CuitProveedor + ";" + f.Monto + ";" + f.Fecha);
            }

            sw.Close();
            MessageBox.Show("Se guardo correctamente el archivo.");
        }


        //AGREGAR
        //Automoviles
        private void btnAgregar_Click (object sender, EventArgs e)
        {
            string dominio = txtDominio.Text;
            string kilometraje = txtKilometraje.Text;
            string marca = txtMarca.Text;
            string modelo = txtModelo.Text;
            string añoFabricacion = txtAñoFabricacion.Text;
            string tipo = cmbTipo.Text;
            string errores = "";

            errores += ValidarDominio(dominio, "Dominio");
            errores += ValidarNumero(kilometraje, "Kilometraje");
            errores += ValidarNumero(añoFabricacion, "Año de Fabricacion");
            errores += ValidarVacio(Marca, "Marca");
            errores += ValidarVacio(Modelo, "Modelo");
            errores += ValidarVacio(Tipo, "Tipo");

            if(!String.IsNullOrEmpty(errores))
            {
                MessageBox.Show(errores, "Error!");
            }
            else
            {
                Automovil a = new Automovil();
                a.Dominio = dominio;
                a.Kilometraje = Convert.ToInt32(kilometraje);
                a.Marca = marca;
                a.Modelo = modelo;
                a.AñoFabricacion = Convert.ToInt32(añoFabricacion);
                a.Tipo = tipo;
                a.Alquilado = chkAlquilado.Checked;

                automoviles.Add(a);
                MessageBox.Show("Se agrego correctamente.");
            }
        }

        private string ValidarDominio(string dominio, string campo)
        {
            string error;
            automovil a = BuscarAutomovil(dominio);

            if(!string.IsNullOrEmpty(dominio))
            {
                errores = "El campo " + campo + " no puede estar vacio." + \n;
            }
            else if(a != null)
            {
                errores = "El automovil ya se encuentra cargado." + \n;
            }
            else
            {
                error = "";
            }

            return error;
        }

        private string ValidarNumero(string valor, string campo)
        {
            string error;

            if(!int.TryParse(valor, out int salida))
            {
                error = "El valor en el campo " + campo + " debe ser numerico entero." + \n;
            }
            else if(salida < 1)
            {
                error = "El valor en el campo " + campo + " debe ser positivo." + \n
            }
            else
            {
                error = "";
            }

            return error;
        }

        private string ValidarVacio(string valor, string campo)
        {
            string error;

            if(string.IsNullOrEmpty(valor))
            {
                error = "El valor ingresado en el campo " + campo + " no puede ser vacio."  + \n;
            }
            else
            {
                error = "";
            }

            return error;
        }

        //Bodegas
        private void btnReservar_Click(object sender, EventArgs e)
        {
            string bodega = lstBodegas.Text;
            string fecha = txtFecha.Text;
            string tipo = CmbTipoReserva.Text;
            string personas = txtPersonas.Text;
            string errores = "";

            errores += ValidarBodega();
            errores += ValidarFecha(fecha, "Fecha");
            errores += ValidarTipo();
            errores += ValidarNumero(personas, "Personas");

            if(string.IsNullOrEmpty(errores))
            {
                MessageBox.Show(errores, "Error!");
            }
            else
            {
                Reserva r = new Reserva();
                r.Bodega = bodega;
                r.Fecha = Convert.ToDateTime(fecha);
                r.Tipo = tipo;
                r.Personas = Convert.ToInt32(personas);

                reservas.Add(r);
                MessageBox.Show("Se cargó correctamente el registro.")
            }
        }

        private string ValidarBodega()
        {
            string error;

            if(lstBodegas.SelectedIndex == -1)
            {
                error = "No hay un valor seleccionado en el campo Bodega."  + \n;
            }
            else
            {
                error = "";
            }

            return error;
        }

        private string ValidarFecha(string valor, string campo)
        {
            string error;

            if(!DateTime.TryParse(valor, out DateTime salida))
            {
                error = "El valor en el campo " + campo + " debe ser formato fecha." + \n;
            }
            else if(salida < DateTime.Now)
            {
                error = "La fecha en el campo " + campo + " no puede ser anterior a hoy." + \n;
            }
            else
            {
                error = "";
            }

            return error;
        }

        private string ValidarTipo()
        {
            string error;

            if(cmbTipoReserva.SelectedIndex == -1)
            {
                error = "No se seleccionó un valor en el campo Tipo." + \n;
            }
            else
            {
                error = "";
            }

            return error;
        }

        private string ValidarNumero(string valor, string campo)
        {
            string error;

            if(!int.TryParse(valor, out int salida))
            {
                error = "El valor ingresado en el campo " + campo + " debe ser numerico.";
            }
            else if(salida < 1)
            {
                error = "El valor ingresado en el campo " + campo + " debe ser positivo.";
            }
            else
            {
                error = "";
            }

            return error;
        }

        //Delivery
        private void AgregarPedido()
        {
            string fecha = txtFecha.Text;
            string telefono = txtTelefono.Text;
            string direccion = txtDireccion.Text;
            string dniCadete = cmbDniCadete.Text;
            string estado = txtEstado.Text;
            string descripcion = lstDescripcion.Text;
            string monto = txtMonto.Text;
            string errores = "";

            errores += ValidarVacio(telefono, "Telefono");
            errores += ValidarVacio(direccion, "Direccion");
            errores += ValidarVacio(estado, "Estado");
            errores += ValidarVacio(descripcion, "Descripcion");
            errores += ValidarDni();
            errores += ValidarNumero(monto, "Monto");
            errores += ValidarFecha(fecha, "Fecha");

            if(!string.IsNullOrEmpty(errores))
            {
                MessageBox.Show(errores, "Error!");
            }
            else
            {
                Pedido p = new Pedido();
                p.NroPedido = AsignarNroPedido();
                p.Fecha = Convert.ToDateTime(fecha);
                p.Telefono = telefono;
                p.Direccion = direccion;
                p.DniCadete = Convert.ToInt32(dniCadete);
                p.Estado = estado;
                p.Descripcion = descripcion;
                p.Monto = Conver.ToFloat(monto);
                pedidos.Add(p);
                MessageBox.Show("Se cargo correctamente el registro.")

                BorrarCampos();
            }
        }

        private string ValidarVacio(string valor, string campo)
        {
            string error;

            if(string.IsNullOrEmpty(valor))
            {
                error = "El valor ingresado en el campo " + campo + " no puede ser vacio." + \n;
            }
            else
            {
                error = "";
            }

            return error;
        }

        private string ValidarDni()
        {
            string error;

            if(cmbDniCadete.SelectedIndex == -1)
            {
                error = "Debe seleccionar un valor en el campo DniCadete.";
            }
            else
            {
                error = "";
            }

            return error;
        }

        private string ValidarNumero(string valor, string campo)
        {
            string error;

            if(!int.TryParse(valor, out int salida))
            {
                error = "El valor ingresado en el campo " + campo + " debe ser numerico." + \n;
            }
            else if(salida < 1)
            {
                error = "El valor ingresado en el campo " + campo + " debe ser positivo." + \n;
            }
            else
            {
                error = "";
            }

            return error;
        }

        private string ValidarFecha(string valor, string campo)
        {
            string error;

            if(!DateTime.TryParse(valor, out Datetime salida))
            {
                error = "El valor ingresado en el campo " + campo + " debe ser una fecha." + \n;
            }
            else if(salida != DateTime.Now)
            {
                error = "la fecha ingresada en el campo " + campo + " debe ser igual a la fecha actual." + \n;
            }
            else
            {
                error = "";
            }

            return error;
        }

        //Estudio contable
        private void AgregarFactura()
        {
            string monto = txtMonto.Text;
            string errores = "";

            errores += ValidarPositivo(monto, "Monto");
            errores += ValidarProveedor();

            if(!string.IsNullOrEmpty(errores))
            {
                MessageBox.Show(errores, "Error!");
            }
            else
            {
                Factura f = new Factura();
                f.Codigo = Autonumerar();
                f.CuitProveedor = Convert.ToInt32(lstProveedor.SelectedItem);
                f.Monto = Convert.ToInt32(monto);
                f.Fecha = DateTime.Now
                facturas.Add(f)
            }

            MessageBox.Show("Se agrego correctamente el registro.");
            
        }

        private string ValidarPositivo(string valor, string campo)
        {
            string campo;

            if(!int.TryParse(valor, out int salida))
            {
                error = "El valor ingresado en el campo debe ser numero entero.";
            }
            else if(salida < 1)
            {
                error = "El numero ingresado en el campo debe ser positivo.";
            }
            else
            {
                error = "";
            }
            return error;
        }

        private string ValidarProveedor()
        {
            string error;

            if(lstProveedor.SelectedIndex == -1)
            {
                error = "No se selecciono un valor en el campo.";
            }
            else
            {
                error = "";
            }

            return error;
        }


        //BUSCAR
        //Automoviles
        private void btnBuscar_Click (object sender, EventArgs e)
        {
            string dominio = txtDominio.Text;

            if(string.IsNullOrEmpty(dominio))
            {
                MessageBox.Show("Debe ingresar un valor en el campo Dominio.");
            }
            else
            {
                Automovil a = BuscarAutomovil(dominio);
                if(a == null)
                {
                    MessageBox.Show("No se encontro el automovil con el dominio ingresado.");
                }
                else
                {
                    txtDominio = a.Dominio;
                    txtKilometraje = a.Kilometraje.ToString();
                    txtMarca = a.Marca;
                    txtModelo = a.Modelo;
                    txtAñoFabricacion = a.AñoFabricacion.ToString();
                    cmbTipo = a.Tipo;
                    chkAlquilado = a.Alquilado;
                }
            }
        }

        private automovil BuscarAutomovil(string valor)
        {
            return automoviles.Find(a => a.Dominio == valor);
        }

        //Bodega
        private void btnBuscarBodega_Click(object sender, EventArgs e)
        {
            txtUbicacion.Clear();
            txtPuntaje.Clear();
            string bodega = txtNombre.Text;

            if(string.IsNullOrEmpty())
            {
                MessageBox.Show("El campo Nombre no puede estar vacio.");
            }
            else
            {
                Bodega b = BuscarBodega(bodega);

                if(bodega == null)
                {
                    MessageBox.Show("El nombre de la bodega no existe.");
                }
                else
                {
                    txtUbicacion.Text = b.Ubicacion;
                    txtPuntaje.Text = b.Puntaje.ToString();
                }
            }
        }

        private Bodega BuscarBodega(string valor)
        {
            return bodegas.Find(b => b.Nombre == valor);
        }

        //Estudio Contable
        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            txtRazonSocial.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtCuit.Focus();

            string cuit = txtCuit.Text;

            if(string.IsNullOrEmpty(cuit))
            {
                MessageBox.Show("El campo cuit no puede estar vacio.");
            }
            else
            {
                Proveedor p = BuscarProveedor(cuit);

                if(p == null)
                {
                    MessageBox.Show("El cuit ingresado no corresponde a un proveedor.");
                }
                else
                {
                    txtRazonSocial.Text = p.RazonSocial;
                    txtDireccion.Text = p.Direccion;
                    txtTelefono.Text = p.Telefono.ToString();
                }
            }
        }

        private Proveedor BuscarProveedor(string valor)
        {
            return proveedores.Find(p => p.Cuit == valor);
        }

        //LISTAR
        //Automoviles
        private void btnListar_Click (object sender, EventArgs e)
        {
            lstAutomoviles.Clear();

            if(cmbTipo.SelectedIndex == -1)
            {
                MessageBox.Show("No hay seleccion en el campo tipo.");
            }
            else
            {
                foreach(Automovil a in automoviles)
                {
                    if(a.Alquilado == false && a.Tipo == cmbTipo)
                    {
                        lstAutomoviles.Items.Add(a.Dominio + "-" + a.Marca + "-" + a.Modelo);
                    }
                }

                if(lstAutomoviles.Items.Count == 0)
                {
                    MessageBox.Show("No hay automoviles disponibles del tipo seleccionado.");
                }
            }
        }

        //Delivery
        private void BtnMostrarPedidos_Click(object sender, EventArgs e)
        {
            string mensaje = "";
            foreach(Pedido p in pedidos)
            {
                if(p.Fecha == DateTime.Now.AddDays(-1) && p.Estado == "Entregado")
                {
                    mensaje += p.NroPedido + "," + p.Fecha + "," + p.Telefono + "," + p.Direccion + "," + p.DniCadete + "," + p.Total + "." \n;
                }
            }

            if(string.IsNullOrEmpty(mensaje))
            {
                MessageBox.Show("No se encontraron pedidos.");
            }
            else
            {
                MessageBox.Show(mensaje, "Pedidos del dia anterior");
            }
        }

        //Estudio Contable
        private void btnMostrarFacturas_Click(object sender, EventArgs e)
        {
            string mensaje = "";
            foreach(Factura f in facturas)
            {
                if(f.Fecha > DateTime.Today.AddDays(-5))
                {
                    mensaje = p.Codigo + \n;
                }
            }

            if(string.IsNullOrEmpty(mensaje))
            {
                MessageBox.Show("No se encontraron facturas en los ultimos 5 dias.");
            }
            else
            {
                MessageBox.Show(mensaje, "Facturas";)
            }
        }


        //ELIMINAR
        //Automoviles
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string dominio = txtDominio.Text;
            if(string.IsNullOrEmpty(dominio))
            {
                MessageBox.Show("El campo Dominio no puede estar vacio.");
            }
            else
            {
                EliminarAutomovil(dominio);
            }
        }

        private void EliminarAutomovil(string valor)
        {
            Automovil a = BuscarAutomovil(valor);

            if(a == null)
            {
                MessageBox.Show("No existe el dominio ingresado.");
            }
            else
            {
                automoviles.Remove(a);
                MessageBox.Show("Se elimino correctamente el registro.");
            }
        }

        //

    }
}