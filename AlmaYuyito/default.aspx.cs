using LibYuyiyo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibYuyiyo.Helper;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using LibYuyiyo.Neg;
using System.Data;

namespace AlmaYuyito
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
    
            litTitulo.Text = "";
           
            
            
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {

            creaGraficos();

        }


        public void creaGraficos()
        {


            string datosVentas = obtenerDatosIngresos();
            DataTable datosProductos = obtenerDatosProductos();

            string prueba = datosProductos.Rows[0][0].ToString()+"       "+ datosProductos.Rows[0][1].ToString();


            string data2 = "{"
                              + "  labels: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun', 'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],"
                              + "  datasets: [{"
                              + "      data: [750, 445, 483, 503, 689, 692, 634,700, 445, 483, 503, 689],"
                              + "      backgroundColor: '#0059b6',"
                              + "      borderColor: '#007bff',"
                              + "      borderWidth: 1, "
                              + "      pointBackgroundColor: '#007bff' "
                              + " }]"
                          + "}";
            string data3 = "{"
                              + "   type: 'line',"
                              + "   data: " + data2 + ","
                              + "   options: {"
                              + "       scales: {"
                              + "           yAxes: [{"
                              + "               ticks: {  "
                              + "                   beginAtZero: false,"
                              + "                   callback: function (value, index, values) {"
                              + "                       return float2dollar(value);"
                              + "                   }"
                              + "               }"
                              + "           }]"
                              + "       },"
                              + "       legend: {"
                              + "           display: false"
                              + "       }"
                              + "   }"
                          + "}";

            var jobject = JsonConvert.DeserializeObject(data2);

            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert("+JObject.Parse(data2)["labels"]+")", true);

            JObject json = new JObject();
            
            string script = "crearChartLine("+datosVentas+ "); crearChartBar(); crearChartPie(" + datosProductos.Rows[0][0].ToString() + "," + datosProductos.Rows[0][1].ToString() + ");";

            ScriptManager.RegisterStartupScript(this, GetType(), "alerta", script, true);

            
            //script = "crearChartLine();";

            //ScriptManager.RegisterStartupScript(this, GetType(), "alerta", script, true);
        }

        public string obtenerDatosIngresos()
        {
            DataTable dt = NegEstadisticas.traerInformacionIngresos();
            DataTable montos = new DataTable();
            montos.Columns.Add("1");
            montos.Columns.Add("2");
            montos.Columns.Add("3");
            montos.Columns.Add("4");
            montos.Columns.Add("5");
            montos.Columns.Add("6");
            montos.Columns.Add("7");
            montos.Columns.Add("8");
            montos.Columns.Add("9");
            montos.Columns.Add("10");
            montos.Columns.Add("11");
            montos.Columns.Add("12");

            montos.Rows.Add(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            foreach (DataRow row in dt.Rows)
            {
                montos.Rows[0][int.Parse(row["Mes"].ToString())] = int.Parse(row["Total"].ToString());

            }

            string datosVentas = String.Format("[{0},{1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}]",
                                                montos.Rows[0][0],
                                                montos.Rows[0][1],
                                                montos.Rows[0][2],
                                                montos.Rows[0][3],
                                                montos.Rows[0][4],
                                                montos.Rows[0][5],
                                                montos.Rows[0][6],
                                                montos.Rows[0][7],
                                                montos.Rows[0][8],
                                                montos.Rows[0][9],
                                                montos.Rows[0][10],
                                                montos.Rows[0][11]);

            return datosVentas;
        }


        public DataTable obtenerDatosProductos()
        {
            string nombres = "[";
            string valores = "[";

            DataTable datos = new DataTable();
            DataTable dt = NegEstadisticas.traerInformacionProductos();

            int contador = dt.Rows.Count;

            foreach (DataRow row in dt.Rows)
            {
                if (contador == 1)
                {
                    nombres += "'" + row["Producto"].ToString() + "']";
                    valores += row["Vendidos"].ToString() + "]";
                }
                else
                {
                    nombres += "'" + row["Producto"].ToString() + "',";
                    valores += row["Vendidos"].ToString() + ",";
                }
                
                contador -= 1;
            }

            datos.Columns.Add("Nombre");
            datos.Columns.Add("Cantidad");

            datos.Rows.Add(nombres,valores);
            return datos;
        }
    }
}